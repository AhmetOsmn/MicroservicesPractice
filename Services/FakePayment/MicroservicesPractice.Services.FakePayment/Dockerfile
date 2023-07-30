FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
EXPOSE 80
COPY Shared/MicroservicesPractice.Shared/*.csproj Shared/MicroservicesPractice.Shared/
COPY Services/FakePayment/MicroservicesPractice.Services.FakePayment/*.csproj Services/FakePayment/MicroservicesPractice.Services.FakePayment/
RUN dotnet restore Services/FakePayment/MicroservicesPractice.Services.FakePayment/*.csproj
COPY  . .
RUN dotnet publish Services/FakePayment/MicroservicesPractice.Services.FakePayment/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","MicroservicesPractice.Services.FakePayment.dll" ]