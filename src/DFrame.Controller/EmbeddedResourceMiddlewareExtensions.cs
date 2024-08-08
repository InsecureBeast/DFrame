using Microsoft.Extensions.FileProviders;
using System.Reflection;


namespace DFrame
{
    public static class EmbeddedResourceMiddlewareExtensions
    {
        public static IApplicationBuilder UseEmbeddedResourceMiddleware(this IApplicationBuilder app, string resourceNamespace, Assembly assembly)
        {
            var fileProvider = new ManifestEmbeddedFileProvider(assembly, resourceNamespace);
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = fileProvider,
                RequestPath = "/embedded-resources"
            });
            return app;
        }
    }
}