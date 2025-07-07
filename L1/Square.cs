namespace L1
{ 
    /// <summary> 
    /// Class that defines one part of the blob. AlreadyIterated and Answer are false by default 
    /// </summary> 
    public class Square
    {
        public int CoordinateX { get; set; }
        public int CoordinateY { get; set; }
        public int Colour { get; set; } // 0 - green, 1 - red, 2 - yellow 
        public bool AlreadyIterated { get; set; } = false;
        public bool Answer { get; set; } = false;
        /// <summary> 
        /// constructor for the class 
        /// </summary> 
        /// <param name="coordinateX"></param> 
        /// <param name="coordinateY"></param> 
        /// <param name="colour"></param> 
        public Square(int coordinateX, int coordinateY, int colour)
        {
            this.CoordinateX = coordinateX;
            this.CoordinateY = coordinateY;
            this.Colour = colour;
        }
    }
}