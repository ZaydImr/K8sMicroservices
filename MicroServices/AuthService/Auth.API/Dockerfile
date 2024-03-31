FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5051
EXPOSE 5551

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY AuthService/Auth.API/Auth.API.csproj ./AuthService/Auth.API/
COPY AuthService/Auth.Application/Auth.Application.csproj ./AuthService/Auth.Application/
COPY AuthService/Auth.Infrastructure/Auth.Infrastructure.csproj ./AuthService/Auth.Infrastructure/
COPY AuthService/Auth.Domain/Auth.Domain.csproj ./AuthService/Auth.Domain/
COPY Common/JwtConfiguration/JwtConfiguration.csproj ./Common/JwtConfiguration/
RUN dotnet restore ./AuthService/Auth.API/Auth.API.csproj

COPY . .
WORKDIR "/src/AuthService/Auth.API"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.API.dll"]