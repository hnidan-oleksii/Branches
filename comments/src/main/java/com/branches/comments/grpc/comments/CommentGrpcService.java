package com.branches.comments.grpc.comments;

import com.branches.comments.dto.CommentDTO;
import com.branches.comments.grpc.comments.CommentServiceGrpc.CommentServiceImplBase;
import com.branches.comments.grpc.comments.Comments.Comment;
import com.branches.comments.grpc.comments.Comments.CommentVote;
import com.branches.comments.grpc.comments.Comments.CommentsRequest;
import com.branches.comments.grpc.comments.Comments.CommentsResponse;
import com.branches.comments.service.CommentService;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;

import java.util.List;
import java.util.stream.Collectors;

@GrpcService
public class CommentGrpcService extends CommentServiceImplBase {

    private final CommentService commentService;

    public CommentGrpcService(CommentService commentService) {
        this.commentService = commentService;
    }

    @Override
    public void getCommentsByPostId(CommentsRequest request, StreamObserver<CommentsResponse> responseObserver) {
        List<CommentDTO> comments = commentService.getCommentsByPostId(request.getPostId());

        List<Comment> grpcComments = comments.stream()
                .map(comment -> {
                    List<CommentVote> votes = comment.votes().stream()
                            .map(v -> CommentVote.newBuilder()
                                    .setId(v.id())
                                    .setCommentId(v.commentId())
                                    .setUserId(v.userId())
                                    .setVoteType(v.voteType())
                                    .build())
                            .collect(Collectors.toList());
                    return com.branches.comments.grpc.comments.Comments.Comment.newBuilder()
                            .setId(comment.id())
                            .setPostId(comment.postId())
                            .setUserId(comment.userId())
                            .setContent(comment.content())
                            .addAllVotes(votes)
                            .build();
                }).collect(Collectors.toList());

        CommentsResponse response = CommentsResponse.newBuilder()
                .addAllComments(grpcComments)
                .build();
        responseObserver.onNext(response);
        responseObserver.onCompleted();
    }
}

