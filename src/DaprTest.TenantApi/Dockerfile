#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DaprTest.TenantApi/DaprTest.TenantApi.csproj", "DaprTest.TenantApi/"]
COPY ["DaprTest.Domain/DaprTest.Domain.csproj", "DaprTest.Domain/"]
COPY ["DaprTest.Common/DaprTest.Common.csproj", "DaprTest.Common/"]
RUN dotnet restore "DaprTest.TenantApi/DaprTest.TenantApi.csproj"
COPY . .
WORKDIR "/src/DaprTest.TenantApi"
RUN dotnet build "DaprTest.TenantApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprTest.TenantApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprTest.TenantApi.dll"]
