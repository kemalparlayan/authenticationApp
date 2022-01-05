FROM mcr.microsoft.com/dotnet/core/aspnet
WORKDIR /App
COPY publish /App
ENTRYPOINT ["dotnet", "authenticationApp.dll"]