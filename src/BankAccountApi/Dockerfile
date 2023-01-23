FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BankAccountApi/BankAccountApi.csproj", "BankAccountApi/"]
COPY ["BankAccount.Transactions.Api/BankAccount.Transactions.Api.csproj", "BankAccount.Transactions.Api/"]
COPY ["BankAccount.Shared.Infrastructure/BankAccount.Shared.Infrastructure.csproj", "BankAccount.Shared.Infrastructure/"]
COPY ["BankAccount.Shared.Application/BankAccount.Shared.Application.csproj", "BankAccount.Shared.Application/"]
COPY ["BankAccount.Transactions.Core/BankAccount.Transactions.Core.csproj", "BankAccount.Transactions.Core/"]
COPY ["BankAccount.Users.Api/BankAccount.Users.Api.csproj", "BankAccount.Users.Api/"]
COPY ["BankAccountApi.Users.Core/BankAccountApi.Users.Core.csproj", "BankAccountApi.Users.Core/"]
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
