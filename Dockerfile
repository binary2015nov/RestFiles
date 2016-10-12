FROM microsoft/dotnet:latest
COPY src /app
WORKDIR /app/RestFiles.ServiceModel
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
WORKDIR /app/RestFiles.ServiceInterface
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
WORKDIR /app/RestFiles
RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]
EXPOSE 5000/tcp
ENV ASPNETCORE_URLS https://*:5000
ENTRYPOINT ["dotnet", "run", "--server.urls", "http://*:5000"]