FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroservicesPractice.Shared/*.csproj Shared/MicroservicesPractice.Shared/
COPY Services/PhotoStock/MicroservicesPractice.Services.PhotoStock/*.csproj Services/PhotoStock/MicroservicesPractice.Services.PhotoStock/
RUN dotnet restore Services/PhotoStock/MicroservicesPractice.Services.PhotoStock/*.csproj
COPY  . .
RUN dotnet publish Services/PhotoStock/MicroservicesPractice.Services.PhotoStock/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroservicesPractice.Services.PhotoStock.dll" ]