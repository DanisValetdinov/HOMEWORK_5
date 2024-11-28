namespace std
{
    class DZ_TUMAKOV
    { 
        static void Main()
        {
            TASK2();
            TASK3();
            TASK5();
            TASK6();
        }

        static void TASK2()
        {
            /*Упражнение 6.2 Написать программу, реализующую умножению двух матриц, заданных в
            виде двумерного массива. В программе предусмотреть два метода: метод печати матрицы,
            метод умножения матриц (на вход две матрицы, возвращаемое значение – матрица).*/
            Console.WriteLine("Упражнение 6.2. Написать программу, умножающую две матрицы");
            int[][] matrix1 = new int[2][];
            int[][] matrix2 = new int[2][];
            matrix1[0] = new int[2];
            matrix1[1] = new int[2];
            matrix2[0] = new int[2];
            matrix2[1] = new int[2];
            matrix1[0][0] = 15;
            matrix1[0][1] = 22;
            matrix1[1][0] = 23;
            matrix1[1][1] = 55;
            matrix2[0][0] = 95;
            matrix2[0][1] = 3;
            matrix2[1][0] = 47;
            matrix2[1][1] = 17;
            MatrixPrint(MultiMatrix(matrix1, matrix2));
        }
        static void TASK3()
        {
            /*Упражнение 6.3 Написать программу, вычисляющую среднюю температуру за год. Создать
            двумерный рандомный массив temperature[12,30], в котором будет храниться температура
            для каждого дня месяца (предполагается, что в каждом месяце 30 дней). Сгенерировать
            значения температур случайным образом. Для каждого месяца распечатать среднюю
            температуру. Для этого написать метод, который по массиву temperature [12,30] для каждого
            месяца вычисляет среднюю температуру в нем, и в качестве результата возвращает массив
            средних температур. Полученный массив средних температур отсортировать по
            возрастанию.*/
            Console.WriteLine("Упражнение 6.3. Вычислить среднюю температуру за год");
            int[][] degreesMonths = new int[12][];
            Random rand = new Random();
            for (int i = 0; i < degreesMonths.Length; i++)
            {
                degreesMonths[i] = new int[30];
            }
            for (int i = 0; i < degreesMonths.Length; i++)
            {
                for (int j = 0; j < degreesMonths[i].Length; j++)
                {
                    degreesMonths[i][j] = rand.Next(-30, 100);
                }
            }
            double[] degrees = AvDegreesMonths(degreesMonths);
            Array.Sort(degrees);
            for (int i = 0; i < degrees.Length; i++)
            {
                Console.WriteLine(degrees[i]);
            }
        }

        static void TASK5()
        {
            /*Домашнее задание 6.2 Упражнение 6.2 выполнить с помощью коллекций
            LinkedList<LinkedList<T>>.*/
            Console.WriteLine("Домашнее задание 6.2. Сделать упр. 6.2. но используя LinkedList<LinkedList<T>>");
            LinkedList<LinkedList<int>> matrix1 = new LinkedList<LinkedList<int>>();
            LinkedList<LinkedList<int>> matrix2 = new LinkedList<LinkedList<int>>();
            LinkedList<int> matrixRes11 = new LinkedList<int>();
            LinkedList<int> matrixRes12 = new LinkedList<int>();
            LinkedList<int> matrixRes21 = new LinkedList<int>();
            LinkedList<int> matrixRes22 = new LinkedList<int>();
            matrixRes11.AddLast(1);
            matrixRes11.AddLast(2);
            matrixRes12.AddLast(3);
            matrixRes12.AddLast(4);
            matrixRes21.AddLast(5);
            matrixRes21.AddLast(6);
            matrixRes22.AddLast(7);
            matrixRes22.AddLast(8);
            matrix1.AddLast(matrixRes11);
            matrix1.AddLast(matrixRes12);
            matrix2.AddLast(matrixRes21);
            matrix2.AddLast(matrixRes22);
            MatrixPrint(MultiMatrix(matrix1, matrix2));
        }
        static void TASK6()
        {
            /*Домашнее задание 6.3 Написать программу для упражнения 6.3, использовав класс
            Dictionary<TKey, TValue>. В качестве ключей выбрать строки – названия месяцев, а в
            качестве значений – массив значений температур по дням.*/
            Console.WriteLine("Домашнее задание 6.3. Сделать упр.6.3. но используя словарь");
            Dictionary<string, int[]> months = new Dictionary<string, int[]>();
            Random rand = new Random();
            string[] Months = new string[] { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            foreach (string month in Months)
            {
                months.Add(month, new int[30]);
                for (int i = 0; i < months[month].Length; i++)
                {
                    months[month][i] = rand.Next(-67, 58);
                }
            }
            Dictionary<string, double> degreeses = AvDegreesMonths(months);
            foreach (string i in degreeses.Keys)
            {
                Console.WriteLine($"Месяц: {i}\nСреднее значение: {degreeses[i]}");
            }
        }
        static int[][] MultiMatrix(int[][] matrix1, int[][] matrix2)
        {
            int[][] resultMatrix = new int[2][];
            resultMatrix[0] = new int[2];
            resultMatrix[1] = new int[2];
            resultMatrix[0][0] = matrix1[0][0] * matrix2[0][0] + matrix1[0][1] * matrix2[1][0];
            resultMatrix[0][1] = matrix1[0][0] * matrix2[1][0] + matrix1[0][1] * matrix2[1][1];
            resultMatrix[1][0] = matrix1[1][0] * matrix2[0][0] + matrix1[1][0] * matrix2[1][0];
            resultMatrix[1][1] = matrix1[1][0] * matrix2[0][1] + matrix1[1][1] * matrix2[1][1];
            return resultMatrix;
        }
        static LinkedList<LinkedList<int>> MultiMatrix(LinkedList<LinkedList<int>> Matrix1, LinkedList<LinkedList<int>> Matrix2)
        {
            LinkedList<LinkedList<int>> resultMatrix = new LinkedList<LinkedList<int>>();
            LinkedList<int> matrix1Res = new LinkedList<int>();
            LinkedList<int> matrix2Res = new LinkedList<int>();
            matrix1Res.AddLast(Matrix1.First().First() * Matrix2.First().First() + Matrix1.First().Last() * Matrix2.Last().First());
            matrix1Res.AddLast(Matrix1.First().First() * Matrix2.Last().First() + Matrix1.First().Last() * Matrix2.Last().Last());
            matrix2Res.AddLast(Matrix1.Last().First() * Matrix2.First().First() + Matrix1.Last().First() * Matrix2.Last().First());
            matrix2Res.AddLast(Matrix1.Last().First() * Matrix2.First().Last() + Matrix1.Last().Last() * Matrix2.Last().Last());
            resultMatrix.AddLast(matrix1Res);
            resultMatrix.AddLast(matrix2Res);
            return resultMatrix;

        }
        static void MatrixPrint(int[][] matrix1)
        {
            int count = 0;
            for (int i = 0; i < matrix1.Length; i++)
            {
                for (int j = 0; j < matrix1[i].Length; j++)
                {
                    if (count % matrix1[i].Length == 0 && count != 0)
                    {
                        Console.Write("\n");
                    }
                    Console.Write($"{matrix1[i][j]} ");
                    count++;
                }
            }
        }
        static void MatrixPrint(LinkedList<LinkedList<int>> matrix)
        {
            foreach (LinkedList<int> matrixi in matrix)
            {
                Console.WriteLine($"{matrixi.First()} {matrixi.Last()}");
            }
        }
        static double[] AvDegreesMonths(int[][] degrees)
        {
            double[] temp = new double[degrees.Length];
            for (int i = 0; i < degrees.Length; i++)
            {
                temp[i] = degrees[i].Average();
            }
            return temp;
        }
        static Dictionary<string, double> AvDegreesMonths(Dictionary<string, int[]> degreeses)
        {
            Dictionary<string, double> avDegrees = new Dictionary<string, double>();
            foreach (string i in degreeses.Keys)
            {
                avDegrees.Add(i, degreeses[i].Average());
            }
            return avDegrees;
        }
    }
}
