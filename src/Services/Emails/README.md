## Docker Commands

Remove all docker containers: `docker rm -f $(docker ps -a -q)`
Remove all docker images: `docker rmi -f $(docker images)`

### Docker tests

To build: `docker build -t emailsapp .`
To run connected: `docker run -it --name myapp emailsapp`
to run disconnected: `docker run -d -p 8080:80 --name myapp emailsapp`
