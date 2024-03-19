using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    public class Table
    {
        public int rows {  get; set; }
        public int columns { get; set; }
        public int[,] cells { get; set; }

        // Methods

        public void CreateTable(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.cells = new int[rows, columns];

            Random rnd = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    cells[i, j] = rnd.Next(0, 2);
                }
            }
        }

        public Table UpdateTable()
        {
            Table updatedTable = new Table(this.rows, this.columns);

            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    //count alive neighbors
                    int aliveNeighbors = 0;
                    for (int k = -1; k < 2; k++)
                    {
                        for (int l = -1; l < 2; l++)
                        {
                            if (i + k >= 0 & j + l >= 0 & i + k < this.rows & j + l < this.columns)
                            {
                                if (!(k == 0 & l == 0) & this.cells[i + k, j + l] == 1) aliveNeighbors++;
                            }
                        }
                    }
                    //check states of cells
                    switch (this.cells[i, j])
                    {
                        case 0:
                            updatedTable.cells[i, j] = aliveNeighbors == 3 ? 1 : 0;
                            break;
                        case 1:
                            updatedTable.cells[i, j] = (aliveNeighbors == 3 | aliveNeighbors == 2) ? 1 : 0;
                            break;
                    }
                }
            }

            return updatedTable;
        }

        // Constructors

        public Table(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.cells = new int[rows, columns];
        }
    }
}
