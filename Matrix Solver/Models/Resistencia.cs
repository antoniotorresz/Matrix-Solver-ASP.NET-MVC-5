using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Matrix_Solver.Models
{
    public class Resistencia
    {
        public string Id { get; set; }
        public string Banda1 { get; set; }
        public string Banda2 { get; set; }
        public string Banda3 { get; set; }
        public string Tolerancia { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}