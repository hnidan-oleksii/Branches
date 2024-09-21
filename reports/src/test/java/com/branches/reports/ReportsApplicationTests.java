package com.branches.reports;

import io.restassured.RestAssured;
import io.restassured.http.ContentType;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.web.server.LocalServerPort;
import org.springframework.boot.testcontainers.service.connection.ServiceConnection;
import org.springframework.cloud.contract.wiremock.AutoConfigureWireMock;
import org.springframework.context.annotation.Import;
import org.springframework.jdbc.core.JdbcTemplate;
import org.testcontainers.containers.PostgreSQLContainer;

import static io.restassured.RestAssured.given;
import static org.hamcrest.Matchers.equalTo;
import static org.hamcrest.Matchers.notNullValue;

@Import(TestcontainersConfiguration.class)
@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
@AutoConfigureWireMock
class ReportsApplicationTests {

    @ServiceConnection
    static PostgreSQLContainer<?> postgreSQLContainer = new PostgreSQLContainer<>("postgres:16.3");

    @LocalServerPort
    private Integer port;

    @BeforeEach
    void setUp(@Autowired JdbcTemplate jdbcTemplate) {
        RestAssured.baseURI = "http://localhost";
        RestAssured.port = port;

        jdbcTemplate.execute("TRUNCATE TABLE comments CASCADE");
        jdbcTemplate.execute("TRUNCATE TABLE posts CASCADE");
        jdbcTemplate.execute("INSERT INTO posts (id, title, content) VALUES (1, 'Test Post', 'This is a test post')");
        jdbcTemplate.execute("INSERT INTO comments (id, content) VALUES (5, 'This is a sample comment')");
    }

    static {
        postgreSQLContainer.start();
    }

    @Test
    void shouldReportPost() {
        String createReportJson = """
                {
                    "reportedBy": 1,
                    "reason": "Spam content",
                    "postId": 1,
                    "commentId": null
                }
                """;

        given()
                .contentType(ContentType.JSON)
                .body(createReportJson)
                .when()
                .post("/api/reports")
                .then()
                .statusCode(201)
                .body("id", notNullValue())
                .body("reportedBy", equalTo(1))
                .body("reason", equalTo("Spam content"))
                .body("postId", equalTo(1))
                .body("commentId", equalTo(null));
    }

    @Test
    void shouldReportComment() {
        String createReportJson = """
                {
                    "reportedBy": 2,
                    "reason": "Offensive language",
                    "postId": null,
                    "commentId": 5
                }
                """;

        given()
                .contentType(ContentType.JSON)
                .body(createReportJson)
                .when()
                .post("/api/reports")
                .then()
                .statusCode(201)
                .body("id", notNullValue())
                .body("reportedBy", equalTo(2))
                .body("reason", equalTo("Offensive language"))
                .body("postId", equalTo(null))
                .body("commentId", equalTo(5));
    }

    @Test
    void shouldNotAllowDuplicateReports() {
        String createReportJson = """
                {
                    "reportedBy": 1,
                    "reason": "Inappropriate content",
                    "postId": 1,
                    "commentId": null
                }
                """;

        given()
                .contentType(ContentType.JSON)
                .body(createReportJson)
                .when()
                .post("/api/reports")
                .then()
                .statusCode(201);

        given()
                .contentType(ContentType.JSON)
                .body(createReportJson)
                .when()
                .post("/api/reports")
                .then()
                .statusCode(400);
    }

    @Test
    void shouldUpdateReportStatus() {
        String createReportJson = """
                {
                    "reportedBy": 3,
                    "reason": "Misleading information",
                    "postId": 1,
                    "commentId": null
                }
                """;

        int reportId = given()
                .contentType(ContentType.JSON)
                .body(createReportJson)
                .when()
                .post("/api/reports")
                .then()
                .statusCode(201)
                .extract()
                .path("id");

        String updateStatusJson = """
                {
                    "status": "under_review"
                }
                """;

        given()
                .contentType(ContentType.JSON)
                .body(updateStatusJson)
                .when()
                .put("/api/reports/" + reportId)
                .then()
                .statusCode(200)
                .body("id", equalTo(reportId))
                .body("status", equalTo("under_review"));
    }
}
