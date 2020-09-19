using System;
using System.Collections.Generic;
using System.Linq;

namespace _09_PokemonDontGo
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pokemons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int sumOfRemovedElements = 0;
            while (pokemons.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());

                if (index >= 0 && index < pokemons.Count)
                {
                    int elementToRemove = pokemons[index];
                    sumOfRemovedElements += elementToRemove;
                    pokemons.RemoveAt(index);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= elementToRemove)
                        {
                            pokemons[i] += elementToRemove;
                        }
                        else if (pokemons[i] > elementToRemove)
                        {
                            pokemons[i] -= elementToRemove;
                        }
                    }
                }

                else if (index < 0)
                {
                    int elementToRemove = pokemons[0];
                    sumOfRemovedElements += elementToRemove;
                    pokemons.RemoveAt(0);
                    pokemons.Insert(0, pokemons[pokemons.Count - 1]);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= elementToRemove)
                        {
                            pokemons[i] += elementToRemove;
                        }
                        else if (pokemons[i] > elementToRemove)
                        {
                            pokemons[i] -= elementToRemove;
                        }
                    }
                }

                else if (index >= pokemons.Count)
                {
                    int elementToRemove = pokemons[pokemons.Count - 1];
                    sumOfRemovedElements += elementToRemove;
                    pokemons.RemoveAt(pokemons.Count - 1);
                    pokemons.Add(pokemons[0]);
                    for (int i = 0; i < pokemons.Count; i++)
                    {
                        if (pokemons[i] <= elementToRemove)
                        {
                            pokemons[i] += elementToRemove;
                        }
                        else if (pokemons[i] > elementToRemove)
                        {
                            pokemons[i] -= elementToRemove;
                        }
                    }
                }
            }

            Console.WriteLine(sumOfRemovedElements);
        }
    }
}
