# syntax=docker/dockerfile:1.2

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Users.API/Users.API.csproj", "Users.API/"]
RUN --mount=type=secret,id=read_nuget_pat \
    dotnet nuget add source --username Lothyriel --password $(cat /run/secrets/read_nuget_pat) --store-password-in-clear-text --name github "https://nuget.pkg.github.com/InfoInvest/index.json"
RUN dotnet restore "Users.API/Users.API.csproj"

COPY . .
WORKDIR "/src/Users.API"
RUN dotnet build "Users.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Users.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Users.API.dll"]