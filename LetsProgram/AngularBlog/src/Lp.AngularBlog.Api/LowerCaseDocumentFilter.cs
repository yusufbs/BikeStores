using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class LowerCaseDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // get all the path
        var paths = swaggerDoc.Paths.ToDictionary(
            path => path.Key.ToLowerInvariant(), 
            path => swaggerDoc.Paths[path.Key]);

        // add all the paths in swagger
        swaggerDoc.Paths = new OpenApiPaths();

        foreach (var pathItem in paths)
        {
            swaggerDoc.Paths.Add(pathItem.Key, pathItem.Value);
        }
    }
}
