FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish WordWhisper.Web.csproj -c Release -o out
WORKDIR out
ENV ASPNETCORE_URLS="http://*:1453"
ENTRYPOINT ["dotnet", "WordWhisper.Web.dll"]