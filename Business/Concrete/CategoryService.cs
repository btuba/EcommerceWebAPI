using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        IMapper _mapper;
        ICategoryRepository _categoryRepository;
        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<int> AddCategory(object request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.Create(category);
            return category.Id;
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.Delete(id);
        }

        public async Task<IList<CategoryDisplayResponse>> GetCategories()
        {
            return _mapper.Map<IList<CategoryDisplayResponse>>(
                await _categoryRepository.GetAll());
        }

        /*public async Task<IList<CategoryDisplayResponse>> GetCategoriesByName(string name)
        {
            return _mapper.Map<IList<CategoryDisplayResponse>>(
                await _categoryRepository.GetCategoriesByName(name));
        }*/

        public async Task<CategoryDisplayResponse> GetCategoryById(int id)
        {
            return _mapper.Map<CategoryDisplayResponse>(
                await _categoryRepository.GetById(id));
        }

        public async Task<bool> IsCategoryExist(int id)
        {
            return await _categoryRepository.IsExist(id);
        }

        public async Task UpdateCategory(object request)
        {
            await _categoryRepository.Update(_mapper.Map<Category>(request));
        }
    }
}
