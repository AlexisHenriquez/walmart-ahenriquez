#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["walmart-ahenriquez.Web/walmart-ahenriquez.Web.csproj", "walmart-ahenriquez.Web/"]
COPY ["walmart-ahenriquez.Domain/walmart-ahenriquez.Domain.csproj", "walmart-ahenriquez.Domain/"]
COPY ["walmart-ahenriquez.Dto/walmart-ahenriquez.Dto.csproj", "walmart-ahenriquez.Dto/"]
COPY ["walmart-ahenriquez.Infrastructure/walmart-ahenriquez.Infrastructure.csproj", "walmart-ahenriquez.Infrastructure/"]
#COPY ["walmart-ahenriquez.Application/walmart-ahenriquez.Application.csproj", "walmart-ahenriquez.Application/"]
RUN dotnet restore "walmart-ahenriquez.Web/walmart-ahenriquez.Web.csproj"

WORKDIR "/src/walmart-ahenriquez.Web"
COPY ./walmart-ahenriquez .

RUN dotnet build "walmart-ahenriquez.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "walmart-ahenriquez.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "walmart-ahenriquez/walmart-ahenriquez.Web.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet walmart-ahenriquez.Web.dll