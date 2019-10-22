# Deploy ASP.NET MVC App

To Internet Information Services or Microsoft Azure

## Install IIS

Open Control Panel > Programs > Programs and Features > Turn Windows features on or off
Expand Internet Information Services -> World Wide Web Services -> Application Development Features
Select ASP.NET 4.7
Select IIS Management Console
Click ok
**Setup website**
Open IIS Manager
right click and select Add Website
Type in site name, set physical path, click ok

## Publish to IIS

In solution explorer, right click project and click publish
Select folder as publish target
Click Create profile
Click Edit profile:
1. Connection tab
    - publish method: File system
    - target location: bin\Release\Publish
2. Settings tab
    - File publish options: check Delete all existing files prior to publish and Precompile during publishing

Click save
Click publish

Copy files from bin\Release\Publish into website physical path
You can now browse to your website

**To use different database for production**
Edit profile
1. Connection tab
    - publish method: web deploy
    - fill in Server, Site name, and Destination URL
2. Settings tab
    - Enter connection string for ApplicationDbContext (defaultConnection)
SQL Server 2017 connection string
`Data Source=TheServer\SQL2017;Initial Catalog=TutorialDB;Persist Security Info=True;User ID=username;Password=mypassword`

## Deploy to Azure
In solution explorer, right click project and click publish
Create new Azure App Service
Publish
