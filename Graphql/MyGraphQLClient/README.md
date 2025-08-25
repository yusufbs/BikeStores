

dotnet new console -n MyGraphQLClient
cd MyGraphQLClient

dotnet add package StrawberryShake.Transport.Http
dotnet add package StrawberryShake.CodeGeneration.CSharp.Analyzers
dotnet add package Microsoft.Extensions.DependencyInjection
dotnet new tool-manifest --force
dotnet tool install StrawberryShake.Tools --local

dotnet graphql init http://localhost:5095/graphql/ -n MyGraphQLClient
