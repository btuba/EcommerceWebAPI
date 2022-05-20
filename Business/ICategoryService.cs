using Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface ICategoryService
    {
        Task<IList<CategoryDisplayResponse>> GetCategoriesByName(string name);
        Task AddCategory(object request);
        Task UpdateCategory(object request);
        Task DeleteCategory(int id);
        Task<CategoryDisplayResponse> GetCategoryById(int id);
        Task<IList<CategoryDisplayResponse>> GetCategories();
        Task<bool> IsCategoryExist(int id);
    }
}
