FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base
RUN mkdir /app
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:8.0 as publish
WORKDIR /app
COPY Catalog.API.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o dist 

FROM base as final
WORKDIR /app
COPY --from=publish /app/dist .
ENTRYPOINT ["dotnet", "Catalog.API.dll"]