ARG BASE
ARG BUILD_NUMBER

FROM ${BASE} as build

RUN dotnet publish \
        --configuration=Release \
        --output /output

FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /app

COPY --from=build /output .

ENV Uploader__Meta__BuildNumber ${BUILD_NUMBER}

CMD ["dotnet", "Netflix.ShareEngine.Api.dll"]