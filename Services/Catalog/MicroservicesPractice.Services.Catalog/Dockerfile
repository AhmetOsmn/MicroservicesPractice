FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroservicesPractice.Shared/*.csproj Shared/MicroservicesPractice.Shared/
COPY Services/Catalog/MicroservicesPractice.Services.Catalog/*.csproj Services/Catalog/MicroservicesPractice.Services.Catalog/
RUN dotnet restore Services/Catalog/MicroservicesPractice.Services.Catalog/*.csproj
COPY  . .
RUN dotnet publish Services/Catalog/MicroservicesPractice.Services.Catalog/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroservicesPractice.Services.Catalog.dll" ]