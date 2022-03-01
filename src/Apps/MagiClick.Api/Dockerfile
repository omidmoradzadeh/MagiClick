#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Apps/MagiClick.Api/MagiClick.Api.csproj", "src/Apps/MagiClick.Api/"]
COPY ["src/Common/MagiClick.Infrastructure/MagiClick.Infrastructure.csproj", "src/Common/MagiClick.Api.Infrastructure/"]
COPY ["src/Common/MagiClick.Application/MagiClick.Application.csproj", "src/Common/MagiClick.Api.Application/"]
COPY ["src/Common/MagiClick.Domain/MagiClick.Domain.csproj", "src/Common/MagiClick.Api.Domain/"]
RUN dotnet restore "src/Apps/MagiClick.Api/MagiClick.Api.csproj"
COPY . .
WORKDIR "/src/src/Apps/MagiClick.Api"
RUN dotnet build "MagiClick.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagiClick.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagiClick.Api.dll"]