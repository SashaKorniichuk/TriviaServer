using Trivia.DAL.Entity;
using Trivia.DAL.Enums;

namespace Trivia.DAL.Seaders
{
    public partial class Seeder
    {
        private static async Task SeedCategories(DataContext context)
        {
            if (!context.Categories.Any())
            {
                Array categoriesList = getArrayOfEnum<Categories>();

                var categories = new List<Category>();

                for (int i = 0; i < 10; i++)
                {
                    categories.Add(CreateCategory(categoriesList.GetValue(i).ToString()));
                }

                await context.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }

        private static Category CreateCategory(string categoryName)
        {
            var category = new Category()
            {
                Name = categoryName,
            };
            return category;
        }
    }
}
