FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroservicesPractice.Shared/*.csproj Shared/MicroservicesPractice.Shared/
COPY IdentityServer/MicroservicesPractice.IdentityServer/*csproj IdentityServer/MicroservicesPractice.IdentityServer/
RUN dotnet restore IdentityServer/MicroservicesPractice.IdentityServer/*csproj
COPY  . .
RUN dotnet publish IdentityServer/MicroservicesPractice.IdentityServer/*csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:3.1 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroservicesPractice.IdentityServer.dll" ]