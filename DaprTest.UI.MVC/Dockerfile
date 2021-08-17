#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DaprTest.UI.MVC/DaprTest.UI.MVC.csproj", "DaprTest.UI.MVC/"]
RUN dotnet restore "DaprTest.UI.MVC/DaprTest.UI.MVC.csproj"
COPY . .
WORKDIR "/src/DaprTest.UI.MVC"
RUN dotnet build "DaprTest.UI.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprTest.UI.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprTest.UI.MVC.dll"]