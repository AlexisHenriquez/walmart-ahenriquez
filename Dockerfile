#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["walmart-ahenriquez.csproj", "walmart-ahenriquez/"]
RUN dotnet restore "walmart-ahenriquez/walmart-ahenriquez.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "walmart-ahenriquez/walmart-ahenriquez.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "walmart-ahenriquez/walmart-ahenriquez.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "walmart-ahenriquez/walmart-ahenriquez.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet walmart-ahenriquez/walmart-ahenriquez.dll