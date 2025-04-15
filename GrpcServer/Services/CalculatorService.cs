using Grpc.Core;

namespace GrpcServer.Services;

public class CalculatorService : Calculator.CalculatorBase
{
    private readonly ILogger<CalculatorService> _logger;

    public CalculatorService(ILogger<CalculatorService> logger)
    {
        _logger = logger;
    }

    public override Task<CalculationResult> Sum(EquationRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Received new Calculation Request for {0}:", nameof(Sum));

        var result = new CalculationResult
        {
            Result = request.Left + request.Right
        };

        return Task.FromResult(result);
    }
}
