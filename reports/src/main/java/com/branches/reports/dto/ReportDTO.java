package com.branches.reports.dto;

import java.time.LocalDateTime;

public record ReportDTO(Long id, Long reportedBy, Long postId, Long commentId, String reason, String status, LocalDateTime createdAt) {
}
