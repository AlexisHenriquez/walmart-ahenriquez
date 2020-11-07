#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
COPY ["walmart-ahenriquez.Web/appSettings.json", "."]
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["walmart-ahenriquez.Web/walmart-ahenriquez.Web.csproj", "walmart-ahenriquez.Web/"]
COPY ["walmart-ahenriquez.Domain/walmart-ahenriquez.Domain.csproj", "walmart-ahenriquez.Domain/"]
COPY ["walmart-ahenriquez.Dto/walmart-ahenriquez.Dto.csproj", "walmart-ahenriquez.Dto/"]
COPY ["walmart-ahenriquez.Infrastructure/walmart-ahenriquez.Infrastructure.csproj", "walmart-ahenriquez.Infrastructure/"]
COPY ["walmart-ahenriquez.Application/walmart-ahenriquez.Application.csproj", "walmart-ahenriquez.Application/"]
RUN dotnet restore "walmart-ahenriquez.Web/walmart-ahenriquez.Web.csproj"

WORKDIR "/src/walmart-ahenriquez.Domain"
COPY ./walmart-ahenriquez.Domain .

WORKDIR "/src/walmart-ahenriquez.Dto"
COPY ./walmart-ahenriquez.Dto .

WORKDIR "/src/walmart-ahenriquez.Infrastructure"
COPY ./walmart-ahenriquez.Infrastructure .

WORKDIR "/src/walmart-ahenriquez.Application"
COPY ./walmart-ahenriquez.Application .

WORKDIR "/src/walmart-ahenriquez.Web"
COPY ./walmart-ahenriquez.Web .

RUN dotnet build "walmart-ahenriquez.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "walmart-ahenriquez.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet walmart-ahenriquez.Web.dll