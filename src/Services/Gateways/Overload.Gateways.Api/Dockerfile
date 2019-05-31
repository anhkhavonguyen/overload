FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Gateways/Overload.Gateways.Api/Overload.Gateways.Api.csproj", "src/Services/Gateways/Overload.Gateways.Api/"]
RUN dotnet restore "src/Services/Gateways/Overload.Gateways.Api/Overload.Gateways.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Gateways/Overload.Gateways.Api"
RUN dotnet build "Overload.Gateways.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Overload.Gateways.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Overload.Gateways.Api.dll"]