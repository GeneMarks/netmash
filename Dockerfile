FROM mcr.microsoft.com/dotnet/sdk:8.0 AS dev-env

WORKDIR /app

COPY ./src/Mishmash.Shared ./Mishmash.Shared
COPY ./src/Mishmash.Server ./Mishmash.Server
COPY ./src/Mishmash.Editor ./Mishmash.Editor

WORKDIR /app/Mishmash.Server
RUN dotnet restore

WORKDIR /app/Mishmash.Editor
RUN dotnet restore

EXPOSE 5000

WORKDIR /app/Mishmash.Server
CMD ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]
