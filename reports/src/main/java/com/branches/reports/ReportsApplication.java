package com.branches.reports;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.cloud.openfeign.EnableFeignClients;

@EnableFeignClients
@SpringBootApplication
public class ReportsApplication {

	public static void main(String[] args) {
		SpringApplication.run(ReportsApplication.class, args);
	}

}
