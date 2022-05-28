#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["backend01/backend01.csproj", "backend01/"]
COPY ["modelos/modelos.csproj", "modelos/"]
RUN dotnet restore "backend01/backend01.csproj"
COPY . .
WORKDIR "/src/backend01"
RUN dotnet build "backend01.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "backend01.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "backend01.dll"]