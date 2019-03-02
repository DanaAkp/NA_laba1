using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NA_laba1
{
    class Program
    {
        //static int[] countX = new int[4];
        static double[] X = new double[4];
        static void Main(string[] args)
        {
            const int n = 4;
            //double[,] A1 = new double[n, n] { { 2, 1, -1, 1 }, { 0.4, 0.5, 4, -8.5 }, { 0.3, -1, 1, 5.2 }, { 1, 0.2, 2.5, -1 } };
            //double[] B = new double[n] { 2.7, 21.9, -3.9, 9.9 };

            double[,] A1 = new double[n, n] { { -0.86, 0.23, 0.18, 017 }, { 0.12, -1.14, 0.08, 0.09 }, { 0.16, 0.24, -1, -0.35 }, { 0.23, -0.08, 0.05, -0.75 } };
            double[] B = new double[n] { 1.42, 0.83, -1.21, -0.65 };
            double[,] A = Matrix.ExtendedMatrix(A1, B, n);
            Matrix.Output(A, n, n + 1);

            double[,] newA;
            #region Гаусс
            //Console.WriteLine("-----------------------------------Метод Гаусса:---------------------------------");
            //newA = Matrix.gauss(A, n);
            //Matrix.Error(B, Matrix.MulMatrix(A1, Matrix.obr(newA, n), n, n), n);
            #endregion
            #region Модификация 1
            //Console.WriteLine("-------------------------------Модификация метода Гаусса1---------------------------------");
            //newA = Matrix.gaussModif1(A, n);
            //Matrix.Error(B, Matrix.MulMatrix(A1, Matrix.obrModif1(newA, n), n, n), n);
            #endregion
            #region Модификация 2
            //Console.WriteLine("-------------------------------Модификация метода Гаусса2:---------------------------------");
            //newA = Matrix.gaussModif2(A, n);
            //Matrix.Error(B, Matrix.MulMatrix(A1, Matrix.obrModif2(newA, n), n, n), n);
            #endregion
            #region Модификация 3
            //Console.WriteLine("-------------------------------Модификация метода Гаусса3:------------------------------------");
            //newA = Matrix.gaussModif3(A, n);
            //Matrix.Error(B, Matrix.MulMatrix(A1, Matrix.obrModif3(newA, n), n, n), n);

            #endregion
            #region LU-разложение
            //Matrix.Error(B, Matrix.MulMatrix(A1, Matrix.LU(A, B, n), n, n), n);
            #endregion
            #region Обратная матрица
            //double[,] B_NEW = new double[n, 1];
            //for (int i = 0; i < n; i++) B_NEW[i, 0] = B[i];

            //double[,] E = new double[n, n];
            //for (int i = 0; i < n; i++)
            //    E[i, i] = 1;
            //double b_e = Matrix.average(E, n);
            //Matrix.MulMatrix(A1, Matrix.InverseMatrix(A1, n), n, n, n);
            //Matrix.Error(Matrix.MulMatrix(A1, Matrix.InverseMatrix(A1, n), n, n, n), n, b_e);
            #endregion
            #region Решение СЛАУ с помощью обр матрицы
            //Matrix.Error(B, Matrix.MulMatrix(A1, Matrix.MulMatrix(Matrix.InverseMatrix(A1, n), B, n, n), n, n), n);
            #endregion

            Console.ReadLine();
        }

       
    }
}
