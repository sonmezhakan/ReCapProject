using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System.Drawing;
using Color = Entities.Concrete.Color;

internal class Program
{
    private static void Main(string[] args)
    {
        CarsManager carsManager = new CarsManager(new EfCarDal());
        CarAdd(carsManager);
        CarUpdate(carsManager);
        CarDelete(carsManager);
        CarDtoList(carsManager);

        Line();

        BrandsManager brandsManager = new BrandsManager(new EfBrandDal());
        BrandAdd(brandsManager);
        BrandUpdate(brandsManager);
        BrandDelete(brandsManager);
        BrandGetAll(brandsManager);

        Line();

        ColorsManager colorsManager = new ColorsManager(new EfColorDal());
        ColorAdd(colorsManager);
        ColorUpdate(colorsManager);
        ColorDelete(colorsManager);
        ColorGetAll(colorsManager);
        

    }

    private static void Line()
    {
        Console.WriteLine("-------------------------------");
    }

    private static void ColorGetAll(ColorsManager colorsManager)
    {
        foreach (var color in colorsManager.GetAll())
        {
            Console.WriteLine("{0} {1}", color.ColorId, color.ColorName);
        }
    }

    private static void BrandGetAll(BrandsManager brandsManager)
    {
        foreach (var brand in brandsManager.GetAll())
        {
            Console.WriteLine("{0} {1}", brand.BrandId, brand.BrandName);
        }
    }

    private static void CarDtoList(CarsManager carsManager)
    {
        foreach (var carDto in carsManager.GetCarsDetails())
        {
            Console.WriteLine("{0} {1} {2} {3} {4}", carDto.CarId, carDto.BrandName, carDto.ColorName, carDto.DailyPrice, carDto.Description);
        }
    }

    private static void ColorDelete(ColorsManager colorsManager)
    {
        colorsManager.Delete(new Color
        {
            ColorId = 2
        });
    }

    private static void ColorUpdate(ColorsManager colorsManager)
    {
        colorsManager.Update(new Color
        {
            ColorId = 1,
            ColorName = "Black Matte"
        });
    }

    private static void ColorAdd(ColorsManager colorsManager)
    {
        colorsManager.Add(new Color
        {
            ColorName = "Red"
        });
    }

    private static void BrandDelete(BrandsManager brandsManager)
    {
        brandsManager.Delete(new Brand
        {
            BrandId = 2
        });
    }

    private static void BrandUpdate(BrandsManager brandsManager)
    {
        brandsManager.Update(new Brand
        {
            BrandId = 1,
            BrandName = "Range Over Sports"
        });
    }

    private static void BrandAdd(BrandsManager brandsManager)
    {
        brandsManager.Add(new Brand
        {
            BrandName = "Jaguar"
        });
    }

    private static void CarDelete(CarsManager carsManager)
    {
        carsManager.Delete(new Car
        {
            CarId = 2,
        });
    }

    private static void CarUpdate(CarsManager carsManager)
    {
        carsManager.Update(new Car
        {
            CarId = 10,
            BrandId = 2,
            ColorId = 2,
            ModelYear = 2010,
            DailyPrice = 75,
            Description = "TestingUpdate"
        });
    }

    private static void CarAdd(CarsManager carsManager)
    {
        carsManager.Add(new Car
        {
            BrandId = 3,
            ColorId = 1,
            ModelYear = 2023,
            DailyPrice = 400,
            Description = "Testing6"
        });
    }
}