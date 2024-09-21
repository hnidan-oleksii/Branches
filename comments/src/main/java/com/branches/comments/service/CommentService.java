package com.branches.comments.service;

import com.branches.comments.dto.CommentDTO;
import com.branches.comments.dto.CreateCommentDTO;
import com.branches.comments.dto.UpdateCommentDTO;
import com.branches.comments.entity.Comment;
import com.branches.comments.repository.CommentRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

@Service
@RequiredArgsConstructor
public class CommentService {

    private final CommentRepository commentRepository;

    public CommentDTO getCommentById(Long id) {
        Comment comment = commentRepository.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("Comment not found"));
        return mapToCommentDTO(comment);
    }

    public List<CommentDTO> getCommentsByPostId(Long postId) {
        return commentRepository.findByPostId(postId).stream()
                .map(this::mapToCommentDTO)
                .collect(Collectors.toList());
    }

    public CommentDTO createComment(CreateCommentDTO dto) {
        Comment comment = commentRepository.save(mapCreateDTOToComment(dto));
        return mapToCommentDTO(comment);
    }

    public CommentDTO updateComment(Long commentId, UpdateCommentDTO dto) {
        Comment comment = commentRepository.findById(commentId).orElseThrow();
        comment.setContent(dto.content());
        return mapToCommentDTO(commentRepository.save(comment));
    }

    public void deleteComment(Long commentId) {
        commentRepository.deleteById(commentId);
    }

    private CommentDTO mapToCommentDTO(Comment comment) {
        return new CommentDTO(comment.getId(), comment.getPostId(), comment.getUserId(), comment.getContent(), comment.getCreatedAt());
    }

    private Comment mapCreateDTOToComment(CreateCommentDTO commentDTO) {
        Comment comment = new Comment();
        comment.setPostId(commentDTO.postId());
        comment.setUserId(commentDTO.userId());
        comment.setContent(commentDTO.content());
        return comment;
    }
}
