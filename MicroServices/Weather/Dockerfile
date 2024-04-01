FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5052
EXPOSE 5552

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Weather/Weather.csproj", "Weather/"]
COPY ["Common/JwtConfiguration/JwtConfiguration.csproj", "Common/JwtConfiguration/"]
RUN dotnet restore "./Weather/Weather.csproj"

COPY . .
WORKDIR "/src/Weather"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.dll"]