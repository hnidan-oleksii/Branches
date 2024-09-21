package com.branches.reports;

import org.springframework.boot.SpringApplication;

public class TestReportsApplication {

	public static void main(String[] args) {
		SpringApplication.from(ReportsApplication::main).with(TestcontainersConfiguration.class).run(args);
	}

}
