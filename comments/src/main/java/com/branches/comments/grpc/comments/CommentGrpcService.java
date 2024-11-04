package com.branches.comments.grpc.comments;

import com.branches.comments.dto.CommentDTO;
import com.branches.comments.grpc.comments.CommentServiceGrpc.CommentServiceImplBase;
import com.branches.comments.grpc.comments.Comments.Comment;
import com.branches.comments.grpc.comments.Comments.CommentVote;
import com.branches.comments.grpc.comments.Comments.CommentsRequest;
import com.branches.comments.service.CommentService;
import io.grpc.stub.StreamObserver;
import net.devh.boot.grpc.server.service.GrpcService;

import java.util.List;

@GrpcService
public class CommentGrpcService extends CommentServiceImplBase {

    private final CommentService commentService;

    public CommentGrpcService(CommentService commentService) {
        this.commentService = commentService;
    }

    @Override
    public void getCommentsByPostId(CommentsRequest request, StreamObserver<Comment> responseObserver) {
        List<CommentDTO> comments = commentService.getCommentsByPostId(request.getPostId());

        try {
            for (CommentDTO commentDTO : comments) {
                List<CommentVote> votes = commentDTO.votes().stream()
                        .map(v -> CommentVote.newBuilder()
                                .setId(v.id())
                                .setCommentId(v.commentId())
                                .setUserId(v.userId())
                                .setVoteType(v.voteType())
                                .build())
                        .toList();

                Comment grpcComment = Comment.newBuilder()
                        .setId(commentDTO.id())
                        .setPostId(commentDTO.postId())
                        .setUserId(commentDTO.userId())
                        .setContent(commentDTO.content())
                        .addAllVotes(votes)
                        .build();

                responseObserver.onNext(grpcComment);
            }
            responseObserver.onCompleted();
        } catch (Exception e) {
            responseObserver.onError(e);
        }
    }
}