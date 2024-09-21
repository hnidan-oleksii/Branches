package com.branches.reports.client;

import org.springframework.cloud.openfeign.FeignClient;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;

@FeignClient(value = "comment", url = "${comments.url")
public interface CommentsClient {
    @GetMapping("/api/posts/{postId}/comments/{commentId}")
    ResponseEntity<Object> getComment(@PathVariable Long postId,
                                      @PathVariable Long commentId);
}