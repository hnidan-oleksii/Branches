package com.branches.reports.dto;

public record CreateReportDTO(Long reportedBy, Long postId, Long commentId, String reason) {
}
