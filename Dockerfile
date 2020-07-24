#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2016 AS build
WORKDIR /inetpub/wwwroot
COPY . .
RUN DIR
RUN cmd /c DIR


#FROM microsoft/dotnet-framework:4.7.2-sdk AS build
#WORKDIR /app
#
## copy csproj and restore as distinct layers
#COPY . ./
#RUN nuget restore
#
#RUN msbuild /p:Configuration=Release
#
#FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8-windowsservercore-ltsc2016 AS runtime
#WORKDIR /inetpub/wwwroot
#COPY --from=build /app/. ./
#

