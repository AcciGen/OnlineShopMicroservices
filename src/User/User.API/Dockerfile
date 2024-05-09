#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/User/User.API/User.API.csproj", "src/User/User.API/"]
COPY ["src/User/User.Application/User.Application.csproj", "src/User/User.Application/"]
COPY ["src/User/User.Domain/User.Domain.csproj", "src/User/User.Domain/"]
COPY ["src/User/User.Infrastructure/User.Infrastructure.csproj", "src/User/User.Infrastructure/"]
RUN dotnet restore "./src/User/User.API/User.API.csproj"
COPY . .
WORKDIR "/src/src/User/User.API"
RUN dotnet build "./User.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./User.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.API.dll"]