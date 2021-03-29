using System;

namespace Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nO Ash vai comecar a sua aventura!!\n\nUsando os pontos cardeais diz-lhe para onde ele deve ir :");

            // 1 -> recolher dados
            string valideMoves, moves = Console.ReadLine();

            // 2 -> Validar
            int steps = Move.Sort(moves, out valideMoves);

            // 3 -> Criar o mapa |+| 4 -> Registar movimentos no mapa
            int[,] map = Move.Catch(Move.CreateMap(steps), steps, valideMoves);

            // 5-> Contar o numero de Pokemons apanhados
            int pokedex = Move.Count(map);


            Console.WriteLine("O Ash deu {0} passos. E apanhou {1} pokemons.", steps, pokedex);

        }
    }
}
