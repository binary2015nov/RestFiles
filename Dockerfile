FROM microsoft/dotnet:2.0-sdk
COPY src /app
WORKDIR /app
RUN ["dotnet", "restore", "--configfile", "/app/NuGet.Config"]
WORKDIR /app/RestFiles
RUN ["dotnet", "build"]
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS https://*:5000
ENTRYPOINT ["dotnet", "run", "--server.urls", "http://*:5000"]