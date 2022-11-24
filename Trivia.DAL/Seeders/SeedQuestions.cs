using Trivia.DAL.Entity;
using Trivia.DAL.Enums;

namespace Trivia.DAL.Seaders
{
    public partial class Seeder
    {
        private static async Task SeedQuestions(DataContext context)
        {
            if (!context.Questions.Any())
            {
                var categories = getArrayOfEnum<Categories>();
                var questions=new List<Question>();
                
                for (int i = 0; i < categories.Length; i++)
                {
                    for (int j = 1; j <= 50; j++)
                    {
                        questions.Add(CreateQuestion(j, categories.GetValue(i).ToString(),i+1));
                    }
                }

                await context.AddRangeAsync(questions);
                await context.SaveChangesAsync();
            }
        }

        private static Question CreateQuestion(int index,string categoryName,int categoryIndex)
        {
            Question question = new Question()
            {
                Text=$"This is the {index} question for category the {categoryName}",
                CategoryId=categoryIndex
            };
            return question;
        }
    }
}
