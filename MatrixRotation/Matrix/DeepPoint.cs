namespace MatrixRotation.Matrix
{
    public class DeepPoint
    {
        public int Column { get; set; }
        public int Row { get; set; }

        public DeepPoint(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public override string ToString()
        {
            return $"Row: {Row}, Column: {Column}";
        }
    }
}
