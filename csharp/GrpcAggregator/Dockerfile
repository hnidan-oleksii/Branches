FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app

COPY ["csharp/GrpcAggregator/.", "GrpcAggregator/"]
RUN dotnet restore "GrpcAggregator/GrpcAggregator.csproj"

COPY . .
ENV BUILD_CONFIGURATION=Development
RUN dotnet publish "GrpcAggregator/GrpcAggregator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 5112
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GrpcAggregator.dll"]
