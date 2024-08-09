using Business.Abstract;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class TravelToCategoryManager(ITravelToCategoryDal travelToCategoryDal) : ITravelToCategoryService
    {
        private readonly ITravelToCategoryDal _travelToCategoryDal = travelToCategoryDal;
        public IResult Add(int travelId, int categoryId)
        {
            var travelToCategory = new TravelToCategory();
            _travelToCategoryDal.Add(travelToCategory);
            return new SuccessResult("Added");
        }


    }
}
