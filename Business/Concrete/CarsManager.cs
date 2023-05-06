using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarsManager : ICarsService
    {
        ICarsDal _carsDal;

        public CarsManager(ICarsDal carsDal)
        {
            _carsDal = carsDal;
        }

        public void Add(Car car)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                if (car.Description.Length >= 2 && car.DailyPrice > 0)
                {
                    _carsDal.Add(car);
                }
                else
                {
                    throw new Exception("Gerekli şartlar sağlanmıyor");
                }
            }
        }

        public void Delete(Car car)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                _carsDal.Delete(car);
            }
        }

        public List<Car> GetAll()
        {
            return _carsDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carsDal.GetAll(p => p.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carsDal.GetAll(p => p.ColorId == colorId).ToList();
        }

        public List<CarDetailDto> GetCarsDetails()
        {
            return _carsDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            if (car.Description.Length >= 2 && car.DailyPrice > 0)
            {
                _carsDal.Update(car);
            }
            else
            {
                throw new Exception("Gerekli şartlar sağlanmıyor");
            }
        }
    }
}
