FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app

COPY ["csharp/WallsApi/.", "WallsApi/"]
COPY ["csharp/WallsApplication/.", "WallsApplication/"]
COPY ["csharp/WallsDomain/.", "WallsDomain/"]
COPY ["csharp/WallsInfrastructure/.", "WallsInfrastructure/"]
RUN dotnet restore "WallsApi/WallsApi.csproj"

COPY . .
ENV BUILD_CONFIGURATION=Development
RUN dotnet publish "WallsApi/WallsApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 5219
EXPOSE 15443
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WallsApi.dll"]
