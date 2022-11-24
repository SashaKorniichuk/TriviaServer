using Trivia.DAL.Entity;

namespace Trivia.DAL.Seaders
{
    public partial class Seeder
    {
        private static async Task SeedAnswers(DataContext context)
        {
            if (!context.Answers.Any())
            {
                var answers = new List<Answer>();
                for (int i = 1; i <= 500; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        answers.Add(CreateAnswer(false,i));
                    }
                    answers.Add(CreateAnswer(true,i));
                }
                await context.AddRangeAsync(answers);
                await context.SaveChangesAsync();
            }
        }

        private static Answer CreateAnswer(bool isCorrect, int questionIndex)
        {
            Answer answer = new Answer()
            {
                IsCorrect=isCorrect,
                Text=isCorrect ? "Correct answer" : "Wrong answer",
                QuestionId=questionIndex
            };
            return answer;
        }
    }
}
