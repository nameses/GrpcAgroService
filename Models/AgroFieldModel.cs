using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrpcAgroService.Models
{
    public class AgroFieldModel
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; set; }

        public double Aria { get; set; }
        public int Bal { get; set; }
        public double PH { get; set; }
        public double Gumus { get; set; }
        public double Azot { get; set; }
        public double Phosfor { get; set; }
        public double Kaliy { get; set; }
        public double Manganese { get; set; }
        public double Cobalt { get; set; }
        public double Copper { get; set; }
        public double Zinc { get; set; }
        public double Lead { get; set; }
        public double Cesium { get; set; }
        public double StrontiumMin { get; set; }
        public double StrontiumMax { get; set; }
    }
}