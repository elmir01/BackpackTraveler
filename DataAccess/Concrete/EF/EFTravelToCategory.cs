using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EF
{
    public class EFTravelToCategory : BaseRepository<TravelToCategory, AppDbContext>, ITravelToCategoryDal
    {
        public EFTravelToCategory(AppDbContext context) : base(context)
        {

        }

        //public List<TravelToCategoryDto> GetAllTravelsByCategoryId(int categoryId)
        //{
        //    var context = new AppDbContext();

        //}
    }
}
