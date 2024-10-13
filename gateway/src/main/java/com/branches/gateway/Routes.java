package com.branches.gateway;

import static org.springframework.cloud.gateway.server.mvc.handler.GatewayRouterFunctions.route;
import static org.springframework.cloud.gateway.server.mvc.handler.HandlerFunctions.http;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.web.servlet.function.RequestPredicates;
import org.springframework.web.servlet.function.RouterFunction;
import org.springframework.web.servlet.function.ServerResponse;

@Configuration(proxyBeanMethods = false)
public class Routes {

	@Bean
	public RouterFunction<ServerResponse> commentsRoute() {
		return route("comments")
			.route(RequestPredicates.path("/api/comments")
				.or(RequestPredicates.path("/api/comments/{id}"))
				.or(RequestPredicates.path("/api/comments/posts/{id}")),
				http(System.getenv("COMMENTS_URL")))
			.build();
	}


	@Bean
	public RouterFunction<ServerResponse> reportsRoute() {
		return route("reports")
			.route(RequestPredicates.path("/api/reports")
				.or(RequestPredicates.path("/api/reports/{id}")),
				http(System.getenv("REPORTS_URL")))
			.build();
	}
}
