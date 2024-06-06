FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SingleHostOrleans7/SingleHostOrleans7.csproj", "SingleHostOrleans7/"]
RUN dotnet restore "SingleHostOrleans7/SingleHostOrleans7.csproj"
COPY . .
WORKDIR "/src/SingleHostOrleans7"
RUN dotnet build "SingleHostOrleans7.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SingleHostOrleans7.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SingleHostOrleans7.dll"]
