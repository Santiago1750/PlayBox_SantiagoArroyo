namespace Tetris
{
    public class Position
    {
        //Para representar un posición o celda en una cuadr{icula
        //Almacenar una fila y una columna
        //line1
        public int Row { get; set; }
        public int Column { get; set; }
        //Agregar un construcor simple
        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
