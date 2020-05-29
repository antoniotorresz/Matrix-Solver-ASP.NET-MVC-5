using Matrix_Solver.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;


namespace Matrix_Solver.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Suma()
        {
            ViewBag.mensaje = "";
            return View();
        }

        [HttpPost]
        public ActionResult Suma(FormCollection collection)
        {
            try
            {
                int aFil, aCol, bFil, bCol;

                aFil = Convert.ToInt32(collection["aFilas"]);
                aCol = Convert.ToInt32(collection["aColumnas"]);
                bFil = Convert.ToInt32(collection["bFilas"]);
                bCol = Convert.ToInt32(collection["bColumnas"]);

                if (aFil > 0 && aCol > 0 && bFil > 0 && bCol > 0)
                {
                    ViewBag.afilas = aFil;
                    ViewBag.acolumnas = aCol;
                    ViewBag.bfilas = bFil;
                    ViewBag.bcolumnas = bCol;

                    ViewBag.mensaje = "Ingrese los numeros de cada matriz";
                }
                else { ViewBag.mensaje = "DATOS POSITIVOS CAMARITA!!!"; }
            }
            catch (Exception e)
            {
                ViewBag.mensaje = "Ingrese todos los valores NUMERICOS de las filas y columnas.";
            }

            return View();
        }

        //GET Resultado 
        public ActionResult HacerSuma(FormCollection collection)
        {
            try
            {
                string key = "";
                string dato = "";
                string resultado = "";

                string aValues = "";
                string bValues = "";

                int[,] a = new int[Convert.ToInt32(collection["naf"]), Convert.ToInt32(collection["nac"])];
                int[,] b = new int[Convert.ToInt32(collection["nbf"]), Convert.ToInt32(collection["nbc"])];

                foreach (var _key in collection.AllKeys)
                {

                    key = Convert.ToString(_key);
                    dato = collection[Convert.ToString(key)];

                    string[] index; //Lo llenaremos con los valores del posterior split  
                    int i, j;

                    if (key.StartsWith("a"))
                    {
                        index = Regex.Split(key, @"\D+");// Le decimos que nos obenga el valor dentro del patron establecido.
                                                         //En este caso una posision despues de un

                        i = int.Parse(index[1]); //primer valor dentro del split
                        j = int.Parse(index[2]); //segundo valor dentro del split

                        a[i, j] = Convert.ToInt32(collection[key]);
                    }

                    if (key.StartsWith("b"))
                    {
                        index = Regex.Split(key, @"\D+");// Le decimos que nos obenga el valor dentro del patron establecido.
                                                         //En este caso una posision despues de un

                        i = int.Parse(index[1]); //primer valor dentro del split
                        j = int.Parse(index[2]); //segundo valor dentro del split

                        b[i, j] = Convert.ToInt32(collection[key]);
                    }

                }



                Utilidades u = new Utilidades();
                int[,] z = u.Sumar(a, b);

                if (z != null)
                {
                    for (int i = 0; i < z.GetLength(0); i++)
                    {
                        resultado += "[";
                        for (int j = 0; j < z.GetLength(1); j++)
                        {
                            aValues += Convert.ToString(a[i, j]);
                            bValues += Convert.ToString(b[i, j]);

                            resultado += Convert.ToString(z[i, j]) + " ";
                        }
                        resultado += "]<br/>";
                    }
                }
                else
                {
                    resultado = "Las matrices no son del mismo orden, por lo tanto no se puede realizar la suma.";
                }

                ViewBag.resultado = resultado;
            }
            catch (Exception e)
            {

            }
            return View();
        }

        //Multiplicacion GET
        public ActionResult Multiplicacion()
        {
            ViewBag.mensaje = "";
            return View();
        }


        [HttpPost]
        public ActionResult Multiplicacion(FormCollection collection)
        {
            try
            {
                int aFil, aCol, bFil, bCol;

                aFil = Convert.ToInt32(collection["aFilas"]);
                aCol = Convert.ToInt32(collection["aColumnas"]);
                bFil = Convert.ToInt32(collection["bFilas"]);
                bCol = Convert.ToInt32(collection["bColumnas"]);

                if (aFil > 0 && aCol > 0 && bFil > 0 && bCol > 0)
                {
                    ViewBag.afilas = aFil;
                    ViewBag.acolumnas = aCol;
                    ViewBag.bfilas = bFil;
                    ViewBag.bcolumnas = bCol;

                    ViewBag.mensaje = "Ingrese los numeros de cada matriz";
                }
                else { ViewBag.mensaje = "DATOS POSITIVOS CAMARITA!!!"; }
            }
            catch (Exception e)
            {
                ViewBag.mensaje = "Ingrese todos los valores NUMERICOS de las filas y columnas.";
            }

            return View();
        }

        public ActionResult HacerMulti(FormCollection collection)
        {
            try
            {
                string key = "";
                string dato = "";
                string resultado = "";

                string aValues = "";
                string bValues = "";

                int[,] a = new int[Convert.ToInt32(collection["naf"]), Convert.ToInt32(collection["nac"])];
                int[,] b = new int[Convert.ToInt32(collection["nbf"]), Convert.ToInt32(collection["nbc"])];

                foreach (var _key in collection.AllKeys)
                {

                    key = Convert.ToString(_key);
                    dato = collection[Convert.ToString(key)];

                    string[] index; //Lo llenaremos con los valores del posterior split  
                    int i, j;

                    if (key.StartsWith("a"))
                    {
                        index = Regex.Split(key, @"\D+");// Le decimos que nos obenga el valor dentro del patron establecido.
                                                         //En este caso una posision despues de un

                        i = int.Parse(index[1]); //primer valor dentro del split
                        j = int.Parse(index[2]); //segundo valor dentro del split

                        a[i, j] = Convert.ToInt32(collection[key]);
                    }

                    if (key.StartsWith("b"))
                    {
                        index = Regex.Split(key, @"\D+");// Le decimos que nos obenga el valor dentro del patron establecido.
                                                         //En este caso una posision despues de un

                        i = int.Parse(index[1]); //primer valor dentro del split
                        j = int.Parse(index[2]); //segundo valor dentro del split

                        b[i, j] = Convert.ToInt32(collection[key]);
                    }

                }



                Utilidades u = new Utilidades();
                int[,] z = u.Multiplicar(a, b);

                if (z != null)
                {
                    for (int i = 0; i < z.GetLength(0); i++)
                    {
                        resultado += "[";
                        for (int j = 0; j < z.GetLength(1); j++)
                        {
                            resultado += Convert.ToString(z[i, j]) + " ";
                        }
                        resultado += "]<br/>";
                    }
                }
                else
                {
                    resultado = "No cumple las condiciones, no se puede hacer la multiplicación.";
                }

                ViewBag.resultado = resultado;
            }
            catch (Exception e)
            {
                
            }

            return View();
        }

        public ActionResult Determinante()
        {
            ViewBag.mensaje = "";
            return View();
        }

        [HttpPost]
        public ActionResult Determinante(FormCollection collection)
        {
            try
            {
                int aFil, aCol;

                aFil = Convert.ToInt32(collection["aFilas"]);
                aCol = Convert.ToInt32(collection["aColumnas"]);

                if (aFil > 0 && aCol > 0)
                {
                    ViewBag.afilas = aFil;
                    ViewBag.acolumnas = aCol;

                    ViewBag.mensaje = "Ingrese los numeros de cada matriz";
                }
                else { ViewBag.mensaje = "DATOS POSITIVOS CAMARITA!!!"; }
            }
            catch (Exception e)
            {
                ViewBag.mensaje = "Ingrese todos los valores NUMERICOS de las filas y columnas.";
            }

            return View();
        }

        public ActionResult HacerDet(FormCollection collection)
        {
            string key = "";
            string dato = "";
            string resultado = "";

            double[,] a = new double[Convert.ToInt32(collection["naf"]), Convert.ToInt32(collection["nac"])];

            foreach (var _key in collection.AllKeys)
            {

                key = Convert.ToString(_key);
                dato = collection[Convert.ToString(key)];

                string[] index; //Lo llenaremos con los valores del posterior split  
                int i, j;

                if (key.StartsWith("a"))
                {
                    index = Regex.Split(key, @"\D+");// Le decimos que nos obenga el valor dentro del patron establecido.
                                                     //En este caso una posision despues de un

                    i = int.Parse(index[1]); //primer valor dentro del split
                    j = int.Parse(index[2]); //segundo valor dentro del split

                    a[i, j] = Convert.ToDouble(collection[key]);
                }
            }

            Utilidades u = new Utilidades();
            string z = u.Det(a);

            ViewBag.resultado = z;

            return View();
        }

    }
}