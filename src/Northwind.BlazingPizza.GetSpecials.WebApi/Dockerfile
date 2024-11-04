# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Northwind.BlazingPizza.GetSpecials.WebApi/Northwind.BlazingPizza.GetSpecials.WebApi.csproj", "src/Northwind.BlazingPizza.GetSpecials.WebApi/"]
COPY ["src/Northwind.BlazingPizza.GetSpecials.IoC/Northwind.BlazingPizza.GetSpecials.IoC.csproj", "src/Northwind.BlazingPizza.GetSpecials.IoC/"]
COPY ["src/Northwind.BlazingPizza.GetSpecials.Core/Northwind.BlazingPizza.GetSpecials.Core.csproj", "src/Northwind.BlazingPizza.GetSpecials.Core/"]
COPY ["src/Northwind.BlazingPizza.GetSpecials.BusinessObjects/Northwind.BlazingPizza.GetSpecials.BusinessObjects.csproj", "src/Northwind.BlazingPizza.GetSpecials.BusinessObjects/"]
COPY ["src/Northwind.BlazingPizza.GetSpecials.Entities/Northwind.BlazingPizza.GetSpecials.Entities.csproj", "src/Northwind.BlazingPizza.GetSpecials.Entities/"]
COPY ["src/Northwind.BlazingPizza.GetSpecials.Repositories/Northwind.BlazingPizza.GetSpecials.Repositories.csproj", "src/Northwind.BlazingPizza.GetSpecials.Repositories/"]
RUN dotnet restore "./src/Northwind.BlazingPizza.GetSpecials.WebApi/Northwind.BlazingPizza.GetSpecials.WebApi.csproj"
COPY . .
WORKDIR "/src/src/Northwind.BlazingPizza.GetSpecials.WebApi"
RUN dotnet build "./Northwind.BlazingPizza.GetSpecials.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Northwind.BlazingPizza.GetSpecials.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Northwind.BlazingPizza.GetSpecials.WebApi.dll"]