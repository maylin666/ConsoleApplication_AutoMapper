using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication_AutoMapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Model_1 model1 = new Model_1();
            Model_2 model2 = new Model_2();


            model1.Name = "王小明";
            model1.Year = 2016;
            model1.Date = DateTime.UtcNow.AddHours(8);


            Console.WriteLine("=== 轉換前 ===");
            Console.WriteLine("model1=name:{0}, year:{1}, date:{2}, type:{3}", model1.Name, model1.Year, model1.Date, model1.GetType());
            Console.WriteLine("model2=name:{0}, year:{1}, date:{2}, type:{3}", model2.Name, model2.Year, model2.Date, model2.GetType());

            model2 = ConvertModelToModel<Model_1, Model_2>(model1);

            Console.WriteLine("=== 轉換後 ===");
            Console.WriteLine("model1=name:{0}, year:{1}, date:{2}, type:{3}", model1.Name, model1.Year, model1.Date, model1.GetType());
            Console.WriteLine("model2=name:{0}, year:{1}, date:{2}, type:{3}", model2.Name, model2.Year, model2.Date, model2.GetType());

            Console.ReadLine();
        }
        static TModel_2 ConvertModelToModel<TModel_1, TModel_2>(TModel_1 list)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<TModel_1, TModel_2>().ReverseMap();
            });
            Mapper.Configuration.AssertConfigurationIsValid();

            var converted = Mapper.Map<TModel_2>(list);
            return converted;
        }
    }

    class Model_1
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public DateTime Date { get; set; }
    }

    class Model_2
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public DateTime Date { get; set; }
    }
}
