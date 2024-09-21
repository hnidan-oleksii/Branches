package com.branches.reports;

import lombok.experimental.UtilityClass;

import static com.github.tomakehurst.wiremock.client.WireMock.*;

@UtilityClass
public class CommentsStubs {
    public void stubCommentsCall(Long postId, Long commentId) {
        stubFor(get(urlEqualTo("/api/posts/" + postId + "/comments/" + commentId))
                .willReturn(aResponse()
                        .withStatus(200)
                        .withHeader("Content-Type", "application/json")
                        .withBody("{\"commentId\":" + commentId + "}")));
    }
}