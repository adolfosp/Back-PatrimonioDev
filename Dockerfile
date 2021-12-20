FROM mcr.microsoft.com/dotnet/sdk:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "Domain/Domain.csproj"
COPY ./Domain ./Domain

COPY ["Aplicacao/Aplicacao.csproj", "Aplicacao/"]
RUN dotnet restore "Aplicacao/Aplicacao.csproj"
COPY ./Aplicacao ./Aplicacao

COPY ["Persistence/Persistence.csproj", "Persistence/"]
RUN dotnet restore "Persistence/Persistence.csproj"
COPY ./Persistence ./Persistence

COPY ["PatrimonioDev/PatrimonioDev.csproj", "PatrimonioDev/"]
RUN dotnet restore "PatrimonioDev/PatrimonioDev.csproj"
COPY ./PatrimonioDev ./PatrimonioDev

WORKDIR "/src/PatrimonioDev"
RUN dotnet build "PatrimonioDev.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatrimonioDev.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./Docker/build ./wwwroot

RUN useradd -m myappuser
USER myappuser

CMD ASPNETCORE_URLS="http://*:$PORT" dotnet PatrimonioDev.dll