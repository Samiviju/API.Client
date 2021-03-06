#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ClientsAPI/ClientsAPI.csproj", "ClientsAPI/"]
COPY ["ClientsAPI.Util/ClientsAPI.Util.csproj", "ClientsAPI.Util/"]
RUN dotnet restore "ClientsAPI/ClientsAPI.csproj"
COPY . .
WORKDIR "/src/ClientsAPI"
RUN dotnet build "ClientsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ClientsAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ClientsAPI.dll"]