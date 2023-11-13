using BussinesLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrate
{
    public class AboutManager:IAboutService
    {
        IAboutDal _aboutdal;
        public AboutManager(IAboutDal aboutdal)
        {
            _aboutdal = aboutdal;
        }


     
        public About GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutdal.List();
        }

        public void TAdd(About t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(About t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            _aboutdal.Update(t);
        }
    }
}
