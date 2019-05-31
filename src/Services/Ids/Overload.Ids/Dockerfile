FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Ids/Overload.Ids/Overload.Ids.csproj", "src/Services/Ids/Overload.Ids/"]
RUN dotnet restore "src/Services/Ids/Overload.Ids/Overload.Ids.csproj"
COPY . .
WORKDIR "/src/src/Services/Ids/Overload.Ids"
RUN dotnet build "Overload.Ids.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Overload.Ids.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Overload.Ids.dll"]