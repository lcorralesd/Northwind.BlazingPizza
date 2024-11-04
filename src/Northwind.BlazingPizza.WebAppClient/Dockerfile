# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Northwind.BlazingPizza.WebAppClient/Northwind.BlazingPizza.WebAppClient.csproj", "src/Northwind.BlazingPizza.WebAppClient/"]
COPY ["src/Northwind.BlazingPizza.RazorViews/Northwind.BlazingPizza.RazorViews.csproj", "src/Northwind.BlazingPizza.RazorViews/"]
COPY ["src/Northwind.BlazingPizza.ViewModels/Northwind.BlazingPizza.ViewModels.csproj", "src/Northwind.BlazingPizza.ViewModels/"]
COPY ["src/Northwind.BlazingPizza.Proxies/Northwind.BlazingPizza.Proxies.csproj", "src/Northwind.BlazingPizza.Proxies/"]
COPY ["src/Northwind.BlazingPizza.GetSpecials.Entities/Northwind.BlazingPizza.GetSpecials.Entities.csproj", "src/Northwind.BlazingPizza.GetSpecials.Entities/"]
RUN dotnet restore "./src/Northwind.BlazingPizza.WebAppClient/Northwind.BlazingPizza.WebAppClient.csproj"
COPY . .
WORKDIR "/src/src/Northwind.BlazingPizza.WebAppClient"
RUN dotnet build "./Northwind.BlazingPizza.WebAppClient.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Northwind.BlazingPizza.WebAppClient.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Northwind.BlazingPizza.WebAppClient.dll"]