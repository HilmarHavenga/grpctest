using Grpc.Net.Client;
using GrpcClientTest;

Console.WriteLine("Connecting to server...");

using var channel = GrpcChannel.ForAddress("http://localhost:5073");
//var client = new Greeter.GreeterClient(channel);
//var reply = await client.SayHelloAsync(new HelloRequest
//{
//    Name = "GreeterClient"
//});
var equationRequest = new EquationRequest { Left = 3, Right = 7 };
var client = new Calculator.CalculatorClient(channel);
var result = await client.SumAsync(equationRequest);

Console.WriteLine($"EquationRequest {equationRequest.Left} + {equationRequest.Right}: {result.Result}");
Console.ReadLine();