using Grpc.Core;
using GrpcAgroService.Data;
using GrpcAgroService.Models;
using GrpcAgroService.Services.common;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace GrpcAgroService.Services
{
    public class AgroFieldByFilterService : AgroFieldByFilter.AgroFieldByFilterBase
    {
        private readonly ServerDbContext _context;

        public AgroFieldByFilterService(ServerDbContext context)
        {
            _context = context;
        }

        //AgroFieldModelField field, double? min = null, double? max = null
        public override Task<InfoAllAgrofieldReply> GetAgroFieldsByFilter(AgroFieldByFilterRequest request, ServerCallContext context)
        {
            IQueryable<AgroFieldModel> query = _context.AgroFields;
            AgroFieldParam field;
            //convert str to lowercase with first capital letter
            //string normalizedFieldName = request.Field.ToLower()
            //    .Replace(request.Field[0], char.ToUpper(request.Field[0]));
            if (string.IsNullOrEmpty(request.Field))
                throw new ArgumentException("Field name is required.", nameof(request.Field));

            //convert to nullable vals
            double? min = request.Min != 0 ? request.Min : null;
            double? max = request.Max != 0 ? request.Max : null;

            if (min > max)
                throw new ArgumentException("Min value cannot be greater than Max value.", nameof(request));

            if (!Enum.TryParse(request.Field, true, out field))
                throw new ArgumentException("Field not found.", request.Field);

            if (field != AgroFieldParam.Name && field != AgroFieldParam.Strontium && field != AgroFieldParam.Bal)
            {
                PropertyInfo propInfo = typeof(AgroFieldModel).GetProperty(field.ToString(), BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

                if (propInfo == null)
                    throw new ArgumentException($"Field {field} not found on AgroFieldModel");
                if (min != null)
                    query = query.AsEnumerable().Where(x => (double)propInfo.GetValue(x) >= min).AsQueryable();

                if (max != null)
                    query = query.AsEnumerable().Where(x => (double)propInfo.GetValue(x) <= max).AsQueryable();

                //query = query.Where(x => propInfo.GetValue(x) != null &&
                //(request.Min == null || (double)propInfo.GetValue(x) >= request.Min)
                //&& (request.Max == null || (double)propInfo.GetValue(x) <= request.Max));
            }
            else if (field == AgroFieldParam.Strontium)
            {
                query = min != null ? query.AsEnumerable().Where(x => x.StrontiumMin >= min).AsQueryable() : query;
                query = max != null ? query.AsEnumerable().Where(x => x.StrontiumMax <= max).AsQueryable() : query;
            }
            else if (field == AgroFieldParam.Bal)
            {
                query = min != null ? query.AsEnumerable().Where(x => x.Bal >= min).AsQueryable() : query;
                query = max != null ? query.AsEnumerable().Where(x => x.Bal <= max).AsQueryable() : query;
            }
            var dataList = query.AsEnumerable().ToList();
            var data = dataList.Select(entity =>
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
            });

            return Task.FromResult(new InfoAllAgrofieldReply()
            {
                Success = true,
                Data = { data }
            });
        }
    }
}