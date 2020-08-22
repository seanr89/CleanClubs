FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app
COPY /Emails.Api/Emails.Api.csproj Emails.Api/
COPY /Emails.App/Emails.App.csproj Emails.App/
COPY /Emails.Domain/Emails.Domain.csproj Emails.Domain/

RUN dotnet restore Emails.Api/Emails.Api.csproj

COPY . .
RUN dotnet build Emails.Api/Emails.Api.csproj
#RUN dotnet publish -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "emails.api.dll"]