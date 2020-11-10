# CleanClubs

Testbed to configure a .net API following, as closely as one can, clean architecture guidelines with accompany web based projects for UI

## Installation and Running

### Web App

Angular web app using npm/yarn and the angular cli

- navigate to the following `cd src/Web/WebApp`
- to run please execute the following commands
  - `npm install` or `yarn install`
  - `ng build`
  - `ng serve`

### API
These steps are only required currently for the Clubs API but further API's will be similar

- navigate to the following `cd src/Services/Clubs/Clubs.API`
  - ensure that you have the latest version of netcore3 installed, preferrably netcore3.1.4+
- to run please execute the following commands
  - `dotnet clean`
  - `dotnet restore`
- The API also includes a vscode debug profile which supports running with F5
- N.B. DB connection is defaulted to the Azure DB for staging/production development

### Current App Structure

All backend services can be found under src/Services - Attempting to split into context/domain bound microservices (slowly)
All Web/UI features can be found under /src/Web - Includes a Angular9 based web app currently

## Docker Operations

run the following commands to create docker builds for each of the apps in question

### Emails

go to directory /src/Services/Emails/Emails.Api/
run command `docker build -t email-image -f Dockerfile .`

### Clubs

go to directory /src
run command `docker build -t clubs-image -f Dockerfile.Clubs .`
