namespace MatrixFeladat
{
    public class Matrix<T>
    {
        private T[,] elements;
        public Matrix(int rowCount, int columnCount)
        {
            if (rowCount <= 0 || columnCount <= 0)
                throw new ArgumentException("Dimensions must be positive.");

            elements = new T[rowCount, columnCount];
        }

        public int RowCount => elements.GetLength(0);
        public int ColumnCount => elements.GetLength(1);

        public void Populate(T value)
        {
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    elements[i, j] = value;
                }
            }
        }

        public override string ToString()
        {
            return string.Join("\n", Enumerable.Range(0, RowCount)
                .Select(r => "| " + string.Join(" , ", Enumerable.Range(0, ColumnCount).Select(c => elements[r, c]?.ToString())) + " |"));
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || row >= RowCount || col < 0 || col >= ColumnCount)
                    throw new IndexOutOfRangeException("Invalid index.");
                return elements[row, col];
            }
            set
            {
                if (row < 0 || row >= RowCount || col < 0 || col >= ColumnCount)
                    throw new IndexOutOfRangeException("Invalid index.");
                elements[row, col] = value;
            }
        }

        public static Matrix<T> Combine(Matrix<T> first, Matrix<T> second)
        {
            if (first.RowCount != second.RowCount || first.ColumnCount != second.ColumnCount)
                throw new ArgumentException("Matrix sizes do not match.");

            var result = new Matrix<T>(first.RowCount, first.ColumnCount);

            for (int i = 0; i < first.RowCount; i++)
            {
                for (int j = 0; j < first.ColumnCount; j++)
                {
                    dynamic a = first[i, j];
                    dynamic b = second[i, j];
                    result[i, j] = a + b;
                }
            }

            return result;
        }

        public void FlipVertical()
        {
            for (int i = 0; i < RowCount / 2; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    var temp = elements[i, j];
                    elements[i, j] = elements[RowCount - 1 - i, j];
                    elements[RowCount - 1 - i, j] = temp;
                }
            }
        }

        public void FlipHorizontal()
        {
            for (int j = 0; j < ColumnCount / 2; j++)
            {
                for (int i = 0; i < RowCount; i++)
                {
                    var temp = elements[i, j];
                    elements[i, j] = elements[i, ColumnCount - 1 - j];
                    elements[i, ColumnCount - 1 - j] = temp;
                }
            }
        }
    }
}