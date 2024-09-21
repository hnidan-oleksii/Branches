package com.branches.reports.service;

import com.branches.reports.dto.CreateReportableDTO;
import com.branches.reports.entity.Reportable;
import com.branches.reports.repository.ReportableRepository;
import org.springframework.stereotype.Service;

import java.util.Optional;

@Service
public class ReportableService {

    private final ReportableRepository reportableRepository;

    public ReportableService(ReportableRepository reportableRepository) {
        this.reportableRepository = reportableRepository;
    }

    public Optional<Reportable> findByPostIdAndCommentId(Long postId, Long commentId) {
        return reportableRepository.findByPostIdAndCommentId(postId, commentId);
    }

    public Reportable saveReportable(CreateReportableDTO createDTO) {
        Reportable reportable = new Reportable();
        reportable.setPostId(createDTO.postId());
        reportable.setCommentId(createDTO.commentId());
        return reportableRepository.save(reportable);
    }
}
