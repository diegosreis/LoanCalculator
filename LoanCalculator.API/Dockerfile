FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY . ./

RUN dotnet restore "LoanCalculator.API/LoanCalculator.API.csproj"

RUN dotnet build "LoanCalculator.API/LoanCalculator.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoanCalculator.API/LoanCalculator.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "LoanCalculator.API.dll"]