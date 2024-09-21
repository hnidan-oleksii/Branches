package com.branches.comments;

import io.restassured.RestAssured;
import io.restassured.http.ContentType;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.web.server.LocalServerPort;
import org.springframework.boot.testcontainers.service.connection.ServiceConnection;
import org.springframework.context.annotation.Import;
import org.testcontainers.containers.PostgreSQLContainer;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.equalTo;
import static org.hamcrest.Matchers.notNullValue;

@Import(TestcontainersConfiguration.class)
@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
class CommentsApplicationTests {

	@ServiceConnection
	static PostgreSQLContainer<?> postgreSQLContainer = new PostgreSQLContainer<>("postgres:16.3");

	@LocalServerPort
	private Integer port;

	@BeforeEach
	void setUp() {
		RestAssured.baseURI = "http://localhost";
		RestAssured.port = port;
	}

	static {
		postgreSQLContainer.start();
	}

	@Test
	void shouldSubmitComment() {
		String submitCommentJson = """
            {
                "postId": 1,
                "userId": 1,
                "content": "This is a test comment."
            }
            """;

		given()
				.contentType(ContentType.JSON)
				.body(submitCommentJson)
				.when()
				.post("/api/posts/{postId}/comments", 1)
				.then()
				.statusCode(201)
				.body("id", notNullValue())
				.body("postId", equalTo(1))
				.body("userId", equalTo(1))
				.body("content", equalTo("This is a test comment."));
	}

	@Test
	void shouldVoteOnComment() {
		String submitCommentJson = """
            {
                "postId": 1,
                "userId": 1,
                "content": "This is a test comment."
            }
            """;

		int commentId =
				given()
						.contentType(ContentType.JSON)
						.body(submitCommentJson)
						.when()
						.post("/api/posts/{postId}/comments", 1)
						.then()
						.statusCode(201)
						.extract()
						.path("id");

		String voteOnCommentJson = """
            {
                "userId": 2,
                "voteType": 1
            }
            """;

		given()
				.contentType(ContentType.JSON)
				.body(voteOnCommentJson)
				.when()
				.post("/api/posts/{postId}/comments/{id}/upvote", 1, commentId)
				.then()
				.statusCode(201)
				.body("id", notNullValue())
				.body("commentId", equalTo(commentId))
				.body("userId", equalTo(2))
				.body("voteType", equalTo(1));
	}

	@Test
	void shouldNotAllowDuplicateVotes() {
		String submitCommentJson = """
            {
                "postId": 1,
                "userId": 1,
                "content": "This is another test comment."
            }
            """;

		int commentId =
				given()
						.contentType(ContentType.JSON)
						.body(submitCommentJson)
						.when()
						.post("/api/posts/{postId}/comments", 1)
						.then()
						.statusCode(201)
						.extract()
						.path("id");

		String voteOnCommentJson = """
            {
                "userId": 2,
                "voteType": 1
            }
            """;

		given()
				.contentType(ContentType.JSON)
				.body(voteOnCommentJson)
				.when()
				.post("/api/posts/{postId}/comments/{id}/upvote", 1, commentId)
				.then()
				.statusCode(201);

		given()
				.contentType(ContentType.JSON)
				.body(voteOnCommentJson)
				.when()
				.post("/api/posts/{postId}/comments/{id}/upvote", 1, commentId)
				.then()
				.statusCode(400);
	}
}
