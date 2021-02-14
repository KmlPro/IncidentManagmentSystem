#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
LABEL authors="Kamil Bytner"
LABEL maintainer="Software Development Kamil Bytner"
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./*.sln", "./"]
COPY ["./*/*.csproj", "./"]

RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done

RUN dotnet restore "IncidentManagementSystem.sln"

RUN dotnet build "IncidentManagementSystem.sln" -c Release -o /app/build

FROM build AS test  
LABEL test=true  
RUN dotnet test "IncidentManagementSystem.sln" -c Release --results-directory /testresults --logger "trx;LogFileName=IncidentManagmentSystem_Tests.trx"

FROM build AS publish
RUN dotnet publish "IncidentManagmentSystem.Web/IncidentManagmentSystem.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IncidentManagmentSystem.Web.dll"]