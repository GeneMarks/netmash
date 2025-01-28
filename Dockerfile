FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev-env

WORKDIR /app

COPY ./src/Netmash.Shared ./Netmash.Shared
COPY ./src/Netmash.Server ./Netmash.Server
COPY ./src/Netmash.Editor ./Netmash.Editor

WORKDIR /app/Netmash.Server
RUN dotnet restore

WORKDIR /app/Netmash.Editor
RUN dotnet restore

EXPOSE 5000

WORKDIR /app/Netmash.Server
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]
