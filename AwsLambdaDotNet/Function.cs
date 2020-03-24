using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Lambda.RuntimeSupport;
using Amazon.Lambda.Serialization.Json;
using System;
using System.Threading.Tasks;

namespace AwsDotNet
{
    public class Function
    {
        /// <summary>
        /// The main entry point for the custom runtime.
        /// </summary>
        /// <param name="args"></param>
        private static async Task Main(string[] args)
        {
            Func<APIGatewayProxyRequest, ILambdaContext, object> func = FunctionHandler;
            using (var handlerWrapper = HandlerWrapper.GetHandlerWrapper(func, new JsonSerializer()))
            using (var bootstrap = new LambdaBootstrap(handlerWrapper))
            {
                await bootstrap.RunAsync();
            }
        }

        /// <summary>
        /// A simple function that takes an integer and returns a string from a list
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static object FunctionHandler(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var input = Newtonsoft.Json.JsonConvert.DeserializeObject<int>(request.Body);

            var repository = new Repository();
            var responseValue = repository.GetValue(input);

            var response = new
            {
                isBase64Encoded = false,
                headers = new { },
                statusCode = 200,
                body = Newtonsoft.Json.JsonConvert.SerializeObject(responseValue)
            };

            return response;
        }
    }
}
