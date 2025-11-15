# Dockerfile for .NET 9 project located in BPCalculator/
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy only the project file first - speeds rebuilds with cache
COPY BPCalculator/*.csproj ./BPCalculator/
RUN dotnet restore BPCalculator/BPCalculator.csproj

# Copy the rest of the source and publish
COPY . .
RUN dotnet publish BPCalculator/BPCalculator.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
EXPOSE 8080

ENTRYPOINT ["dotnet", "BPCalculator.dll"]
