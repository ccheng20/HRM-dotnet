FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Onboarding.API/", "Onboarding/Onboarding.API/"]
COPY ["ApplicationCore/", "Onboarding/ApplicationCore/"]
COPY ["Infrastructure/", "Onboarding/Infrastructure/"]
RUN dotnet restore "Onboarding/Onboarding.API/Onboarding.API.csproj"
WORKDIR "/src/Onboarding/Onboarding.API"
RUN dotnet build "Onboarding.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboarding.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV MySQLConnectionString='Server=tcp:fullstackhrm.database.windows.net,1433;Initial Catalog=OnboardingDb;Persist Security Info=False;User ID=fullstack;Password=Yangwawa1010!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;'
ENTRYPOINT ["dotnet", "Onboarding.API.dll"]
