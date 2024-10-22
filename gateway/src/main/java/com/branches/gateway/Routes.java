package com.branches.gateway;

import static org.springframework.cloud.gateway.server.mvc.filter.FilterFunctions.setPath;
import static org.springframework.cloud.gateway.server.mvc.handler.GatewayRouterFunctions.route;
import static org.springframework.cloud.gateway.server.mvc.handler.HandlerFunctions.http;

import org.springframework.cloud.gateway.server.mvc.handler.GatewayRouterFunctions;
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

	@Bean
	public RouterFunction<ServerResponse> commentsSwaggerRoute() {
		return GatewayRouterFunctions.route("comments_swagger")
			.route(RequestPredicates.path("/aggregate/comments.api/v3/api-docs"),
				http(System.getenv("COMMENTS_URL")))
			.filter(setPath("/api-docs"))
			.build();
	}


	@Bean
	public RouterFunction<ServerResponse> reportsSwaggerRoute() {
		return GatewayRouterFunctions.route("comments_swagger")
			.route(RequestPredicates.path("/aggregate/reports.api/v3/api-docs"),
				http(System.getenv("REPORTS_URL")))
			.filter(setPath("/api-docs"))
			.build();
	}
}
