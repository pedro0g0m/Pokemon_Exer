using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon
{
    class Move
    {
        /// <summary>
        /// Filtra o input do utilizador e regista so os steps validos
        /// </summary>
        /// <param name="path">movimentos introduzidos pelo utilizador</param>
        /// <param name="valideMoves">Steps validos</param>
        /// <returns>Numero de steps validos + out string com os movimentos validados</returns>
        public static int Sort(string path, out string valideMoves)
        {
            string aux = "";
            int steps = 0;
            const char n = 'N', s = 'S', e = 'E', o = 'O';

            foreach (var x in path.ToUpper())
            {
                switch (x)
                {
                    case n:
                        steps++;
                        aux = string.Concat(aux + "n");
                        break;
                    case s:
                        steps++;
                        aux = string.Concat(aux + "s");
                        break;
                    case e:
                        steps++;
                        aux = string.Concat(aux + "e");
                        break;
                    case o:
                        steps++;
                        aux = string.Concat(aux + "o");
                        break;
                }
            }

            valideMoves = aux;
            return steps;
        }

        /// <summary>
        /// Calcula o tamanho do Mapa
        /// </summary>
        /// <param name="steps">numero de steps registados</param>
        /// <returns>Um array bidimensional que suporte o numero de steps registados</returns>
        public static int[,] CreateMap(int steps)
        {
            int size = steps * 2 + 1;
            int[,] map = new int[size, size];

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    map[x, y] = 1;
                }
            }

            return map;
        }

        /// <summary>
        /// Regista as casas visitadas no mapa
        /// </summary>
        /// <param name="map">Mapa inicial</param>
        /// <param name="step">Length do comando valido</param>
        /// <param name="valideMoves">Comandos validos</param>
        /// <returns>O mapa com os movimentos registados</returns>
        public static int[,] Catch(int[,] map, int step, string valideMoves)
        {
            int x = step, y = step;
            const char n = 'N', s = 'S', e = 'E', o = 'O';

            map[x, y] = 0;  //Meio do map

            foreach (var k in valideMoves.ToUpper())
            {
                switch (k)
                {
                    case n:
                        y += 1;
                        map[x, y] = 0;
                        break;
                    case s:
                        y -= 1;
                        map[x, y] = 0;
                        break;
                    case e:
                        x += 1;
                        map[x, y] = 0;
                        break;
                    case o:
                        x -= 1;
                        map[x, y] = 0;
                        break;
                }

            }

            return map;
        }

        /// <summary>
        /// Conta o numero de pokemons apanhados
        /// </summary>
        /// <param name="map">Mapa do jogo</param>
        /// <returns>O numero de pokemos apanhados</returns>
        public static int Count(int[,] map)
        {
            int count = 0, size = (int)Math.Sqrt(map.Length);

            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (map[x, y] == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
}
