package com.branches.comments.controller;

import com.branches.comments.dto.*;
import com.branches.comments.service.CommentService;
import com.branches.comments.service.CommentVoteService;
import lombok.RequiredArgsConstructor;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/comments")
@RequiredArgsConstructor
public class CommentController {

    private final CommentService commentService;
    private final CommentVoteService commentVoteService;

    @GetMapping("/{id}")
    public ResponseEntity<CommentDTO> getComment(@PathVariable Long id) {
        return ResponseEntity.ok(commentService.getCommentById(id));
    }

    @GetMapping("/posts/{postId}")
    public ResponseEntity<List<CommentDTO>> getCommentsByPost(@PathVariable Long postId) {
        List<CommentDTO> comments = commentService.getCommentsByPostId(postId);
        return ResponseEntity.ok(comments);
    }

    @PostMapping
    public ResponseEntity<CommentDTO> createComment(@RequestBody CreateCommentDTO dto) {
        CommentDTO createdComment = commentService.createComment(dto);
        return new ResponseEntity<>(createdComment, HttpStatus.CREATED);
    }

    @PutMapping("/{id}")
    public ResponseEntity<CommentDTO> updateComment(@PathVariable Long postId,
                                                    @PathVariable Long id,
                                                    @RequestBody UpdateCommentDTO dto) {
        CommentDTO updatedComment = commentService.updateComment(id, dto);
        return ResponseEntity.ok(updatedComment);
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteComment(@PathVariable Long postId,
                                              @PathVariable Long id) {
        commentService.deleteComment(id);
        return ResponseEntity.noContent().build();
    }

    @PostMapping("/{id}/upvote")
    public ResponseEntity<CommentVoteDTO> upvoteComment(@PathVariable Long postId,
                                                        @PathVariable Long id,
                                                        @RequestBody CreateCommentVoteDTO voteRequestDTO) {
        try {
            CommentVoteDTO response = commentVoteService.voteOnComment(id, voteRequestDTO);
            return new ResponseEntity<>(response, HttpStatus.CREATED);
        } catch (IllegalArgumentException e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @PostMapping("/{id}/downvote")
    public ResponseEntity<CommentVoteDTO> downvoteComment(@PathVariable Long postId,
                                                          @PathVariable Long id,
                                                          @RequestBody CreateCommentVoteDTO voteRequestDTO) {
        try {
            CommentVoteDTO response = commentVoteService.voteOnComment(id, voteRequestDTO);
            return new ResponseEntity<>(response, HttpStatus.CREATED);
        } catch (IllegalArgumentException e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }
}
