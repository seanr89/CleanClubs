FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
# EXPOSE 80
# EXPOSE 443

WORKDIR /app
COPY /Emails.Api/Emails.Api.csproj Emails.Api/
COPY /Emails.App/Emails.App.csproj Emails.App/
COPY /Emails.Domain/Emails.Domain.csproj Emails.Domain/

RUN dotnet restore Emails.Api/Emails.Api.csproj

COPY . .
#RUN dotnet build Emails.Api/Emails.Api.csproj
RUN dotnet publish Emails.Api/Emails.Api.csproj -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Emails.Api.dll"]