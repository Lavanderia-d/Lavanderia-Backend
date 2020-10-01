FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src

# Copy everything and restore as distinct layers
COPY Lavanderia.Api/*.csproj Lavanderia.Api/
COPY Lavanderia.Domain/*.csproj Lavanderia.Domain/
COPY Lavanderia.Infra/*.csproj Lavanderia.Infra/
RUN dotnet restore Lavanderia.Api/Lavanderia.Api.csproj
COPY . ./

# Build
WORKDIR /src/Lavanderia.Api
RUN dotnet build Lavanderia.Api.csproj -c Release -o /app/build

# Publish
FROM build as publish
RUN dotnet publish Lavanderia.Api.csproj -c Release -o /app/publish

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Lavanderia.Api.dll