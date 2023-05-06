using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandsService
    {
        List<Brand> GetById(int brandId);
        List<Brand> GetAll();
        void Add(Brand car);
        void Delete(Brand car);
        void Update(Brand car);

    }
}
