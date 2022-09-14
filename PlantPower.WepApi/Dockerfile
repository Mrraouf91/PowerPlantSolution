#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PlantPower.WepApi/PlantPower.WepApi.csproj", "PlantPower.WepApi/"]
COPY ["PowerPlant.Service/PowerPlant.Application.csproj", "PowerPlant.Service/"]
COPY ["PowerPlant.Entities/PowerPlant.Entities.csproj", "PowerPlant.Entities/"]
COPY ["PowerPlant.Dto/PowerPlant.Dto.csproj", "PowerPlant.Dto/"]
RUN dotnet restore "PlantPower.WepApi/PlantPower.WepApi.csproj"
COPY . .
WORKDIR "/src/PlantPower.WepApi"
RUN dotnet build "PlantPower.WepApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PlantPower.WepApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PlantPower.WepApi.dll"]