using Microsoft.Extensions.DependencyInjection;

namespace Trivia.DAL.Seaders
{
    public partial class Seeder
    {
        private static Random random = new Random();
        public async static Task SeedData(IServiceProvider services)
        {
            using (var scope = services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DataContext>();
                await SeedCategories(context);
                await SeedQuestions(context);
                await SeedAnswers(context);
                await SeedPlayers(context);
            }
        }
        private static Array getArrayOfEnum<T>() where T : Enum
        {
            Type type = typeof(T);
            Array result = type.GetEnumValues();
            return result;
        }
    }
}
