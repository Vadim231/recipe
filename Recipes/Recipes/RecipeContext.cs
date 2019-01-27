namespace Recipes
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class RecipeContext : DbContext
    {
        
        public RecipeContext()
            : base("name=RecipeContext")
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Material> Materials { get; set; }
        
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}