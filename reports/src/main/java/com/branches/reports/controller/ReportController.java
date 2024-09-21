package com.branches.reports.controller;

import com.branches.reports.dto.CreateReportDTO;
import com.branches.reports.dto.ReportDTO;
import com.branches.reports.dto.UpdateReportDTO;
import com.branches.reports.service.ReportService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/reports")
public class ReportController {
    private final ReportService reportService;

    public ReportController(ReportService reportService) {
        this.reportService = reportService;
    }

    @GetMapping
    public ResponseEntity<List<ReportDTO>> getReports() {
        return ResponseEntity.ok(reportService.getAllReports());
    }

    @PostMapping
    public ResponseEntity<ReportDTO> report(@RequestBody CreateReportDTO dto) {
        return new ResponseEntity<>(reportService.report(dto), HttpStatus.CREATED);
    }

    @PutMapping("/{id}")
    public ResponseEntity<ReportDTO> updateReportStatus(@PathVariable Long id,
                                                        @RequestBody UpdateReportDTO dto) {
        return ResponseEntity.ok(reportService.updateReportStatus(id, dto));
    }
}
