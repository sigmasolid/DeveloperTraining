FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Workshop3.EFCore.WebAPI/Workshop3.EFCore.WebAPI.csproj", "Workshop3.EFCore.WebAPI/"]
RUN dotnet restore "Workshop3.EFCore.WebAPI/Workshop3.EFCore.WebAPI.csproj"
COPY . .
WORKDIR "/src/Workshop3.EFCore.WebAPI"
RUN dotnet build "Workshop3.EFCore.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Workshop3.EFCore.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Workshop3.EFCore.WebAPI.dll"]
