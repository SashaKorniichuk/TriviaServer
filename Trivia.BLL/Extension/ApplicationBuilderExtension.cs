using Microsoft.AspNetCore.Builder;
using Trivia.DAL.Seaders;

namespace Trivia.BLL.Extension
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder AddSeeder(this IApplicationBuilder app)
        {
            Seeder.SeedData(app.ApplicationServices);
            return app;
        }
    }
}
