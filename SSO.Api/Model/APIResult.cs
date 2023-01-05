using Microsoft.AspNetCore.Mvc;

namespace SSO.Api.Model
{

    public class MethodResult
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }
        public Object Value { get; set; }
        public MethodResultState State { get; set; }
    }

    public class APIActionResult : IActionResult
    {
        private readonly MethodResult methodResult;
        public APIActionResult(MethodResult methodResult)
        {
            this.methodResult = methodResult;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var result = new ObjectResult(methodResult.Exception ?? methodResult.Value)
            {
                StatusCode = methodResult.State == MethodResultState.success ? StatusCodes.Status200OK : StatusCodes.Status500InternalServerError
            };
            await result.ExecuteResultAsync(context);
        }
    }
    public enum MethodResultState
    {
        pending = 0,
        success = 1,
        fail = 2
    }
}
