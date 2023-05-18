FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Onboarding/Onboarding.API/Onboarding.API.csproj", "Onboarding/Onboarding.API/"]
COPY ["Onboarding/Infrastructure/Infrastructure.csproj", "Onboarding/Infrastructure/"]
COPY ["Onboarding/ApplicationCore/ApplicationCore.csproj", "Onboarding/ApplicationCore/"]
RUN dotnet restore "Onboarding/Onboarding.API/Onboarding.API.csproj"
COPY . .
WORKDIR "/src/Onboarding/Onboarding.API"
RUN dotnet build "Onboarding.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboarding.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboarding.API.dll"]
