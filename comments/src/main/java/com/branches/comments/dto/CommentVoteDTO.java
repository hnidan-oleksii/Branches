package com.branches.comments.dto;

import java.time.LocalDateTime;

public record CommentVoteDTO(Long id, Long commentId, Long userId, Short voteType, LocalDateTime votedAt) {
}
