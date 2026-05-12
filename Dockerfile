# Multi-stage Dockerfile for .NET application

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS builder
WORKDIR /src

# Copy project files
COPY ["MyServerJob.App/MyServerJob.App.csproj", "MyServerJob.App/"]
COPY ["MyServerJob.Tests/MyServerJob.Tests.csproj", "MyServerJob.Tests/"]

# Restore dependencies
RUN dotnet restore "MyServerJob.App/MyServerJob.App.csproj"

# Copy source code
COPY . .

# Build and publish
RUN dotnet publish "MyServerJob.App/MyServerJob.App.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/runtime:10.0
WORKDIR /app

# Copy published application from builder
COPY --from=builder /app/publish .

# Set entry point
ENTRYPOINT ["./MyServerJob.App"]
