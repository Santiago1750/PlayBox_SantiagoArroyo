namespace Tetris
{
    public class GameGrid
    {

        //Crear una matriz bidimencional
        //La primera dimensión es la fila y la segunda dimensi{on es la columna
        //line1
        private readonly int[,] grid;

        //Propiedades para la cantidad de filas y columnas
        //Indexador para facilitar el acceso a la matriz
        //line2
        public int Rows { get; }
        public int Columns { get; }

        //line3 
        public int this[int r, int c]
        {
            get => grid[r, c];
            set => grid[r, c] = value;
        }
        //Con está indexación se puede ingresar directamente a un objeto de Gamegrid
        //El constructor tomará la cantidad de filas y columnas de los parametros. 
        //Número de columnas
        //Número de filas
        //line4
        public GameGrid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            grid = new int[rows, columns];
        }
        //En el body, se guarda el número de fila, columnas y se inicializa la matriz. 
        
        //Metodos convenciales
        //Verificar si una fila y una columan están dentro de la matriz o no.
        //line5
        public bool IsInside(int r, int c)
        {
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        //Verificar si una celda está vacia o no 
        //Debe estar dentro de la matriz y el valor de entrada en la matriz deber ser cero.
        //line6
        public bool IsEmpty(int r, int c)
        {
            return IsInside(r, c) && grid[r, c] == 0;
        }
        //Verificar si una fila completa está llena
        //line7
        public bool IsRowFull(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }

            return true;
        }
        //Verificar si una fila está vacia
        //line8
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }

            return true;
        }
        //Cuando hay filas completas y deben borrarse
        //line9
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }
        //Cuando las filas de arriba deben moverse hacia abajo
        //line10
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r + numRows, c] = grid[r, c];
                grid[r, c] = 0;
            }
        }
        //Cuando borramos las filas completas
        //line11
        public int ClearFullRows()
        {
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r--)
            {
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }

            return cleared;
        }
    }
}
