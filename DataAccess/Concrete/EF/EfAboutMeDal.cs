using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EF
{
    public class EfAboutMeDal : BaseRepository<AboutMe, AppDbContext>, IAboutMeDal
    {
        public EfAboutMeDal(AppDbContext context) : base(context)
        {

        }
    }
}
