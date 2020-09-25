FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app

ARG BUILD_CONFIGURATION=Debug
ENV ASPNETCORE_ENVIRONMENT=Development
ENV DOTNET_USE_POLLING_FILE_WATCHER=true  
ENV ASPNETCORE_URLS=http://+:5001  
EXPOSE 5001

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


ENTRYPOINT [ "dotnet", "jogovelha.dll" ]
# CMD [ "dotnet", "jogovelha.dll" ]