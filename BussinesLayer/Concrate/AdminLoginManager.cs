using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLayer.Concrate
{
    
    public class AdminLoginManager
    {
        Repository<Admin> adminrepo = new Repository<Admin>();
        
        public void AdminSignUp(Admin p)
        {
        
             adminrepo.Insert(p);
        }

       

        public List<Admin> GetAll()
        {
            return adminrepo.List();
        }

       

    }
        
}
