/// https://www.codewars.com/kata/582b079bbbbc74bed7000095

namespace Homework_08._04_Vectors_1
{
    public class Vector3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double Length { get { return Math.Sqrt(X * X + Y * Y + Z * Z); } }
    }
}
