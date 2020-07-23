ARG SourceDirectory

FROM mcr.microsoft.com/windows/servercore:1809 AS build
WORKDIR /src

RUN Install-WindowsFeature -name Web-Server -IncludeManagementTools.

COPY SourceDirectory/ .
RUN DIR



ENTRYPOINT ["dotnet", "Blaise.Api.dll"]




