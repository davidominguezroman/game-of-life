using Raylib_cs;
using System.Numerics;
namespace GameOfLife;

class Program
{
    static void Main(string[] args)
    {
        // Configuración de las celdas
        const int gridAncho = 100; // Ancho en celdas del grid
        const int gridAlto = 100; // Alto en celdas del grid
        const int tamanoCelda = 8; // tamaño de cada celda
        const int espaciado = 1; // espaciado entre celdas

        // Tamaño total del grid
        int gridTotalAncho = gridAncho * tamanoCelda + (gridAncho - 1) * espaciado;
        int gridTotalAlto = gridAlto * tamanoCelda + (gridAlto - 1) * espaciado;

        // Tamaño de la ventana (para que sea más grande que el grid)
        const int margen = 40;
        int ventanaAncho = gridTotalAncho + margen;
        int ventanaAlto = gridTotalAlto + margen;

        // Offset para centrar el grid
        int offsetX = (ventanaAncho - gridTotalAncho) / 2;
        int offsetY = (ventanaAlto - gridTotalAlto) / 2;

        // Estado del grid (false = muerta, true = viva)
        bool[,] grid = new bool[gridAncho, gridAlto];

        // Dibujamos la ventana
        Raylib.InitWindow(ventanaAncho, ventanaAlto, "Conway's Game of Life");
        Raylib.SetTargetFPS(60);

        while (!Raylib.WindowShouldClose())
        {
            // TO-DO: escribir la lógica de clicks para activar y desactivar celdas
            // TO-DO: Escribir la lógica de la simulación
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            // Para dibujar el grid, hacemos dos bucles for "nesteados" de la siguiente forma:
            // posX siempre será el offsetX más una cantidad, x, que se irá incrementando
            // Lo mismo para posY

            for (int x = 0; x < gridAncho; x++)
            {
                for(int y = 0; y < gridAlto; y++)
                {
                    // Cálculo de las posiciones de cada celda
                    int posX = offsetX + x * (tamanoCelda + espaciado);
                    int posY = offsetY + y * (tamanoCelda + espaciado);

                    // Dibujamos Color según el estado de la celda
                    // Si la celda arroja bool 1 (true) se pone blanca, si no se pone gris oscuro
                    Color color = grid[x, y] ? Color.White : Color.DarkGray;

                    // Dibujamos la celda como un rectángulo de lados iguales a tamanoCelda
                    Raylib.DrawRectangle(posX, posY, tamanoCelda, tamanoCelda, color);
                }
            }

            Raylib.EndDrawing();

        }
    }
}
