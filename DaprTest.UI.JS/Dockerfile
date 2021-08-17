#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DaprTest.UI.JS/DaprTest.UI.JS.csproj", "DaprTest.UI.JS/"]
RUN dotnet restore "DaprTest.UI.JS/DaprTest.UI.JS.csproj"
COPY . .
WORKDIR "/src/DaprTest.UI.JS"
RUN dotnet build "DaprTest.UI.JS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprTest.UI.JS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprTest.UI.JS.dll"]