FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Interview.API/", "Interviews/Interview.API/"]
COPY ["ApplicationCore/", "Interviews/ApplicationCore/"]
COPY ["Infrastructure/", "Interviews/Infrastructure/"]
RUN dotnet restore "Interviews/Interview.API/Interview.API.csproj"
WORKDIR "/src/Interviews/Interview.API"
RUN dotnet build "Interview.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Interview.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MySQLConnectionString='Server=tcp:fullstackhrm.database.windows.net,1433;Initial Catalog=InterviewDb;Persist Security Info=False;User ID=fullstack;Password=Yangwawa1010!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENTRYPOINT ["dotnet", "Interview.API.dll"]
