namespace LinearRegression
{
    internal class LineEquation
    {
        public LineEquation(double a, double b)
        {
            A = a;
            B = b;
        }

        public double A { get; }
        public double B { get; }

        public override string ToString()
        {
            return $"Y={A}X+{B}";
        }
    }
}