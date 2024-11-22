using MatrixFeladat;

internal class Program
{
    static void Main(string[] args)
    {
        var myMatrix = new Matrix<int>(3, 3);
        myMatrix.Populate(7);
        Console.WriteLine("Initial matrix filled with 7:");
        Console.WriteLine(myMatrix);

        myMatrix[1, 1] = 42;
        Console.WriteLine("\nUpdated middle element to 42:");
        Console.WriteLine(myMatrix);

        myMatrix.FlipVertical();
        Console.WriteLine("\nFlipped vertically:");
        Console.WriteLine(myMatrix);

        myMatrix.FlipHorizontal();
        Console.WriteLine("\nFlipped horizontally:");
        Console.WriteLine(myMatrix);

        var secondMatrix = new Matrix<int>(3, 3);
        secondMatrix.Populate(5);

        var combinedMatrix = Matrix<int>.Combine(myMatrix, secondMatrix);
        Console.WriteLine("\nCombined matrix:");
        Console.WriteLine(combinedMatrix);
    }
}
