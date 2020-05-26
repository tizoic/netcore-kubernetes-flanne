FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as builder
WORKDIR /app
COPY . ./
RUN dotnet restore ./00-backend.Api/*.csproj
RUN dotnet publish 00-backend.Api/*.csproj -c Release -o ./source

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=builder /app/source .
ENTRYPOINT [ "dotnet", "backend.Api.dll" ]
