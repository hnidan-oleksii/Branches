package com.branches.comments.dto;

public record CreateCommentDTO(Long postId, Long userId, String content) {
}
