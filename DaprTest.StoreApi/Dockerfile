#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DaprTest.StoreApi/DaprTest.StoreApi.csproj", "DaprTest.StoreApi/"]
COPY ["DaprTest.Domain/DaprTest.Domain.csproj", "DaprTest.Domain/"]
COPY ["DaprTest.Common/DaprTest.Common.csproj", "DaprTest.Common/"]
RUN dotnet restore "DaprTest.StoreApi/DaprTest.StoreApi.csproj"
COPY . .
WORKDIR "/src/DaprTest.StoreApi"
RUN dotnet build "DaprTest.StoreApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprTest.StoreApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprTest.StoreApi.dll"]
