using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace AsyncGoneConflict.HelloWorld;

public class HelloWorldFunction(ILogger<HelloWorldFunction> logger)
{
    [Function("hello-world")]
    public Ok<string> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hello")] HttpRequestData requestData, FunctionContext _)
    {
        logger.LogInformation("", await requestData.Body.ReadAsStringAsync())
        TypedResults.Ok("hello world !");
    }
}
