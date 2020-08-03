FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Taxas.API/Taxas.API.csproj", "src/Taxas.API/"]
COPY ["src/Taxas.Application/Taxas.Application.csproj", "src/Taxas.Application/"]
COPY ["src/Taxas.Domain/Taxas.Domain.csproj", "src/Taxas.Domain/"]
COPY ["src/Taxas.Data/Taxas.Data.csproj", "src/Taxas.Data/"]
RUN dotnet restore "src/Taxas.API/Taxas.API.csproj"
COPY . .

WORKDIR "/src/src/Taxas.API"
RUN dotnet build "Taxas.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Taxas.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Taxas.API.dll"]