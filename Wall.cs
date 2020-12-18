namespace Wall
{
    public class Wall
    {
        // number of bricks in a row
        public int M { get; set; }

        // count rows
        public int N { get; set; }

        // an array that contains all rows
        /* an even line will be displayed in the following liхе
         *  _ _   _ _   _ _       _ _   _ _
         * |_|_| |_|_| |_|_| ... |_|_| |_|_|
         *  _ _   _ _   _ _       _ _   _ _
         * |_|_| |_|_| |_|_|     |_|_| |_|_|
         * 
         * an odd line will be displayed in the following line
         *  _   _ _   _ _       _ _   _
         * |_| |_|_| |_|_| ... |_|_| |_|
         * |_|  _ _   _ _       _ _  |_| 
         *     |_|_| |_|_|     |_|_| 
        */
        public Layer[] Layers { get; set; }
    }
}
