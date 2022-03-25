FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# cSopy csproj and restore as distinct layers
COPY  *.sln .
COPY /FinanSist.Domain/*.csproj ./FinanSist.Domain/
COPY /FinanSist.WebApi/*.csproj ./FinanSist.WebApi/

RUN dotnet restore

COPY FinanSist.Domain/. ./FinanSist.Domain/
COPY /FinanSist.WebApi/. ./FinanSist.WebApi/

WORKDIR /app/FinanSist.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/FinanSist.WebApi/out ./
ENTRYPOINT ["dotnet", "FinanSist.WebApi.dll"]








