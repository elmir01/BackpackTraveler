using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EF;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FaqPageManager(IFaqPageDal faqPageDal) : IFaqService
    {
        private readonly IFaqPageDal _faqPageDal = faqPageDal;
        public IResult Add(Faq entity)
        {
            if (entity.Title.Length > 5)
            {
                _faqPageDal.Add(entity);
                Console.WriteLine("elave olundu");
                return new SuccessResult("Added");
            }
            else
            {
                Console.WriteLine("xeta");
                return new ErrorResult("xeta");
            }
        }

        public IResult Delete(int id)
        {
            Faq deleteFaqPage = null;
            Faq resultFaqPage = _faqPageDal.Get(a => a.IsDeleted == false && a.Id == id);
            if (resultFaqPage != null)
            {
                deleteFaqPage = resultFaqPage;
                deleteFaqPage.IsDeleted = true;
                _faqPageDal.Delete(deleteFaqPage);
                Console.WriteLine("deleted");
                return new SuccessResult("deleted");
            }
            else
            {
                Console.WriteLine("xetaa");
                return new ErrorResult("xeta");
            }
        }

        public IDataResult<Faq> Get(int id)
        {
            Faq getFaqPage = _faqPageDal.Get(a => a.Id == id);

            if (getFaqPage != null)
            {
                return new SuccessDataResult<Faq>(getFaqPage);
            }
            else
            {
                return new ErrorDataResult<Faq>("xeta");
            }
        }

        public IDataResult<List<Faq>> GetAll()
        {
            var faqs = _faqPageDal.GetAll(a => a.IsDeleted == false).ToList();
            if (faqs.Count > 0)
            {
                return new SuccessDataResult<List<Faq>>(faqs);
            }
            else
            {
                return new ErrorDataResult<List<Faq>>("xeta");
            }
        }

        public IResult Update(int id,Faq entity)
        {
            Faq updateFaqPage = _faqPageDal.Get(a => a.Id == id && a.IsDeleted == false);
            if (updateFaqPage != null)
            {
                updateFaqPage.Title = entity.Title;
                updateFaqPage.Description = entity.Description;
                _faqPageDal.Update(updateFaqPage);
                return new SuccessResult("Updated");
            }
            else
            {
                return new ErrorResult("xeta");
            }
        }


    
    }
}
