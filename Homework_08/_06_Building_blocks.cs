/// https://www.codewars.com/kata/55b75fcf67e558d3750000a3

namespace Homework_08._06_Building_blocks
{
    class Block
    {
        private int Width { get; }
        private int Length { get; }
        private int Height { get; }

        public Block(int[] dimensions)
        {
            this.Width = dimensions[0];
            this.Length = dimensions[1];
            this.Height = dimensions[2];
        }

        public int GetWidth()
        {
            return this.Width;
        }

        public int GetLength()
        {
            return this.Length;
        }

        public int GetHeight()
        {
            return this.Height;
        }

        public int GetVolume()
        {
            return this.Width * this.Length * this.Height;
        }

        public int GetSurfaceArea()
        {
            return
              2 * this.Width * this.Length +
              2 * this.Length * this.Height +
              2 * this.Width * this.Height;
        }
    }
}
