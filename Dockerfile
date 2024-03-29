FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 25029
EXPOSE 44325
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LifeManager_BlazorServerUI.csproj", "./"]
RUN dotnet restore "LifeManager_BlazorServerUI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "LifeManager_BlazorServerUI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LifeManager_BlazorServerUI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LifeManager_BlazorServerUI.dll"]
