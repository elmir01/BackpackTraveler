﻿using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(Category category);
        IResult Update(int id,  Category category);
        IResult Delete(int id);
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> Get(int id);
    }
}
