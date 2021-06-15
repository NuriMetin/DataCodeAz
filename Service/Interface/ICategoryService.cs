using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interface
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void CreateCategory(Category category);
        void UpdateCategory(int id, Category category);
        void DeleteCategory(Category category);
    }
}
