FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY AtivaInvestimentos.API/AtivaInvestimentos.API.csproj AtivaInvestimentos.API/
COPY AtivaInvestimentos.DTO/AtivaInvestimentos.DTO.csproj AtivaInvestimentos.DTO/
COPY AtivaInvestimentos.Domain/AtivaInvestimentos.Domain.csproj AtivaInvestimentos.Domain/
COPY AtivaInvestimentos.Infra/AtivaInvestimentos.Infra.csproj AtivaInvestimentos.Infra/
COPY AtivaInvestimentos.Service/AtivaInvestimentos.Service.csproj AtivaInvestimentos.Service/
COPY AtivaInvestimentos.Validations/AtivaInvestimentos.Validation.csproj AtivaInvestimentos.Validations/
RUN dotnet restore AtivaInvestimentos.API/AtivaInvestimentos.API.csproj
COPY . .
WORKDIR /src/AtivaInvestimentos.API
RUN dotnet build AtivaInvestimentos.API.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish AtivaInvestimentos.API.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AtivaInvestimentos.API.dll"]
