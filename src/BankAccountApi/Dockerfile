FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["BankAccountApi/BankAccountApi.csproj", "BankAccountApi/"]

COPY ["modules/Transactions/BankAccount.Transactions.Api/BankAccount.Transactions.Api.csproj", "modules/Transactions/BankAccount.Transactions.Api/"]
COPY ["modules/Transactions/BankAccount.Transactions.Core/BankAccount.Transactions.Core.csproj", "modules/Transactions/BankAccount.Transactions.Core/"]


COPY ["shared/BankAccount.Shared.Application/BankAccount.Shared.Application.csproj", "shared/BankAccount.Shared.Application/"]
COPY ["shared/BankAccount.Shared.Infrastructure/BankAccount.Shared.Infrastructure.csproj", "shared/BankAccount.Shared.Infrastructure/"]

COPY ["modules/UserManagement/BankAccount.Users.Api/BankAccount.Users.Api.csproj", "modules/UserManagement/BankAccount.Users.Api/"]
COPY ["modules/UserManagement/BankAccount.Users.Core/BankAccount.Users.Core.csproj", "modules/UserManagement/BankAccount.Users.Core/"]


RUN dotnet restore "BankAccountApi/BankAccountApi.csproj"
COPY . .
WORKDIR "/src/BankAccountApi"
RUN dotnet build "BankAccountApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankAccountApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankAccountApi.dll"]
