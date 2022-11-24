using Trivia.BLL.Models.ResponseApiModels;

namespace Trivia.BLL.Services
{
    public class BaseService
    {
        public BaseService()
        {

        }

        public async Task<TResponse> ExecuteQueriesAsync<TResponse>(Func<Task> queries, TResponse response)

        {
            try
            {
                await queries();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);

            }
            return response;
        }
        public async Task<TResponse> ExecuteQueriesWithHandledExceptionsAsync<TResponse>(Func<Task> queries, TResponse response)
            where TResponse : BaseResponse
        {
            try
            {
                await queries();
            }
            catch (Exception exception)
            {
                response.ToFailed(HasInnerException(exception));

            }
            return response;
        }

        private string HasInnerException(Exception exception)
        {
            return exception.InnerException == null ? exception.Message : exception.InnerException.Message;
        }
    }
}
