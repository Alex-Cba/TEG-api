FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

EXPOSE 80
EXPOSE 5024

COPY . ./

RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "TEG-api.dll"]
