
dotnet test /source/Netflix.ShareEngine.Api.Tests/Netflix.ShareEngine.Api.Tests.csproj \
    --configuration=Release \
    --no-restore \
    --no-build \
    --filter "Category!=Performance&Category!=Integration&Category!=Manual"