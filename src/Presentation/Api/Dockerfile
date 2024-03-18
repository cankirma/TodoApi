#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Presentation/Api/Api.csproj", "src/Presentation/Api/"]
COPY ["src/Todo/Core/Application/Application.csproj", "src/Todo/Core/Application/"]
COPY ["src/Todo/Core/Domain/Domain.csproj", "src/Todo/Core/Domain/"]
COPY ["src/Todo/Infrastructure/Persistence/Persistence.csproj", "src/Todo/Infrastructure/Persistence/"]
RUN dotnet restore "./src/Presentation/Api/Api.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Api"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]