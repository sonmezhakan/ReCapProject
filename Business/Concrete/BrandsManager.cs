using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandsManager : IBrandsService
    {
        IBrandsDal _brandsDal;

        public BrandsManager(IBrandsDal brandsDal)
        {
            _brandsDal = brandsDal;
        }

        public void Add(Brand brand)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                _brandsDal.Add(brand);
            }
        }

        public void Delete(Brand brand)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                _brandsDal.Delete(brand);
            }
        }

        public List<Brand> GetAll()
        {
            return _brandsDal.GetAll();
        }

        public List<Brand> GetById(int brandId)
        {
            return _brandsDal.GetAll(b => b.BrandId == brandId).ToList();
        }

        public void Update(Brand brand)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                _brandsDal.Update(brand);
            }
        }
    }
}
