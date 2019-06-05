#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-stretch AS build
WORKDIR /src
COPY ["src/Services/Payment/Overload.Payment.Api/Overload.Payment.Api.csproj", "src/Services/Payment/Overload.Payment.Api/"]
RUN dotnet restore "src/Services/Payment/Overload.Payment.Api/Overload.Payment.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Payment/Overload.Payment.Api"
RUN dotnet build "Overload.Payment.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Overload.Payment.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Overload.Payment.Api.dll"]