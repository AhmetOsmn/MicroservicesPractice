FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroservicesPractice.Shared/*.csproj Shared/MicroservicesPractice.Shared/
COPY Frontends/MicroservicesPractice.Web/*csproj Frontends/MicroservicesPractice.Web/
RUN dotnet restore Frontends/MicroservicesPractice.Web/*csproj
COPY  . .
RUN dotnet publish Frontends/MicroservicesPractice.Web/*csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroservicesPractice.Web.dll" ]