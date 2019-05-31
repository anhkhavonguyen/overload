FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["src/Services/Reporting/Overload.Reporting.Service/Overload.Reporting.Service.csproj", "src/Services/Reporting/Overload.Reporting.Service/"]
RUN dotnet restore "src/Services/Reporting/Overload.Reporting.Service/Overload.Reporting.Service.csproj"
COPY . .
WORKDIR "/src/src/Services/Reporting/Overload.Reporting.Service"
RUN dotnet build "Overload.Reporting.Service.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Overload.Reporting.Service.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Overload.Reporting.Service.dll"]