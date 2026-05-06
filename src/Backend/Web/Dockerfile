FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

RUN --mount=type=bind,source=.,target=/tmp/context \
    find /tmp/context \( -name "*.csproj" -o -name "*.props" -o -name "*.slnx" \) -exec sh -c 'mkdir -p $(dirname "/src/${1#/tmp/context/}") && cp "$1" "/src/${1#/tmp/context/}"' _ {} \; && \
    dotnet restore "src/Backend/Web/Web.csproj"

COPY . .

RUN dotnet publish "src/Backend/Web/Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false --no-restore

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Web.dll"]
