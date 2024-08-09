using Business.Abstract;
using Core.Entities.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager(ICategoryDal categoryDal) : ICategoryService
    {
        private readonly ICategoryDal _categoryDal = categoryDal;
        public IResult Add(Category category)
        {
            if (category.CategoryName.Length > 5)
            {
                category.IsDeleted = false;
                _categoryDal.Add(category);
                return new SuccessResult("Added");
            }
            else
                return new ErrorResult("xeta");
        }

        public IResult Delete(int id)
        {
            Category deleteCategory = null;
            var result = _categoryDal.Get(a => a.IsDeleted == false && a.Id == id);
            if (result != null)
            {
                deleteCategory = result;
                deleteCategory.IsDeleted = true;
                _categoryDal.Delete(deleteCategory);
                Console.WriteLine("deleted");
                return new SuccessResult("deleted");
            }
            else
                Console.WriteLine("xetaa");
            return new ErrorResult("xeta");
        }

        public IDataResult<Category> Get(int id)
        {
            var result = _categoryDal.Get(t => t.Id == id && t.IsDeleted == false);
            if (result != null)
                return new SuccessDataResult<Category>(result, "loaded");
            else return new ErrorDataResult<Category>(result, "tapilmadi");
        }

        public IDataResult<List<Category>> GetAll()
        {
            var result = _categoryDal.GetAll(a => a.IsDeleted == false).ToList();
            if (result.Count > 0)
                return new SuccessDataResult<List<Category>>(result);
            else return new ErrorDataResult<List<Category>>("xeta baş verdi");
        }

        public IResult Update(int id, Category category)
        {
            var updateCategory = _categoryDal.Get(a => a.Id == id && a.IsDeleted == false);
            updateCategory.CategoryName = category.CategoryName;
            updateCategory.Url = category.Url;
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}
