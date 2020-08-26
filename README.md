# CleanClubs

net app to test and configure clean architecture with c#

## Docker Operations

run the following commands to create docker builds for each of the apps in question

### Emails

go to directory /src/Services/Emails/Emails.Api/
run command `docker build -t email-image -f Dockerfile .`

### Clubs

go to directory /src
run command `docker build -t clubs-image -f Dockerfile.Clubs .`
