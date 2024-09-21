package com.branches.reports.entity;

import jakarta.persistence.*;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

@Data
@NoArgsConstructor
@AllArgsConstructor
@Entity
@Table(name = "reportables")
public class Reportable {

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(name = "post_id")
    private Long postId;

    @Column(name = "comment_id")
    private Long commentId;

    @PrePersist
    @PreUpdate
    public void validatePostOrComment() {
        if ((postId == null && commentId == null) || (postId != null && commentId != null)) {
            throw new IllegalArgumentException("Either postId or commentId must be set, not both.");
        }
    }
}
