using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITravelService
    {
        IResult Add(Travel travel);
        IResult Update(int id, Travel travel);
        IResult Delete(int id);
        IDataResult<List<Travel>> GetAll();
        IDataResult<Travel> Get(int id);
    }
}
