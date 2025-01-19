# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Viola.Api/Viola.Api.csproj", "Viola.Api/"]
COPY ["Viola.Application/Viola.Application.csproj", "Viola.Application/"]
COPY ["Viola.Domain/Viola.Domain.csproj", "Viola.Domain/"]
COPY ["Viola.Persistance/Viola.Persistance.csproj", "Viola.Persistance/"]
COPY ["Viola.Infrastructure/Viola.Infrastructure.csproj", "Viola.Infrastructure/"]
RUN dotnet restore "./Viola.Api/Viola.Api.csproj"
COPY . .
WORKDIR "/src/Viola.Api"
RUN dotnet build "./Viola.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Viola.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Viola.Api.dll"]