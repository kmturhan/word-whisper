FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
COPY . .
RUN dotnet publish WordWhisper.Web/WordWhisper.Web.csproj -c Release --property:PublishDir=/out
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /out .
ENTRYPOINT dotnet WordWhisper.Web.dll