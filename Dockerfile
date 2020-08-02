FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster
WORKDIR /src
EXPOSE 5001

COPY jogovelha.csproj ./
RUN dotnet restore "jogovelha.csproj"

COPY . .
RUN ls

RUN dotnet build . -c Release -o /app/build

RUN dotnet add jogovelha.csproj package Microsoft.EntityFrameworkCore.InMemory

COPY . ./
RUN dotnet publish -c Release -o out
CMD ASPNETCORE_URLS=http://*:$PORT dotnet out/jogovelha.dll