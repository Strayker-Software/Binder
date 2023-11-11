FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 80

COPY binder-web-backend/Binder.sln binder-web-backend/Binder.sln
COPY binder-web-backend/Binder.Api/Binder.Api.csproj binder-web-backend/Binder.Api/Binder.Api.csproj
COPY binder-web-backend/Binder.Application/Binder.Application.csproj binder-web-backend/Binder.Application/Binder.Application.csproj
COPY binder-web-backend/Binder.Core/Binder.Core.csproj binder-web-backend/Binder.Core/Binder.Core.csproj
COPY binder-web-backend/Binder.IntegrationTests/Binder.IntegrationTests.csproj binder-web-backend/Binder.IntegrationTests/Binder.IntegrationTests.csproj
COPY binder-web-backend/Binder.Persistence/Binder.Persistence.csproj binder-web-backend/Binder.Persistence/Binder.Persistence.csproj
COPY binder-web-backend/Binder.UnitTests/Binder.UnitTests.csproj binder-web-backend/Binder.UnitTests/Binder.UnitTests.csproj

RUN dotnet restore binder-web-backend/Binder.sln

COPY binder-web-backend/Binder.Api binder-web-backend/Binder.Api
COPY binder-web-backend/Binder.Application binder-web-backend/Binder.Application
COPY binder-web-backend/Binder.Persistence binder-web-backend/Binder.Persistence
COPY binder-web-backend/Binder.Core binder-web-backend/Binder.Core
WORKDIR /app/binder-web-backend
RUN  dotnet  publish -c Release  -o /app/binder-web-backend/out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build  /app/binder-web-backend/out .
ENTRYPOINT [ "dotnet", "Binder.Api.dll" ]