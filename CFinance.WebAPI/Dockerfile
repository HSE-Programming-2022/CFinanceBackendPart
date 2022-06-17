FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY published/ ./
EXPOSE $PORT
ENTRYPOINT ["dotnet", "CFinance.WebAPI.dll"]
