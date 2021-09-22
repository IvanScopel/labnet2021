using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp04.Data;
using tp04.Entities;

namespace tp04.Logic
{
    public class CategoriesLogic : BaseLogic, IABMLogic<Categories>
    {

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }
        public void Add(Categories newCategory)
        {
            context.Categories.Add(newCategory);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var categoryToDelete = context.Categories.Find(id);

            context.Categories.Remove(categoryToDelete);

            context.SaveChanges();
        }


        public void Update(Categories category)
        {
            var categoryToUpdate = context.Categories.Find(category.CategoryID);


            categoryToUpdate.CategoryName= category.CategoryName;
            categoryToUpdate.Description = category.Description;

            context.SaveChanges();
        }
    }
}
