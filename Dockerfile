FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
COPY . .
RUN dotnet publish WordWhisper.Web/WordWhisper.Web.csproj -c Release --property:PublishDir=/out
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY ~/.microsoft/usersecrets/cf22710a-baf0-45a1-8890-18c3b00f12a6 /app/secrets
COPY --from=build-env /out .
ENTRYPOINT dotnet WordWhisper.Web.dll