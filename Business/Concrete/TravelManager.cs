using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
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
    public class TravelManager(ITravelDal travelDal) : ITravelService
    {
        private readonly ITravelDal _travelDal = travelDal;
        [ValidationAspect<Travel>(typeof(TravelValidator))]
        public IResult Add(Travel entity)
        {
           
               
                _travelDal.Add(entity);
                return new SuccessResult("Added");
            
            
            
        }

        public IResult Delete(int id)
        {
            Travel deleteTravel = null;
            Travel resultTravel = _travelDal.Get(a => a.IsDeleted == false && a.Id == id);
            if (resultTravel != null)
            {
                deleteTravel = resultTravel;
                deleteTravel.IsDeleted = true;
                _travelDal.Delete(deleteTravel);
                Console.WriteLine("deleted");
                return new SuccessResult("deleted");
            }
            else
                
            return new ErrorResult("xeta");
        }

        public IDataResult<Travel> Get(int id)
        {
            Travel getTravel = _travelDal.Get(t => t.Id == id && t.IsDeleted == false);
            if (getTravel != null)
                return new SuccessDataResult<Travel>(getTravel, "loaded");
            else return new ErrorDataResult<Travel>(getTravel, "tapilmadi");
        }

        public IDataResult<List<Travel>> GetAll()
        {
            var travels = _travelDal.GetAll(a => a.IsDeleted == false).ToList();
            if (travels.Count > 0)
                return new SuccessDataResult<List<Travel>>(travels);
            else return new ErrorDataResult<List<Travel>>("xeta baş verdi");
        }

        public IResult Update(int id, Travel travel)
        {
            var updateTravel = _travelDal.Get(a => a.Id == id && a.IsDeleted == false);
            updateTravel.Title = travel.Title;
            updateTravel.Description = travel.Description;
            updateTravel.Url = travel.Url;
            _travelDal.Update(travel);
            return new SuccessResult();
        }
    }
}
