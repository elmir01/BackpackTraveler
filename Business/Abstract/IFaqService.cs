using Core.Helpers.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFaqService
    {
        IResult Add(Faq faq);
        IResult Update(int id, Faq faq);
        IResult Delete(int id);
        IDataResult<List<Faq>> GetAll();
        IDataResult<Faq> Get(int id);
    }
}
