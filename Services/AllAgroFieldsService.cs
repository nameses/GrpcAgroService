using Grpc.Core;
using GrpcAgroService.Data;
using Microsoft.EntityFrameworkCore;

namespace GrpcAgroService.Services
{
    public class AllAgroFieldService : AllAgroField.AllAgroFieldBase
    {
        private readonly ServerDbContext _dbContext;
        private readonly ILogger<AllAgroFieldService> _logger;

        public AllAgroFieldService(ServerDbContext dbContext,
            ILogger<AllAgroFieldService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public override Task<InfoAllAgrofieldReply> GetInfoByName(InfoAllAgrofieldRequest request, ServerCallContext context)
        {
            var data = _dbContext.AgroFields.ToListAsync().Result.Select(entity =>
            {
                return new InfoAgrofieldData()
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
                };
            });//.ToList();

            if (data == null)
            {
                return Task.FromResult(new InfoAllAgrofieldReply
                {
                    Success = false
                }); ;
            }

            return Task.FromResult(new InfoAllAgrofieldReply
            {
                Success = true,
                Data = { data }
            });
        }
    }
}