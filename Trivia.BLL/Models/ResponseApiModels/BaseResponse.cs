using Trivia.BLL.Helpers;

namespace Trivia.BLL.Models.ResponseApiModels
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Status = ResponseStatus.Success;
            Message = string.Empty;
        }

        public string Status { get; set; }
        public string Message { get; set; }

        public BaseResponse ToFailed(string failureMessage)
        {
            Status = ResponseStatus.Failed;
            Message = failureMessage;
            return this;
        }
    }
}
