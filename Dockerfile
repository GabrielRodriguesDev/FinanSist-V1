FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# cSopy csproj and restore as distinct layers
COPY  *.sln .
COPY /TestArchitectureReviewOne.Domain/*.csproj ./TestArchitectureReviewOne.Domain/
COPY /TestArchitectureReviewOne.WebApi/*.csproj ./TestArchitectureReviewOne.WebApi/

RUN dotnet restore

COPY TestArchitectureReviewOne.Domain/. ./TestArchitectureReviewOne.Domain/
COPY /TestArchitectureReviewOne.WebApi/. ./TestArchitectureReviewOne.WebApi/

WORKDIR /app/TestArchitectureReviewOne.WebApi
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/TestArchitectureReviewOne.WebApi/out ./
ENTRYPOINT ["dotnet", "TestArchitectureReviewOne.WebApi.dll"]








