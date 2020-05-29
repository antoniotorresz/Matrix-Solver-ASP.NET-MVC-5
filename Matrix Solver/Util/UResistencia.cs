using Matrix_Solver.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Matrix_Solver.Util
{
    public class UResistencia
    {
        string DATA_PATH = "~/App_Data/RegistroResistencias.txt";
        public void GuardarResistencia(Resistencia r)
        {
            var data = r.ToString() + Environment.NewLine;
            var archivo = HttpContext
                .Current
                .Server
                .MapPath(this.DATA_PATH);

            File.AppendAllText(@archivo, data);
        }

        public List<Resistencia> ObtenerActivas()
        {
            List<Resistencia> lr = null;

            var archivo = HttpContext
                .Current
                .Server
                .MapPath(this.DATA_PATH);

            if (File.Exists(archivo))
            {
                lr = new List<Resistencia>();
                foreach (string line in File.ReadAllLines(archivo))
                {
                    Resistencia r = JsonConvert.DeserializeObject<Resistencia>(line);
                    lr.Add(r);
                }
            }

            return lr;
        }

        public void ActualizarTxt(List<Resistencia> lr)
        {

            var archivo = HttpContext
                .Current
                .Server
                .MapPath(this.DATA_PATH);

            if (File.Exists(archivo))
            {
                File.Delete(archivo);
                foreach (Resistencia r in lr)
                {
                    string linea = r.ToString() + Environment.NewLine;
                    File.AppendAllText(@archivo, linea);
                    linea = "";
                }
            }
        }
    }
}