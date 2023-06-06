FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /src/Services.WebApi/out ./

ENTRYPOINT ["dotnet", "Services.WebApi.dll"]