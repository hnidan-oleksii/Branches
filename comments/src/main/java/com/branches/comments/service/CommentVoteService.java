package com.branches.comments.service;

import com.branches.comments.dto.CommentVoteDTO;
import com.branches.comments.dto.CreateCommentVoteDTO;
import com.branches.comments.entity.Comment;
import com.branches.comments.entity.CommentVote;
import com.branches.comments.repository.CommentRepository;
import com.branches.comments.repository.CommentVoteRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
@RequiredArgsConstructor
public class CommentVoteService {

    private final CommentVoteRepository commentVoteRepository;
    private final CommentRepository commentRepository;

    public CommentVoteDTO voteOnComment(Long commentId, CreateCommentVoteDTO voteRequestDTO) {
        Comment comment = commentRepository.findById(commentId)
                .orElseThrow(() -> new IllegalArgumentException("Comment not found"));

        Optional<CommentVote> existingVote = commentVoteRepository.findByCommentIdAndUserId(commentId, voteRequestDTO.userId());
        if (existingVote.isPresent()) {
            throw new IllegalArgumentException("User has already voted on this comment");
        }

        CommentVote vote = new CommentVote();
        vote.setComment(comment);
        vote.setUserId(voteRequestDTO.userId());
        vote.setVoteType(voteRequestDTO.voteType());

        CommentVote savedVote = commentVoteRepository.save(vote);

        return new CommentVoteDTO(savedVote.getId(), commentId, savedVote.getUserId(), savedVote.getVoteType(), savedVote.getVotedAt());
    }
}
