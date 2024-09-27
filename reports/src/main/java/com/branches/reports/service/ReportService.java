package com.branches.reports.service;

import com.branches.reports.client.CommentsClient;
import com.branches.reports.dto.CreateReportDTO;
import com.branches.reports.dto.CreateReportableDTO;
import com.branches.reports.dto.ReportDTO;
import com.branches.reports.dto.UpdateReportDTO;
import com.branches.reports.entity.Report;
import com.branches.reports.entity.Reportable;
import com.branches.reports.repository.ReportRepository;
import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;
import java.util.stream.Collectors;

@RequiredArgsConstructor
@Service
public class ReportService {

    private final ReportRepository reportRepository;

    private final ReportableService reportableService;
    private final CommentsClient commentsClient;

    public List<ReportDTO> getAllReports() {
        return reportRepository.findAll().stream()
                .map(this::convertToReportDTO)
                .collect(Collectors.toList());
    }

    public ReportDTO report(CreateReportDTO dto) {
        if (dto.commentId() != null &&
                commentsClient.getComment(dto.commentId()) == null) {
            throw new IllegalArgumentException("Comment id don't exists");
        }
        // TODO Checking for post existence
        if (dto.postId() != null && false) {
            throw new IllegalArgumentException("Post id don't exists");
        }

        Optional<Reportable> existingReportable = reportableService.findByPostIdAndCommentId(dto.postId(), dto.commentId());
        if (existingReportable.isPresent()) {
            throw new IllegalArgumentException("Already reported");
        }

        Reportable reportable = reportableService.saveReportable(new CreateReportableDTO(dto.postId(), dto.commentId()));
        Report report = new Report();
        report.setReportedBy(dto.reportedBy());
        report.setReportable(reportable);
        report.setReason(dto.reason());

        return convertToReportDTO(reportRepository.save(report));
    }

    public ReportDTO getReportById(Long id) {
        Report report = reportRepository.findById(id).orElseThrow(() -> new IllegalArgumentException("Report not found"));
        return convertToReportDTO(report);
    }

    public ReportDTO updateReportStatus(Long id, UpdateReportDTO updateReportDTO) {
        Report report = reportRepository.findById(id)
                .orElseThrow(() -> new IllegalArgumentException("Report not found."));
        report.setStatus(updateReportDTO.status());
        Report updatedReport = reportRepository.save(report);
        return convertToReportDTO(updatedReport);
    }

    private ReportDTO convertToReportDTO(Report report) {
        return new ReportDTO(
                report.getId(),
                report.getReportedBy(),
                report.getReportable().getPostId(),
                report.getReportable().getCommentId(),
                report.getReason(),
                report.getStatus(),
                report.getCreatedAt()
        );
    }
}
