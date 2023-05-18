FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Interview/Interview.API/Interview.API.csproj", "Interview/Interview.API/"]
COPY ["Interview/Infrastructure/Infrastructure.csproj", "Interview/Infrastructure/"]
COPY ["Recruiting/ApplicationCore/ApplicationCore.csproj", "Recruiting/ApplicationCore/"]
COPY ["Interview/ApplicationCore/ApplicationCore.csproj", "Interview/ApplicationCore/"]
RUN dotnet restore "Interview/Interview.API/Interview.API.csproj"
COPY . .
WORKDIR "/src/Interview/Interview.API"
RUN dotnet build "Interview.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interview.API.dll"]
