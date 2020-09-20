# CleanClubs

Testbed to configure a .net API following, as closely as one can, clean architecture guidelines with accompany web based projects for UI

### Current App Structure
All backend services can be found under src/Services
    - Attempting to split into context/domain bound microservices (slowly)
All Web/UI features can be found under /src/Web
    - Includes a Angular9 based web app currently

## Docker Operations

run the following commands to create docker builds for each of the apps in question

### Emails

go to directory /src/Services/Emails/Emails.Api/
run command `docker build -t email-image -f Dockerfile .`

### Clubs

go to directory /src
run command `docker build -t clubs-image -f Dockerfile.Clubs .`
