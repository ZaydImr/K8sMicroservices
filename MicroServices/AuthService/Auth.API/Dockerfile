FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5051
EXPOSE 5551

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY Auth.API/Auth.API.csproj ./Auth.API/
COPY Auth.Application/Auth.Application.csproj ./Auth.Application/
COPY Auth.Infrastructure/Auth.Infrastructure.csproj ./Auth.Infrastructure/
COPY Auth.Domain/Auth.Domain.csproj ./Auth.Domain/
RUN dotnet restore ./Auth.API/Auth.API.csproj

COPY . .
WORKDIR "/src/Auth.API"
RUN dotnet build -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.API.dll"]