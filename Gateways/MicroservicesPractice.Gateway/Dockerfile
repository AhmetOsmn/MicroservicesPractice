FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Gateways/MicroservicesPractice.Gateway/*.csproj Gateways/MicroservicesPractice.Gateway/
RUN dotnet restore Gateways/MicroservicesPractice.Gateway/*.csproj
COPY  . .
RUN dotnet publish Gateways/MicroservicesPractice.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroservicesPractice.Gateway.dll" ]