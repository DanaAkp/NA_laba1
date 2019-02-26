using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NA_laba1
{
    class Program
    {
        static double determinant = 1;
        static int[] countX = new int[4];
        static double[] X = new double[4];
        static void Main(string[] args)
        {
            Random rand = new Random();
            const int n = 4;

            double[,] A1 = new double[n,n]{ { 2, 1, -1, 1 }, { 0.4, 0.5, 4, -8.5 }, { 0.3, -1, 1, 5.2 }, { 1, 0.2, 2.5, -1} };
            double[] B = new double[n] { 2.7, 21.9, -3.9, 9.9 };
            double[,] A = ExtendedMatrix(A1, B, n);
            double b = average(A, n);

            for (int i = 0; i < n; i++)
                countX[i] = i;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n + 1; j++)
                {
                   // A[i, j] = rand.Next(10);
                    Console.Write(A[i, j] + " ");
                }
                Console.WriteLine();
            }
            double[,] newA;

            Console.WriteLine("---------------------------------Метод Гаусса:---------------------------------");
            newA = gauss(A, n);
            Error(newA, n, b);
            obr(newA, n);

            //Console.WriteLine("---------------------------------Модификация метода Гаусса1---------------------------------");
            //  gaussModif1(A, n);
            //Error(newA, n, b);
            //obrModif1(newA, n);

            //Console.WriteLine("---------------------------------Модификация метода Гаусса2:---------------------------------");
            //newA = gaussModif2(A, n);
            //Error(newA, n, b);
            //obrModif2(newA, n);

            //Console.WriteLine("------------------------------Модификация метода Гаусса3:------------------------------------");
            //newA = gaussModif3(A, n);
            //Error(newA, n, b);
            //obrModif3(newA, n);


            //Error(LU(A, B, n), n, b);


            //MulMatrix(A,X,n,n,1);


            Console.ReadLine();
        }
        
        //A(n*m) * B(m*k)
        static void MulMatrix(double[,] A, double[,] B, int n, int m, int k)
        {
            double[,] C = new double[n, k];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < k; j++)
                {
                    for(int c = 0; c < m; c++)
                    {
                        C[i, j] += A[i, c] * B[c, j];
                    }
                }
            }
            Output(C, n,k);
        }

        #region Методы
        static void Output(double[,] A, int n,int m)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                    Console.Write(A[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("------------------------------------------------------------------");
        }
        static void Error(double[,] A,int n, double b)
        {
            double myB = average(A, n);
            Console.WriteLine(" B = " + b);
            Console.WriteLine("new B = " + myB);
            Console.WriteLine("inccuracy = " + Math.Abs(b - myB) / b);
            // Console.WriteLine("inccuracy = " + Math.Abs(b - myB) / myB);
            Console.WriteLine("------------------------------------------------------------------");
        }
        static double average(double[,] A, int n)
        {
            double delta = 0;
            for (int i = 0; i < n; i++)
            {
                delta += A[i, n] * A[i, n];
            }

            delta = Math.Sqrt(delta);
            return delta;
        }
        static double[,] Colum(double[,] A, int n, int a, int k) //а и к - индексы элементов,которые меняем м\у собой
        {
            for (int i = 0; i < n+1; i++)
            {
                double buf = A[a, i];
                A[a, i] = A[k, i];
                A[k, i] = buf;
            }
            return A;
        }
        static double[,] Row(double[,] A, int n, int a, int k)//а и к - номера столбцов которые меняем
        {
            for (int i = 0; i < n; i++)
            {
                double buf = A[i, a];
                A[i, a] = A[i, k];
                A[i, k] = buf;
            }
            int c = countX[a];
            countX[a] = countX[k];
            countX[k] = c;
            return A;
        }
        #endregion

        #region Гаусс
        static double[,] gauss(double[,] A, int n)
        {
            determinant = 1;
            for (int i = 0; i < n; i++)
            {
                double buf = A[i, i];
                determinant *= buf;
                for (int j = i; j < n + 1; j++) A[i, j] /= buf;

                for (int k = i + 1; k < n; k++)
                {
                    buf = A[k, i];
                    for (int j = i; j < n + 1; j++)
                        A[k, j] = buf * A[i, j] - A[k, j];
                }
            }
            Output(A, n,n+1);
            Console.WriteLine("Determinant = " + determinant);
            return A;
        }
        static double[] obr(double[,] A, int n)
        {
            double[] x = new double[n + 1];
            // int c = n-1;
            for (int i = n - 1; i >= 0; i--)
            {
                double buf = 0;
                for (int k = i; k < n; k++)
                {
                    //if(i!=0)
                    buf += A[i, k] * x[k];
                }
                x[i] = A[i, n] - buf;
                Console.Write("X"+i+" = "+x[i] + "\n");
                //c--;
            }
            return x;
        }
        #endregion

        #region 1 Модификация
        static double[,] gaussModif1(double[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double max = A[i, i];
                int index = i;
                for (int c = i; c < n; c++)
                    if (Math.Abs(max) < Math.Abs(A[i, c]))
                    { max = A[i, c]; index = c; }
                if(i!=index)
                    A = Row(A, n, i, index);
                double buf = A[i, i];
                for (int j = i; j < n + 1; j++) A[i, j] /= buf;

                for (int k = i + 1; k < n; k++)
                {
                    buf = A[k, i];
                    for (int j = i; j < n + 1; j++)
                        A[k, j] = buf * A[i, j] - A[k, j];
                }
            }
            Output(A, n,n+1);
            return A;
        }
        static double[,] obrModif1(double[,] A, int n)
        {
            double[] x = new double[n + 1];
            // int c = n-1;

            for (int i = n - 1; i >= 0; i--)
            {
                double buf = 0;
                for (int k = i; k < n; k++)
                {
                    //if(i!=0)
                    buf += A[i, k] * x[k];
                }
                x[i] = A[i, n] - buf;
                //Console.Write("X" + i + " = " + x[i] + "\n");
                //c--;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("X" + i + " = " + x[countX[i]] + "\n");
            }
            return A;
        }
        #endregion

        #region 2 Модификация
        static double[,] gaussModif2(double[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double max = A[i, i];
                int index = i;
                for (int c = i; c < n; c++)
                    if (Math.Abs(max) < Math.Abs(A[c, i]))
                    { max = A[c, i]; index = c; }
                if (i != index)
                    A = Colum(A, n, i, index);
                double buf = A[i, i];
                determinant *= buf;
                for (int j = i; j < n + 1; j++) A[i, j] /= buf;

                for (int k = i + 1; k < n; k++)
                {
                    buf = A[k, i];
                    for (int j = i; j < n + 1; j++)
                        A[k, j] = buf * A[i, j] - A[k, j];
                }
            }
            Output(A, n,n+1);
            Console.WriteLine("Determinant = " + determinant);
            return A;
        }
        static double[,] obrModif2(double[,] A, int n)
        {
            double[] x = new double[n + 1];
            // int c = n-1;
            for (int i = n - 1; i >= 0; i--)
            {
                double buf = 0;
                for (int k = i; k < n; k++)
                {
                    //if(i!=0)
                    buf += A[i, k] * x[k];
                }
                x[i] = A[i, n] - buf;
                Console.Write("X" + i + " = " + x[i] + "\n");
                //c--;
            }
            return A;
        }
        #endregion

        #region 3 Модификация
        static double[,] gaussModif3(double[,] A, int n)
        {
            for (int i = 0; i < n; i++)
            {
                double max = A[i, i];
                int row = i;
                int col = i;
                for (int c = i; c < n; c++)
                {
                    for (int j = i; j < n; j++)
                        if (Math.Abs(max) < Math.Abs(A[c, j]))
                        {
                            max = A[c, j];
                            row = c;
                            col = j;
                        }
                }
                if (row != i) A = Colum(A, n, row, i);
                if (col != i) A = Row(A, n, col, i);
                double buf = A[i, i];
                determinant *= buf;
                for (int j = i; j < n + 1; j++) A[i, j] /= buf;

                for (int k = i + 1; k < n; k++)
                {
                    buf = A[k, i];
                    for (int j = i; j < n + 1; j++)
                        A[k, j] = buf * A[i, j] - A[k, j];
                }
            }
            Output(A, n,n+1);
            Console.WriteLine("Determinant = " + determinant);
            return A;
        }
        static double[,] obrModif3(double[,] A, int n)
        {
            double[] x = new double[n + 1];
            // int c = n-1;

            for (int i = n - 1; i >= 0; i--)
            {
                double buf = 0;
                for (int k = i; k < n; k++)
                {
                    //if(i!=0)
                    buf += A[i, k] * x[k];
                }
                x[i] = A[i, n] - buf;
                //Console.Write("X" + i + " = " + x[i] + "\n");
                //c--;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write("X" + i + " = " + x[countX[i]] + "\n");
            }
            return A;
        }
        #endregion

        #region LU-методы
        static double[,] LU(double[,] A,double[] B, int n)
        {
            double[,] L = new double[n, n];
            double[,] U = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    double buf = 0;
                    if (i <= j)
                    {
                        for (int k = 0; k <= i - 1; k++)
                        {
                            buf += L[i, k] * U[k, j];
                        }
                        U[i, j] = A[i, j] - buf;
                    }
                    buf = 0;
                    if (i > j)
                    {
                        for (int k = 0; k <= j - 1; k++)
                        {
                            buf += L[i, k] * U[k, j];
                        }
                        L[i, j] = (A[i, j] - buf) / U[j, j];
                    }
                    if (i == j) L[i, j] = 1;
                }
            }
            Console.WriteLine("--------------Матрица L");
            OutputLU(L, n);
            Console.WriteLine("--------------Матрица U");
            OutputLU(U, n);
            determinant = 1;
            for(int i = 0; i < n; i++)
            {
                determinant *= U[i, i];
            }
            Console.WriteLine("determ U = "+ determinant);
            return Desicion(L, U, B, n);
        }
        static double[,] Desicion(double[,] L,double[,] U,double[] B,int n)
        {
            double[,] LY = ExtendedMatrix(L, B, n);
            LY = gauss(LY, n);
            double[,] UX = ExtendedMatrix(U, obr(LY,n), n);
            UX = gauss(UX, n);
            obr(UX, n);
            return UX;
        }
        static double[,] ExtendedMatrix(double[,] A, double[] B,int n)
        {
            double[,] newA = new double[n, n + 1];
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n + 1; j++)
                {
                    if (j == n) newA[i, j] = B[i];
                    else newA[i, j] = A[i, j];
                }
            }
            return newA;
        }
        static void OutputLU(double[,] A,int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(A[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("-----------------------------------------------------------------");
        }
        #endregion
    }
}
