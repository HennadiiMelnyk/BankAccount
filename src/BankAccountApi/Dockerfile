FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["src/BankAccountApi/BankAccountApi.csproj", "src/BankAccountApi/"]

COPY ["src/modules/Transactions/BankAccount.Transactions.Api/BankAccount.Transactions.Api.csproj", "src/modules/Transactions/BankAccount.Transactions.Api/"]
COPY ["src/modules/Transactions/BankAccount.Transactions.Core/BankAccount.Transactions.Core.csproj", "src/modules/Transactions/BankAccount.Transactions.Core/"]


COPY ["src/shared/BankAccount.Shared.Application/BankAccount.Shared.Application.csproj", "src/shared/BankAccount.Shared.Application/"]
COPY ["src/shared/BankAccount.Shared.Infrastructure/BankAccount.Shared.Infrastructure.csproj", "src/shared/BankAccount.Shared.Infrastructure/"]

COPY ["src/modules/UserManagement/BankAccount.Users.Api/BankAccount.Users.Api.csproj", "src/modules/UserManagement/BankAccount.Users.Api/"]
COPY ["src/modules/UserManagement/BankAccount.Users.Core/BankAccount.Users.Core.csproj", "src/modules/UserManagement/BankAccount.Users.Core/"]


RUN dotnet restore "src/BankAccountApi/BankAccountApi.csproj"
COPY . .
WORKDIR "src/BankAccountApi"
RUN dotnet build "BankAccountApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BankAccountApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankAccountApi.dll"]
