#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["src/Services/Logging/Overload.Logging.Api/Overload.Logging.Api.csproj", "src/Services/Logging/Overload.Logging.Api/"]
RUN dotnet restore "src/Services/Logging/Overload.Logging.Api/Overload.Logging.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Logging/Overload.Logging.Api"
RUN dotnet build "Overload.Logging.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Overload.Logging.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Overload.Logging.Api.dll"]