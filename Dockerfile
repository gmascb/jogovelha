FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app

ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true
ENV PORT=44501
EXPOSE 44501

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY jogovelha.csproj ./
RUN dotnet restore "jogovelha.csproj"
COPY . .
RUN dotnet build . -c Release -o /app

FROM build as publish
RUN dotnet publish "jogovelha.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .


CMD ASPNETCORE_URLS=http://*:$PORT dotnet jogovelha.dll