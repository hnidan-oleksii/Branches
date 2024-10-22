FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app

COPY ["csharp/Posts/.", "Posts/"]
COPY ["csharp/PostsBLL/.", "PostsBLL/"]
COPY ["csharp/PostsDAL_ADO/.", "PostsDAL_ADO/"]
COPY ["csharp/PostsDAL_EF/.", "PostsDAL_EF/"]
RUN dotnet restore "Posts/Posts.csproj"

COPY . .
ENV BUILD_CONFIGURATION=Development
RUN dotnet publish "Posts/Posts.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 5045
EXPOSE 44357
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Posts.dll"]
