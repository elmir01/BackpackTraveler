using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutMeService
    {
        IResult Add(AboutMe aboutMe);
        IResult Update(int id, AboutMe aboutMe);
        IResult Delete(int id);
        IDataResult<List<AboutMe>> GetAll();
        IDataResult<AboutMe> Get(int id);
    }
}
