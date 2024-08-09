using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation.FluentValidation;
using Core.CrossCuttingConcern.Validation.FluentValidation;
using Core.Helpers.Results.Abstract;
using Core.Helpers.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AboutMeManager(IAboutMeDal aboutMeDal) : IAboutMeService

    {
        private readonly IAboutMeDal _aboutMeDal = aboutMeDal;
        [ValidationAspect<AboutMe>(typeof(AboutMeValidator))]
        public IResult Add(AboutMe entity)
        { 
         
                _aboutMeDal.Add(entity);
 
                return new SuccessResult("Added");
            
     
           
        }

        public IResult Delete(int id)
        {
            AboutMe deleteAboutMe = null;
            AboutMe resultAboutMe = _aboutMeDal.Get(a => a.IsDeleted == false && a.Id == id);
            if (resultAboutMe != null)
            {
                deleteAboutMe = resultAboutMe;
                deleteAboutMe.IsDeleted = true;
                _aboutMeDal.Delete(deleteAboutMe);
                Console.WriteLine("deleted");
                return new SuccessResult("deleted");
            }
            else
                Console.WriteLine("xetaa");
            return new ErrorResult("xeta");

        }
        public IDataResult<AboutMe> Get(int id)
        {
            AboutMe getAboutMe = _aboutMeDal.Get(a => a.Id == id&&a.IsDeleted==false);
            if (getAboutMe != null)
                return new SuccessDataResult<AboutMe>(getAboutMe, "loaded");
            else return new ErrorDataResult<AboutMe>(getAboutMe,"tapilmadi");
        }   
            
        public IDataResult<List<AboutMe>> GetAll()
        {
            var abouts = _aboutMeDal.GetAll(a => a.IsDeleted == false).ToList();
            if (abouts.Count > 0)
                return new SuccessDataResult<List<AboutMe>>(abouts);
            else return new ErrorDataResult<List<AboutMe>>("xeta bash verdi");
        }
        public IResult Update(int id,AboutMe entity)
        {
          
            var updateAboutMe = _aboutMeDal.Get(a=>a.Id == id&&a.IsDeleted==false);
            updateAboutMe.Title = entity.Title; 
            updateAboutMe.Description = entity.Description; 
            updateAboutMe.Url = entity.Url; 
            _aboutMeDal.Update(entity);
            return new SuccessResult();
        }
    }
}
