#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM 172.20.20.9:1112/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM 172.20.20.9:1112/sdk:6.0 AS build
WORKDIR /src
COPY ["SSO.Api/SSO.Api.csproj", "SSO.Api/"]
COPY ["SSO.Booster/SSO.Booster.csproj", "SSO.Booster/"]
COPY ["SSO.Application/SSO.Application.csproj", "SSO.Application/"]
COPY ["SSO.Core/SSO.Core.csproj", "SSO.Core/"]
COPY ["SSO.Common/SSO.Common.csproj", "SSO.Common/"]
COPY ["SSO.Infrastructure/SSO.Infrastructure.csproj", "SSO.Infrastructure/"]
RUN dotnet restore "SSO.Api/SSO.Api.csproj"
COPY . .
WORKDIR "/src/SSO.Api"
RUN dotnet build "SSO.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SSO.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSO.Api.dll"]
