#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/framework/runtime:windows-server-1909-dc-core-uefi-gke-v1585613264
WORKDIR /inetpub/wwwroot
COPY . .


