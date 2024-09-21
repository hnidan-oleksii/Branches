package com.branches.reports.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.time.LocalDateTime;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "reports")
public class Report {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false)
    private Long reportedBy;

    @ManyToOne
    @JoinColumn(name = "reportable_id", nullable = false)
    private Reportable reportable;

    @Column(nullable = false)
    private String reason;

    @Column(nullable = false)
    private String status = "open";

    @Column(nullable = false)
    private LocalDateTime createdAt = LocalDateTime.now();
}
