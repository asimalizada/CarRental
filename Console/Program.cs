using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BrandManager manager = new BrandManager(new EfBrandDal());

            var result = manager.GetAll();

            foreach (var r in result.Data)
            {
                System.Console.WriteLine(r.Name);
            }

        }
    }
}
