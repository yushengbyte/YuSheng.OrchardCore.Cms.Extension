# YuSheng.OrchardCore.Media.Tencent

Tencent cloud cos orchardcore plugin

[![NuGet](https://img.shields.io/nuget/v/YuSheng.OrchardCore.Media.Tencent.svg)](https://www.nuget.org/packages/YuSheng.OrchardCore.Media.Tencent)

## Install Nuget
```
dotnet add package YuSheng.OrchardCore.Media.Tencent --version 0.0.2
```
## appsettings.json config demo

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "OrchardCore": {
    "OrchardCore.Media.Tencent": {
      "BucketName": "xxx-xxx",
      "BasePath": "xxxxxx", //the folder in the bucket,must contains '/', like 'myphoto/'
      "Appid": "xxxx", // tencent cloud appid
      "IsHttps": false,
      "Region": "xxxx", // tencent cloud bucket region
      "IsSetDebugLog": false,
      "SecretId": "xxxx", // tecent cloud secreId
      "SecretKey": "xxxx" // tencent cloud secreKey
    }
  }
}
```

## Init tencnet cos folder
Creat a new txt file named 'OrchardCore.Media.txt',then upload OrchardCore.Media.txt to the basepath folder(the tencent cos folder you set in appsettings.json),now you can see the folder in cms media library when you enable this plugin.

