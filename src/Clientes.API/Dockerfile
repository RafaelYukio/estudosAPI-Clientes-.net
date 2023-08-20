#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN sed -i 's/TLSv1.2/TLSv1.0/g' /etc/ssl/openssl.cnf

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Clientes.API/Clientes.API.csproj", "src/Clientes.API/"]
COPY ["src/Clientes.Application/Clientes.Application.csproj", "src/Clientes.Application/"]
COPY ["src/Clientes.Domain/Clientes.Domain.csproj", "src/Clientes.Domain/"]
COPY ["src/Clientes.Infra.IoC/Clientes.Infra.IoC.csproj", "src/Clientes.Infra.IoC/"]
COPY ["src/Clientes.Infra.Data/Clientes.Infra.Data.csproj", "src/Clientes.Infra.Data/"]
RUN dotnet restore "src/Clientes.API/Clientes.API.csproj"
COPY . .
WORKDIR "/src/src/Clientes.API"
RUN dotnet build "Clientes.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Clientes.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Clientes.API.dll"]