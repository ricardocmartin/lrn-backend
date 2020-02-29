FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Lrn.Api/Lrn.Api.csproj", "Lrn.Api/"]
COPY ["Lrn.Aplication/Lrn.Aplication.csproj", "Lrn.Aplication/"]
COPY ["Lrn.Domain/Lrn.Domain.csproj", "Lrn.Domain/"]
COPY ["Lrn.Services/Lrn.Service.csproj", "Lrn.Services/"]
COPY ["Lrn.Infra.CrossCutting/Lrn.Infra.CrossCutting.csproj", "Lrn.Infra.CrossCutting/"]
COPY ["Lrn.Infra.Data/Lrn.Infra.Data.csproj", "Lrn.Infra.Data/"]
RUN dotnet restore "Lrn.Api/Lrn.Api.csproj"
COPY . .
WORKDIR "/src/Lrn.Api"
RUN dotnet build "Lrn.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lrn.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lrn.Api.dll"]