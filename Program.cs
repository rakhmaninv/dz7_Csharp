

// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.


while (true)
{
    Console.Write("Type task number(47, 50 or 52): ");
    string task = Console.ReadLine() ?? "0";
    if (task == "47") 
    {
        Task47();
        break;
    }
    else if (task == "50") 
    {
        Task50();
        break;
    }
    else if (task == "52") 
    {
        Task52();
        break;
    }
    else Console.WriteLine("Incorrect task number");
}

void Task47() // Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
{
    int columns = Convert.ToInt32(UserNumberInput("type number of columnes in array: "));
    int rows = Convert.ToInt32(UserNumberInput("type number of rows in array: "));
    double[,] randArray = CreateArray(rows, columns);
    PrintArrayDouble(randArray);
}
void Task50() // Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента
              //            или же указание, что такого элемента нет.
{
    int columns = Convert.ToInt32(UserNumberInput("type number of columnes in array: "));
    int rows = Convert.ToInt32(UserNumberInput("type number of rows in array: "));
    double[,] array = CreateArray(rows, columns);
    PrintArrayDouble(array);
    FindElementValue(array);
}
void Task52()
{
    int columns = Convert.ToInt32(UserNumberInput("type number of columnes in array: "));
    int rows = Convert.ToInt32(UserNumberInput("type number of rows in array: "));
    int[,] array = Convert2DArrayToInt(CreateArray(rows, columns));
    PrintArrayInt(array);
    double[] avgArray = ColumnAverage(array);
    Console.WriteLine("Averege of columns");
    Print1DArray(avgArray);
}


double[,] CreateArray(int row, int col)
{
    double[,] array = new double[row,col];
    double minRandomValue = UserNumberInput("type minimum generated number: ");
    double maxRandomValue = UserNumberInput("type maximum generated number: ");

    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            array[i,j] = Math.Round(GetRandomNumber(minRandomValue, maxRandomValue), 2);
        }
    }
    return array;
}

double GetRandomNumber(double minimum, double maximum)
{
return new Random().NextDouble() * (maximum - minimum) + minimum;
}

double UserNumberInput(string msg)
{
    double userNumber;
    while (true)
    {
        try
        {
            Console.Write(msg);
            userNumber = Double.Parse(Console.ReadLine()!);
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Incorrect data entered");
        }
    }
    return userNumber;
}

void PrintArrayDouble(double[,] array)
{
    int row = array.GetLength(0);
    int col = array.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            Console.Write(array[i,j] + "\t");
        }
        Console.WriteLine();
    }
}

void PrintArrayInt(int[,] array)
{
    int row = array.GetLength(0);
    int col = array.GetLength(1);
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            Console.Write(array[i,j] + "\t");
        }
        Console.WriteLine();
    }
}

void FindElementValue(double[,] array)
{
    int colPosition = Convert.ToInt32(UserNumberInput("type column position: "));
    int rowPosition = Convert.ToInt32(UserNumberInput("type row position: "));
    try
    {
        Console.WriteLine("Your element is {0}", array[rowPosition -1, colPosition -1]);
    }
    catch (IndexOutOfRangeException)
    {
        Console.WriteLine("there is no element in position [{0}, {1}]", rowPosition, colPosition);
    }
}

int[,] Convert2DArrayToInt(double[,] arr)
{
    int col = arr.GetLength(1);
    int row = arr.GetLength(0);
    int[,] arrayInt = new int[row,col];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++)
        {
            arrayInt[i,j] = Convert.ToInt32(arr[i,j]);
        }
    }
    return arrayInt;
}

double[] ColumnAverage(int[,] arr)
{
    int col = arr.GetLength(1);
    int row = arr.GetLength(0);
    double[] averageArray = new double[col];
    for (int i = 0; i < col; i++)
    {
        for (int j = 0; j < row; j++)
        {
            averageArray[i] += arr[j,i];
        }
        averageArray[i] = Math.Round(averageArray[i] / row, 2);
    }
    return averageArray; //averageArray[i] = Math.Round(averageArray[i] / col, 2)
}
void Print1DArray(double[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        Console.Write(arr[i] + "\t");
    }
}