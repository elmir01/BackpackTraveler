using Core.Helpers.Results.Abstract;

namespace Business.Abstract
{
    public interface ITravelToCategoryService
    {
        IResult Add(int travelId, int categoryId);
        //IDataResult<List<TravelToCategoryDto>> GetAllTravelByCategoryId(int categoryId);
    }
}
