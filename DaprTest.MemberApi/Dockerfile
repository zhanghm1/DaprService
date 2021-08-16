#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DaprTest.MemberApi/DaprTest.MemberApi.csproj", "DaprTest.MemberApi/"]
RUN dotnet restore "DaprTest.MemberApi/DaprTest.MemberApi.csproj"
COPY . .
WORKDIR "/src/DaprTest.MemberApi"
RUN dotnet build "DaprTest.MemberApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DaprTest.MemberApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DaprTest.MemberApi.dll"]
