FROM mcr.microsoft.com/dotnet/sdk:7.0 
 
WORKDIR /source

COPY ./src/*.sln .
COPY ./src/Netflix.ShareEngine.Api/*.csproj ./Netflix.ShareEngine.Api/
COPY ./src/Netflix.ShareEngine.Api.Tests/*.csproj ./Netflix.ShareEngine.Api.Tests/

RUN dotnet restore
 
COPY ./src/Netflix.ShareEngine.Api/. ./Netflix.ShareEngine.Api/
COPY ./src/Netflix.ShareEngine.Api.Tests/. ./Netflix.ShareEngine.Api.Tests/
COPY ./ci/*.sh ./ci/

RUN chmod a+x ci/*.sh

RUN dotnet build --configuration=Release 