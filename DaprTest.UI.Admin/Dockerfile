#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DaprTest.UI.Admin/DaprTest.UI.Admin.csproj", "DaprTest.UI.Admin/"]
COPY ["DaprTest.Application/DaprTest.Application.csproj", "DaprTest.Application/"]
COPY ["DaprTest.Common/DaprTest.Common.csproj", "DaprTest.Common/"]
COPY ["DaprTest.Domain/DaprTest.Domain.csproj", "DaprTest.Domain/"]
COPY ["DaprTest.EFCore/DaprTest.EFCore.csproj", "DaprTest.EFCore/"]
RUN dotnet restore "DaprTest.UI.Admin/DaprTest.UI.Admin.csproj"
COPY . .
WORKDIR "/src/DaprTest.UI.Admin"
RUN dotnet build "DaprTest.UI.Admin.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprTest.UI.Admin.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprTest.UI.Admin.dll"]