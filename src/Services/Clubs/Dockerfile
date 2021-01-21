FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
EXPOSE 80
EXPOSE 443

WORKDIR /app
COPY /Clubs.API/Clubs.API.csproj Clubs.API/
COPY /Clubs.App/Clubs.App.csproj Clubs.App/
COPY /Clubs.Domain/Clubs.Domain.csproj Clubs.Domain/
COPY /Clubs.Infrastructure/Clubs.Infrastructure.csproj Clubs.Infrastructure/
COPY /Clubs.Messages/Clubs.Messages.csproj Clubs.Messages/

RUN dotnet restore Clubs.API/Clubs.API.csproj

COPY . .
RUN dotnet build Clubs.API/Clubs.API.csproj
#RUN dotnet publish -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app .
ENTRYPOINT ["dotnet", "Clubs.api.dll"]