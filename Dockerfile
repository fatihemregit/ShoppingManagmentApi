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
COPY ["ShoppingManagment/ShoppingManagment.csproj", "ShoppingManagment/"]
COPY ["Business/Business.csproj", "Business/"]
COPY ["Data/Data.csproj", "Data/"]
COPY ["Entity/Entity.csproj", "Entity/"]
RUN dotnet restore "./ShoppingManagment/ShoppingManagment.csproj"
COPY . .
WORKDIR "/src/ShoppingManagment"
RUN dotnet build "ShoppingManagment.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ShoppingManagment.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#Env deðerleri
ENV JWT__securityKey = "SF3VCQUYCQfHQkjI0ziWZ4KIU2vZIpMB7q9hScw8oTP0FZlHY5Ve5Y9ym6HgFU54Mbk0p6SeQvYFYZSmxTGt4dWMxR45CoGqTies"
ENV JWT__issuer = "wYkh97r1BRZmVAyXTHojfUzJX5tYEa2dLTlzBgwMhryzDRHB8PkhuW38E6pmMjKD"
ENV JWT__audience = "a1gQbceyrGfHIwzPyYR4F7XjAfsdA3rglQH0gLLM2jlzQEZkIt8eTEeoU3kIiX5V"
ENV JWT__accessTokenExpirationInMinute = 15
ENV JWT__refreshTokenExpirationInDay = 7 



ENTRYPOINT ["dotnet", "ShoppingManagment.dll"]