#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ToDo-WebApp/ToDo-WebApp.csproj", "ToDo-WebApp/"]
RUN dotnet restore "ToDo-WebApp/ToDo-WebApp.csproj"
COPY . .
WORKDIR "/src/ToDo-WebApp"
RUN dotnet build "ToDo-WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDo-WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo-WebApp.dll"]