#### Using docker from commandline

**Note: replace Pwd12345 with your password**
**Using git bash terminal**

**Create cert**
```dotnet dev-certs https --clean```
```dotnet dev-certs https --trust -ep $USERPROFILE\\.aspnet\\https\\cert-aspnetcore.pfx -p Pwd12345```


**Build docker image**
**use -t option for tag name**
```docker build -f Dockerfile ..```

**Create container**
**Problem using git bash: "C:/Program File/Git/" is added to path, need to go up two directories**
```docker run --rm -p 8000:80 -p 8001:443 -e ASPNETCORE_URLS="https://+;http://+" -e ASPNETCORE_HTTPS_PORT=8001 -e ASPNETCORE_Kestrel__Certificates__Default__Password=Pwd12345 -e ASPNETCORE_Kestrel__Certificates__Default__Path="../../root/.aspnet/https/cert-aspnetcore.pfx" -v $USERPROFILE\\.aspnet\\https\\:/root/.aspnet/https/ aspnetcoredockerhttps```


**Be sure to clean up certificates if not in use.**