FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY *.csproj ./
COPY "src/Services/Emails/Emails.Api/Emails.Api.csproj" "./"
RUN dotnet restore

COPY . ./
RUN dotnet build
