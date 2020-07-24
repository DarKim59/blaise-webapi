#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2016
#WORKDIR /inetpub/wwwroot
#COPY . .
#

FROM microsoft/dotnet-framework:4.7.2-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Blaise.Api/*.csproj ./blaiseAPI/
COPY Blaise.Api/*.config ./blaiseAPI/
COPY Blaise.Core/*.csproj ./blaiseAPI/
COPY Blaise.Core/*.config ./blaiseAPI/
RUN nuget restore

# copy everything else and build app
COPY . ./
WORKDIR /app/blaiseAPI
RUN msbuild /p:Configuration=Release

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2016 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build /app/blaiseAPI/. ./


