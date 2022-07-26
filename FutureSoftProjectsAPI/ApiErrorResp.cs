using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FutureSoftProjectsAPI
{
    public class ApiErrorResp
    {
        public string Message { get; set; } = "Please correct the specified Errors and try again.";
        public List<string> Errors { get; set; }
        public ApiErrorResp(string message)
        {
            Errors = new List<string>() { message };
        }

        public ApiErrorResp(List<string> messages)
        {
            Errors = messages;
        }

        public ApiErrorResp(ModelStateDictionary modelState)
        {
            Errors = modelState.Values.SelectMany(modelErrorCollection => modelErrorCollection.Errors).
                                       Select(modelError => modelError.ErrorMessage).
                                       ToList();
        }
    }
}
