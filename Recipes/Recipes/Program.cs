using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();
            List<Material> materials = new List<Material>();
            
            Console.WriteLine("Выберите действие:\n1 -- Создание нового рецепта\n2 -- Получение списка всех рецептов");

            int choise = int.Parse(Console.ReadLine());

            switch (choise)
            {
                case 1:
                using (RecipeContext context = new RecipeContext())
                {
                    Console.WriteLine("введите имя рецепта: ");
                    Recipe recipe = new Recipe { Name = Console.ReadLine() };

                    Console.WriteLine("введите количество материалов: ");
                    int amount = int.Parse(Console.ReadLine());
                    Console.WriteLine("введите названия материалов: ");
                    for (int i = 0; i < amount; i++)
                    {
                        Material material = new Material
                        {
                            Name = Console.ReadLine()
                        };
                        recipe.Materials.Add(material);
                        context.Materials.Add(material);
                    }
                    context.Recipes.Add(recipe);
                    context.SaveChanges();
                    break;
                }
                case 2:
                using (RecipeContext context = new RecipeContext())
                {
                    recipes = context.Recipes.ToList();

                    foreach (var rec in recipes)
                    {
                        materials = rec.Materials.ToList();

                        Console.WriteLine("Рецепт: \n" + rec.Name + "\nМатериалы: ");

                        foreach (var mat in materials)
                        {
                            Console.WriteLine(mat.Name);
                        }
                    }
                    break;
                }
                default:
                    Console.WriteLine("Такого выбора нет");
                    break;
            }
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
