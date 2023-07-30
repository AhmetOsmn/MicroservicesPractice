FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroservicesPractice.Shared/*.csproj Shared/MicroservicesPractice.Shared/
COPY Services/Order/MicroservicesPractice.Services.Order.Application/*.csproj Services/Order/MicroservicesPractice.Services.Order.Application/
COPY Services/Order/MicroservicesPractice.Services.Order.Domain/*.csproj Services/Order/MicroservicesPractice.Services.Order.Domain/
COPY Services/Order/MicroservicesPractice.Services.Order.Domain.Core/*.csproj Services/Order/MicroservicesPractice.Services.Order.Domain.Core/
COPY Services/Order/MicroservicesPractice.Services.Order.Infrastructure/*.csproj Services/Order/MicroservicesPractice.Services.Order.Infrastructure/
COPY Services/Order/MicroservicesPractice.Services.Order.API/*.csproj Services/Order/MicroservicesPractice.Services.Order.API/
RUN dotnet restore Services/Order/MicroservicesPractice.Services.Order.API/*.csproj
COPY  . .
RUN dotnet publish Services/Order/MicroservicesPractice.Services.Order.API/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroservicesPractice.Services.Order.API.dll" ]