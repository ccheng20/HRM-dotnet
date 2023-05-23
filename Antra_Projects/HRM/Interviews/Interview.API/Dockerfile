FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Interviews/Interview.API/Interview.API.csproj", "Interviews/Interview.API/"]
COPY ["Interviews/ApplicationCore/ApplicationCore.csproj", "Interviews/ApplicationCore/"]
COPY ["Interviews/Infrastructure/Infrastructure.csproj", "Interviews/Infrastructure/"]
RUN dotnet restore "Interviews/Interview.API/Interview.API.csproj"
COPY . .
WORKDIR "/src/Interviews/Interview.API"
RUN dotnet build "Interview.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MySQLConnectionString='Server=tcp:fullstackhrm.database.windows.net,1433;Initial Catalog=InterviewDb;Persist Security Info=False;User ID=fullstack;Password=Yangwawa1010!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENTRYPOINT ["dotnet", "Interview.API.dll"]
