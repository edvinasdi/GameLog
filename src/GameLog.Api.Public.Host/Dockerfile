FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["GameLog.Public.Host/GameLog.Public.Host.csproj", "GameLog.Public.Host/"]
RUN dotnet restore "GameLog.Public.Host/GameLog.Public.Host.csproj"
COPY . .
WORKDIR "/src/GameLog.Public.Host"
RUN dotnet build "GameLog.Public.Host.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GameLog.Public.Host.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GameLog.Public.Host.dll"]
