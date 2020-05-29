using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Matrix_Solver.Util
{
    public class Utilidades
    {
        internal int[,] Sumar(int[,] a, int[,] b)
        {
            int[,] z = null;

            if (!(a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1)))
            {
                z = new int[a.GetLength(0), a.GetLength(1)];

                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < a.GetLength(1); j++)
                    {
                        z[i, j] = a[i, j] + b[i, j];
                    }
                }
            }
            return z;
        }

        internal int[,] Multiplicar(int[,] a, int[,] b)
        {
            int[,] z = null;
            if (a.GetLength(1) == b.GetLength(0)) // Aj = Bi
            {
                z = new int[a.GetLength(0), b.GetLength(1)];
                for (int i = 0; i < a.GetLength(0); i++)
                {
                    for (int j = 0; j < b.GetLength(1); j++)
                    {
                        int suma = 0;
                        for (int k = 0; k < a.GetLength(1); k++)
                        {
                            suma += (a[i, k] * b[k, j]);
                        }
                        z[i, j] = suma;
                    }
                }
            }
            return z;
        }

        internal string Det(double[,] a)
        {
            string resultado = "";
            if (a.GetLength(0) == a.GetLength(1))
            {
                resultado = "Determinante: " + Convert.ToString(ResolverDet(a));
            }
            else
            {
                resultado = "La matriz no cumple la condición (tiene que ser cuadrada)";
            }
            return resultado;
        }
        internal double ResolverDet(double[,] a)
        {
            double determinante = 0.0;
            int filas = a.GetLength(0);
            int columnas = a.GetLength(1);

            if ((filas == 1) && (columnas == 1)) // si solo hay un elemento en la matriz ese mismo es el determinante.
                return a[0, 0];

            int signo = 1;

            for (int i = 0; i < columnas; i++)
            {
                // Obtiene el adjunto de fila=0, columna=i, pero sin el signo.
                double[,] submatriz = Submatriz(a, filas, columnas, i);
                determinante = determinante + signo * a[0, i] * ResolverDet(submatriz);
                signo *= -1; 
            }
            return determinante;
        }
        /*
         @param double[,] a es la matriz original
         @param filas numero de filas de la matriz original
         @param columnas numero de columnas de la matriz original
         @param i la columna que se quiere eliminar junto con la fila 0
        */
        private double[,] Submatriz(double[,] a, int filas, int columnas, int i)
        {
            double[,] subMat = new double[filas -1, columnas -1];
            int counter = 0;

            for (int j = 0; j < columnas; j++)
            {
                if (j == i)
                {
                    continue;
                }
                for (int k = 1; k < filas; k++)
                {
                    subMat[k - 1, counter] = a[k, j]; //quitamos el la columna con el indice k
                }
                counter++;
            }
            return subMat;
        }
    }
}