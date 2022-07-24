FROM mcr.microsoft.com/dotnet/sdk:6.0.200 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY . .
WORKDIR /app
RUN dotnet restore

# Copy everything else and build
WORKDIR /app/FinanSist.WebApi
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/FinanSist.WebApi/out .
ENTRYPOINT ["dotnet", "FinanSist.WebApi.dll"]








