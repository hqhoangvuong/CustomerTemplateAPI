using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Writers;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTemplateAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            var sw = (ISwaggerProvider)host.Services.GetService(typeof(ISwaggerProvider));
            var doc = sw.GetSwagger("v1", null, "/");
            using (var streamWriter = new StringWriter())
            {
                var writer = new OpenApiJsonWriter(streamWriter);
                doc.SerializeAsV2(writer);
                var swaggerString = streamWriter.ToString();
                File.WriteAllText("swagger.json", swaggerString);
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
