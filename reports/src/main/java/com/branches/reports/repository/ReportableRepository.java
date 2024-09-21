package com.branches.reports.repository;

import com.branches.reports.entity.Reportable;
import org.springframework.data.jpa.repository.JpaRepository;

import java.util.Optional;

public interface ReportableRepository extends JpaRepository<Reportable, Long> {
    Optional<Reportable> findByPostIdAndCommentId(Long postId, Long commentId);
}
