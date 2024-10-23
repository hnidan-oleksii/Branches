FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app

COPY ["csharp/HttpAggregator/.", "HttpAggregator/"]
RUN dotnet restore "HttpAggregator/HttpAggregator.csproj"

COPY . .
ENV BUILD_CONFIGURATION=Development
RUN dotnet publish "HttpAggregator/HttpAggregator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 5036
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HttpAggregator.dll"]
