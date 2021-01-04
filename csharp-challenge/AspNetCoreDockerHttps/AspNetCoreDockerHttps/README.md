Make sure current working directory is the project not solution path

==Note: replace Pwd12345 with your password==
**Be sure to clean up certificates if not in use.**

1) **Create certificate for server**

`dotnet dev-certs https --clean`

`dotnet dev-certs https --trust -ep $USERPROFILE\\.aspnet\\https\\cert-aspnetcore.pfx -p Pwd12345`

2) **Build docker image** use -t option for different tag name

`docker build -f Dockerfile ..`

3) **Create container**

Problem using git bash: "C:/Program File/Git/" is added to path, solution need to go up two directories using ../../

`docker run --rm -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password=Pwd12345 -e ASPNETCORE_Kestrel__Certificates__Default__Path="../../root/.aspnet/https/cert-aspnetcore.pfx" -v $USERPROFILE\\.aspnet\\https\\:/root/.aspnet/https/ aspnetcoredockerhttps`

## Use docker compose to build image and run container

**This will replace step 2 and 3. Configure in docker-compose.yml file

`docker-compose up`

**stop and remove container**
`docker-compose down`

## List of common command
+ **list image** `docker images`

+ **list running container** `docker ps` \
option -a to list all container

+ **remove images** `docker rmi [image id]`

+ **remove container** `docker rm [container id]`

+ **build image from docker file and a context** `docker build` \
option -f to specify file
option -t to give a different tag name

+ **Create and run container** `docker run`
option -rm remove container when exit
option -p port mapping (container are isolated from host need to map)
option -e environment variable
option -v volume share files between host and container (we do not want to store secrets in images)

+ **Stop container** `docker stop [container id]`
+ **Start container** `docker start [container id]`
