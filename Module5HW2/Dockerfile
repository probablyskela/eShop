FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Module5HW2/Module5HW2.csproj", "Module5HW2/"]
RUN dotnet restore "Module5HW2/Module5HW2.csproj"
COPY . .
WORKDIR "/src/Module5HW2"
RUN dotnet build "Module5HW2.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Module5HW2.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Module5HW2.dll"]
