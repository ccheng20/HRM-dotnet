﻿FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Recruiting/Recruitings.API/Recruitings.API.csproj", "Recruiting/Recruitings.API/"]
COPY ["Recruiting/ApplicationCore/ApplicationCore.csproj", "Recruiting/ApplicationCore/"]
COPY ["Recruiting/Infrastructures/Infrastructures.csproj", "Recruiting/Infrastructures/"]
RUN dotnet restore "Recruiting/Recruitings.API/Recruitings.API.csproj"
COPY . .
WORKDIR "/src/Recruiting/Recruitings.API"
RUN dotnet build "Recruitings.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Recruitings.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MSSQLConnectionString='Server=tcp:fullstackhrm.database.windows.net,1433;Initial Catalog=RecruitingDb;Persist Security Info=False;User ID=fullstack;Password=Yangwawa1010!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENV angularURL = 'http://localhost:4200'
ENTRYPOINT ["dotnet", "Recruitings.API.dll"]
