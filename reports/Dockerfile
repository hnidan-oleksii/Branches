FROM maven:3.9.9-amazoncorretto-17 AS build
WORKDIR /app
COPY pom.xml .
COPY src ./src
RUN mvn clean package -DskipTests

FROM amazoncorretto:17
WORKDIR /app
COPY --from=build ./app/target/reports-0.0.1.jar .
CMD ["java", "-jar", "reports-0.0.1.jar"]
