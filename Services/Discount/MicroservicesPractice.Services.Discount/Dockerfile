FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroservicesPractice.Shared/*.csproj Shared/MicroservicesPractice.Shared/
COPY Services/Discount/MicroservicesPractice.Services.Discount/*.csproj Services/Discount/MicroservicesPractice.Services.Discount/
RUN dotnet restore Services/Discount/MicroservicesPractice.Services.Discount/*.csproj
COPY  . .
RUN dotnet publish Services/Discount/MicroservicesPractice.Services.Discount/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroservicesPractice.Services.Discount.dll" ]