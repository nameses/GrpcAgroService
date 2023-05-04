using Grpc.Core;
using GrpcAgroService;

namespace GrpcAgroService.Services
{
    public class GreeterService : Greeter.GreeterBase
    {
        private readonly ILogger<GreeterService> _logger;

        public GreeterService(ILogger<GreeterService> logger)
        {
            _logger = logger;
        }

        public override Task<InfoAgrofieldReply> GetInfoByName(InfoAgrofieldRequest request, ServerCallContext context)
        {
            return Task.FromResult(new InfoAgrofieldReply
            {
                Name = "Hello " + request.Name
            });
        }
    }
}