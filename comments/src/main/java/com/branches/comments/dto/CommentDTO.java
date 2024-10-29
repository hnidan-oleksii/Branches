package com.branches.comments.dto;

import java.time.LocalDateTime;
import java.util.List;

public record CommentDTO(Long id, Long postId, Long userId, String content, LocalDateTime createdAt,
                         List<CommentVoteDTO> votes) {
}
