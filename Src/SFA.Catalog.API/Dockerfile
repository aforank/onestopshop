#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SFA.Catalog.API/SFA.Catalog.API.csproj", "SFA.Catalog.API/"]
COPY ["../SFA.Catalog.Infrastructure/SFA.Catalog.Infrastructure.csproj", "../SFA.Catalog.Infrastructure/"]
RUN dotnet restore "SFA.Catalog.API/SFA.Catalog.API.csproj"
COPY . .
WORKDIR "/src/SFA.Catalog.API"
RUN dotnet build "SFA.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SFA.Catalog.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SFA.Catalog.API.dll"]