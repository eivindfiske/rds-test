FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["rds-test/rds test.csproj", "rds-test/"]
RUN dotnet restore "rds-test\rds test.csproj"
COPY . .
WORKDIR "/src/rds-test"
RUN dotnet build "rds test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "rds test.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "rds test.dll"]
