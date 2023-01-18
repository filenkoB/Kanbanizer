FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore backend.sln
RUN dotnet build -o ./build

FROM base
WORKDIR /app
COPY --from=build /src/build .
ENTRYPOINT ["dotnet", "backend.WebApi.dll"]