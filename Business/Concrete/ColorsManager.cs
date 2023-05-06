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
    public class ColorsManager : IColorsService
    {
        IColorsDal _colorsDal;

        public ColorsManager(IColorsDal colorsDal)
        {
            _colorsDal = colorsDal;
        }

        public void Add(Color color)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                _colorsDal.Add(color);
            }
        }

        public void Delete(Color color)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                _colorsDal.Delete(color);
            }
        }

        public List<Color> GetAll()
        {
            return _colorsDal.GetAll();
        }

        public List<Color> GetById(int colorId)
        {
            return _colorsDal.GetAll(c => colorId == colorId).ToList();
        }

        public void Update(Color color)
        {
            using (RentaCarContext context = new RentaCarContext())
            {
                _colorsDal.Update(color);
            }
        }
    }
}
