using Grpc.Core;
using GrpcAgroService.Data;
using GrpcAgroService.Models;
using GrpcAgroService.Services.common;
using System.Formats.Asn1;
using System.Globalization;

namespace GrpcAgroService.Services
{
    public class CsvConverterService : CsvConverter.CsvConverterBase
    {
        private readonly ServerDbContext _dbContext;
        private readonly ILogger<AgroFieldService> _logger;

        public CsvConverterService(ServerDbContext dbContext,
            ILogger<AgroFieldService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public override Task<CsvConverterReply> ConvertCsv(CsvConverterRequest request, ServerCallContext context)
        {
            // Read the CSV file and map the data to the entity model
            var inputModels = common.CsvHelper.ReadCsvData(request.CsvFilePath);
            var entities = inputModels.Select(model => InputModel.ConvertToAgroFieldModel(model)).ToList();

            // Save or update entities
            foreach (var field in entities)
            {
                var existingField = _dbContext.AgroFields.FindAsync(field.Name).Result;
                if (existingField != null)
                    existingField = field;
                else _dbContext.AgroFields.Add(field);
            }
            _dbContext.SaveChanges();

            // Return a response indicating success
            return Task.FromResult(new CsvConverterReply
            {
                Success = true
            });
        }

        public class InputModel
        {
            public string Name { get; set; }

            public string Aria { get; set; }
            public string Bal { get; set; }
            public string PH { get; set; }
            public string Gumus { get; set; }
            public string Azot { get; set; }
            public string Phosfor { get; set; }
            public string Kaliy { get; set; }
            public string Manganese { get; set; }
            public string Cobalt { get; set; }
            public string Copper { get; set; }
            public string Zinc { get; set; }
            public string Lead { get; set; }
            public string Cesium { get; set; }
            public string Strontium { get; set; }

            public static AgroFieldModel ConvertToAgroFieldModel(InputModel input)
            {
                var model = new AgroFieldModel
                {
                    Name = input.Name,
                    Aria = double.Parse(input.Aria.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Bal = int.Parse(input.Bal),
                    PH = double.Parse(input.PH.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Gumus = double.Parse(input.Gumus.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Azot = double.Parse(input.Azot.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Phosfor = double.Parse(input.Phosfor.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Kaliy = double.Parse(input.Kaliy.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Manganese = double.Parse(input.Manganese.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Cobalt = double.Parse(input.Cobalt.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Copper = double.Parse(input.Copper.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Zinc = double.Parse(input.Zinc.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Lead = double.Parse(input.Lead.Replace(',', '.'), CultureInfo.InvariantCulture),
                    Cesium = double.Parse(input.Cesium.Replace(',', '.'), CultureInfo.InvariantCulture)
                };
                //strontium can be in format "0.2-0.7" and just "0.3"
                if (input.Strontium.Contains('-'))
                {
                    var strontium = input.Strontium.Replace(',', '.').Split('-');
                    model.StrontiumMin = double.Parse(strontium[0], CultureInfo.InvariantCulture);
                    model.StrontiumMax = double.Parse(strontium[1], CultureInfo.InvariantCulture);
                }
                else
                {
                    model.StrontiumMin = double.Parse(input.Strontium, CultureInfo.InvariantCulture);
                    model.StrontiumMax = double.Parse(input.Strontium, CultureInfo.InvariantCulture);
                }
                return model;
            }
        }
    }
}