FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["quickOS.API/quickOS.API.csproj", "quickOS.API/"]
COPY ["quickOS.Application/quickOS.Application.csproj", "quickOS.Application/"]
COPY ["quickOS.Core/quickOS.Core.csproj", "quickOS.Core/"]
COPY ["quickOS.Infra/quickOS.Infra.csproj", "quickOS.Infra/"]
RUN dotnet restore "quickOS.API/quickOS.API.csproj"
COPY . .
WORKDIR "/src/quickOS.API"
RUN dotnet build "quickOS.API.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "quickOS.API.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "quickOS.API.dll"]
