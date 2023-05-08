using Grpc.Core;
using GrpcAgroService;
using GrpcAgroService.Data;

namespace GrpcAgroService.Services
{
    public class AgroFieldService : AgroField.AgroFieldBase
    {
        private readonly ServerDbContext _dbContext;
        private readonly ILogger<AgroFieldService> _logger;

        public AgroFieldService(ServerDbContext dbContext,
            ILogger<AgroFieldService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public override Task<InfoAgrofieldReply> GetInfoByName(InfoAgrofieldRequest request, ServerCallContext context)
        {
            var entity = _dbContext.AgroFields.FindAsync(request.Name).Result;
            if (entity == null)
            {
                return Task.FromResult(new InfoAgrofieldReply
                {
                    Success = false
                }); ;
            }

            return Task.FromResult(new InfoAgrofieldReply
            {
                Success = true,
                Data = new InfoAgrofieldData()
                {
                    Name = entity.Name,
                    Aria = entity.Aria,
                    Bal = entity.Bal,
                    PH = entity.PH,
                    Azot = entity.Azot,
                    Phosfor = entity.Phosfor,
                    Kaliy = entity.Kaliy,
                    Manganese = entity.Manganese,
                    Cobalt = entity.Cobalt,
                    Copper = entity.Copper,
                    Zinc = entity.Zinc,
                    Lead = entity.Lead,
                    Cesium = entity.Cesium,
                    Strontium = entity.StrontiumMin + "-" + entity.StrontiumMax
                }
            });
        }
    }
}