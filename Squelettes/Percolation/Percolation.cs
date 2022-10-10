using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            return _open[i, j];
        }

        private bool IsFull(int i, int j)
        {
            return _full[i,j];
        }

        public bool Percolate()
        {
           
            return _percolate;
           
        }
        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            if (i == 0 && j == 0)
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(0, 1),
                    new KeyValuePair<int, int>(1, 0)
                };
                return list;
            }

            else if (i == _size - 1 && j == 0)
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(i - 1, j),
                    new KeyValuePair<int, int>(i, j + 1)
                };
                return list;
            }

            else if (i == 0 && j == _size - 1)
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(i, j - 1),
                    new KeyValuePair<int, int>(i + 1, j)
                };
                return list;
            }

            else if (i == _size - 1 && j == _size - 1)
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(i - 1, j),
                    new KeyValuePair<int, int>(i, j - 1)
                };
                return list;
            }

            else if (i == 0)
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(i + 1, j),
                    new KeyValuePair<int, int>(i, j - 1),
                    new KeyValuePair<int, int>(i, j + 1)
                };
                return list;
            }

            else if (i == _size - 1)
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(i - 1, j),
                    new KeyValuePair<int, int>(i, j - 1),
                    new KeyValuePair<int, int>(i, j + 1)
                };
                return list;

            }

            else if (j == 0)
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(i + 1, j),
                    new KeyValuePair<int, int>(i - 1, j),
                    new KeyValuePair<int, int>(i, j + 1)
                };
                return list;
            }

            else if (j == _size - 1)
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(i + 1, j),
                    new KeyValuePair<int, int>(i - 1, j),
                    new KeyValuePair<int, int>(i, j - 1)
                };
                return list;
            }
            else
            {
                List<KeyValuePair<int, int>> list = new List<KeyValuePair<int, int>>
                {
                    new KeyValuePair<int, int>(i + 1, j),
                    new KeyValuePair<int, int>(i - 1, j),
                    new KeyValuePair<int, int>(i, j - 1),
                    new KeyValuePair<int, int>(i, j + 1)
                };
                return list;
            }
        }


            public void Recursion(int i, int j)
        {
            for (int k = 0; k < CloseNeighbors(i, j).Count-1; k++)
            {
                int x = CloseNeighbors(i, j)[k].Key;
                int y = CloseNeighbors(i, j)[k].Value;
                if (IsFull(x, y) == false && IsOpen(x, y))
                {
                    _full[x, y] = true;
                    if (x == _size - 1)
                    {
                        _percolate = true;
                    }
                    Recursion(x, y);
                }
               
            }
        }
            public void Open(int i, int j)
        {
            _open[i, j] = true;
            
            for (int k =0; k < CloseNeighbors(i , j).Count - 1; k++)
            {
                int x = CloseNeighbors(i, j)[k].Key;
                int y = CloseNeighbors(i, j)[k].Value;
                if (IsFull(x, y) || i == 0)
                {
                    _full[i, j] = true;
                    Recursion(i, j);
                    break;
                }
            }

        }
    }
}
