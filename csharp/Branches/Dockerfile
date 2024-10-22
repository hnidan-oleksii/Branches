FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app

COPY ["csharp/Branches/.", "Branches/"]
COPY ["csharp/Branches_BLL/.", "Branches_BLL/"]
COPY ["csharp/Branches_DAL/.", "Branches_DAL/"]
RUN dotnet restore "Branches/Branches.csproj"

COPY . .
ENV BUILD_CONFIGURATION=Development
RUN dotnet publish "Branches/Branches.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
EXPOSE 5123
EXPOSE 44328
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Branches.dll"]
