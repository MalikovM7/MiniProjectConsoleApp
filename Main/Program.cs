
using Microsoft.EntityFrameworkCore.Query;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Turbo.az.Entity;
using Turbo.Az.Entities;
using Turbo.Az.Extensions;
using Turbo.Az.Models.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Turbo.Az.Main
{
    internal class Program
    {


        static AppDbContext db = new AppDbContext();

        static List<Brand> markaList = new();
        static List<Models.Entities.Model> modelList = new();
        static List<CarAnnouncement> announcementList = new();
        static void Main(string[] args)
        {






            int answer;
            do
            {
                Console.WriteLine("1 - Marka elave ele: ");
                Console.WriteLine("2 - Marka sil :");
                Console.WriteLine("3 - Marka hamisin goster: ");
                Console.WriteLine("4 - Marka Id ile axtar: ");
                Console.WriteLine("5 - Marka duzelish ele: ");


                Console.WriteLine("6 - Model elave ele: ");
                Console.WriteLine("7 - Model sil: ");
                Console.WriteLine("8 - Butun modelleri goster: ");
                Console.WriteLine("9 - Model Id ile axtar: ");
                Console.WriteLine("10 - Modele duzelish ele: ");


                Console.WriteLine("11 - Elan elave ele: ");

                answer = Helper.ReadInt("Siayhidan secim edin", "Sehv daxil etdiniz");


                switch (answer)
                {
                    case 1:
                        AddNewMarka();
                        break;
                    case 2:
                        DeleteMarka();
                        break;
                    case 3:
                        GetAllMarka();
                        break;
                    case 4:
                        GetMarkaById();
                        break;
                    case 5:
                        EditMarka();
                        break;
                    case 6:
                        AddNewModel();
                        break;
                    case 7:
                        DeleteModel();
                        break;
                    case 8:
                        GetAllModedls();
                        break;
                    case 9:
                        GetModelById();
                        break;
                    case 10:
                        EditModel();
                        break;
                    //case 11:
                    //    AddAnouncement();
                    //    break;

                    default:
                        break;
                }

            } while (true);


        }


        //    private static void AddAnouncement()
        //    {
        //        int modelId;
        //        double price;
        //        int march;
        //        int fuelTypeNum;
        //        int gearBoxNum;
        //        int transmissionNum;
        //        int bannerNum;

        //        var query = from m in db.Models
        //                    join b in db.Brands on m.BrandId equals b.Id
        //                    select new
        //                    {
        //                        m.Id,
        //                        m.Name,
        //                        m.BrandId,
        //                        BrandName = b.Name
        //                    };

        //        Console.WriteLine("Elan yaratmaq ucun Modellerden birini secin");

        //        foreach (var item in query)
        //        {
        //            Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.BrandName}");
        //        }
        //    l1:
        //        modelId = Helper.ReadInt("Modelin Id-sini daxil edin", "Sehv daxil etdiniz");
        //        var model = query.FirstOrDefault(m => m.Id == modelId);
        //        if (model == null)
        //        {
        //            Console.WriteLine("Secdiyiniz Id-ile model yoxdur !");
        //            goto l1;
        //        }

        //    l2:
        //        price = Helper.ReadDouble("Qiymeti daxil edin", "Sehv daxil etdiniz!");
        //        if (price < 300)
        //        {
        //            Console.WriteLine("Daxil etdiyiniz giymet minimumdan balacadi!");
        //            goto l2;
        //        }
        //    l3:
        //        march = Helper.ReadInt("Avtomobilin yurushunu daxil edin!", "Sehv daxil etdiniz!");
        //        if (march < 0)
        //        {
        //            Console.WriteLine("Yurush 0-dan balaca ola bilmez!");
        //            goto l3;
        //        }


        //        foreach (var item in Enum.GetValues(typeof(FuelType)))
        //        {
        //            Console.WriteLine($"{(int)item}-{item}");
        //        }
        //        FuelType fuelType;
        //    l4:
        //        fuelTypeNum = Helper.ReadInt("FuelType Secin:", "Sehv daxil etdiniz!");

        //        if (Enum.IsDefined(typeof(FuelType), fuelTypeNum))
        //        {
        //            fuelType = (FuelType)fuelTypeNum;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
        //            goto l4;
        //        }

        //        GearBox gearBox;
        //    l5:
        //        foreach (var item in Enum.GetValues(typeof(GearBox)))
        //        {
        //            Console.WriteLine($"{(int)item}-{item}");
        //        }
        //        gearBoxNum = Helper.ReadInt("Suretler qutusunu Secin:", "Sehv daxil etdiniz!");

        //        if (Enum.IsDefined(typeof(GearBox), gearBoxNum))
        //        {
        //            gearBox = (GearBox)gearBoxNum;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
        //            goto l5;
        //        }

        //        Transmission transmission;
        //        foreach (var item in Enum.GetValues(typeof(Transmission)))
        //        {
        //            Console.WriteLine($"{(int)item}-{item}");
        //        }
        //    l6:
        //        transmissionNum = Helper.ReadInt("Oturucunu Secin:", "Sehv daxil etdiniz!");

        //        if (Enum.IsDefined(typeof(Transmission), transmissionNum))
        //        {
        //            transmission = (Transmission)transmissionNum;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
        //            goto l6;
        //        }
        //    l7:
        //        BanType banner;
        //        foreach (var item in Enum.GetValues(typeof(BanType)))
        //        {
        //            Console.WriteLine($"{(int)item}-{item}");
        //        }

        //        bannerNum = Helper.ReadInt("Ban novunu Secin:", "Sehv daxil etdiniz!");

        //        if (Enum.IsDefined(typeof(BanType), bannerNum))
        //        {
        //            banner = (BanType)bannerNum;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
        //            goto l7;
        //        }

        //        CarAnnouncement announcement = new CarAnnouncement();
        //        announcement.Banner = banner;
        //        announcement.Transmission = transmission;
        //        announcement.Price = price;
        //        announcement.GearBox = gearBox;
        //        announcement.FuelType = fuelType;
        //        announcement.March = march;
        //        announcement.ModelId= modelId;

        //        db.CarAnnouncements.Add(announcement);


        //        Console.WriteLine("Yeni elan elave edildi !");
        //        Console.WriteLine($"Info : Id-{announcement.Id}, Banner-{announcement.Banner} Yurush - {announcement.March} " +
        //            $" Suretler qutusu novu - {announcement.GearBox} Fuel Type - {announcement.FuelType} Modeli - {announcement.ModelId}" +
        //            $"Marka - {model.Name}  Qiymeti - {announcement.Price} Oturucu novu - {announcement.Transmission}");
        //        Console.Clear();
        //    }

        private static void EditModel()
        {
            int modelId;
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BrandName = b.Name
                        };
            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.BrandName}");
            }
        l1:
            modelId = Helper.ReadInt("Duzelish etmek istediyiniz modelin Id-sini daxil edin !", "Sehv daxil etdiniz");
            var model = db.Models.FirstOrDefault(m => m.Id == modelId);
            if (model == null)
            {
                Console.WriteLine($"{modelId} - Id li Model siyahida yoxdur!");
                goto l1;
            }

            string newModelName = Helper.ReadString("Modelin yeni adini daxil edin!", "Sehv daxil etdiniz");

            foreach (var item in db.Brands.ToList())
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }

            int brandId;

        l2:
            brandId = Helper.ReadInt("Yeni markanin Id-sini daxil ele", "Sehv daxil etdiniz!");
            Brand brand = db.Brands.FirstOrDefault(m => m.Id == brandId);
            if (brand == null)
            {
                Console.WriteLine($"{brandId} - Id li Marka siyahida yoxdur!");
                goto l2;
            }

            model.BrandId = brand.Id;
            model.Name = newModelName;
            db.SaveChanges();

            Console.WriteLine("Deyisiklik edildi ! \n");


        }

        private static void GetModelById()
        {
            int modelId;

            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BrandName = b.Name
                        };
        l1:
            modelId = Helper.ReadInt("Tapmaq istediyiniz Modelin Id-sini daxil edin", "Sehv daxil etdiniz");

            var model = query.FirstOrDefault(x => x.Id == modelId);
            if (model == null)
            {
                Console.WriteLine("Bu Id-ile model tapilmadi!");
                goto l1;
            }

            Console.WriteLine($"Id - {model.Id} Adi - {model.Name}  Markasi - {model.BrandName}");
            Console.WriteLine("\n");

        }

        private static void GetAllModedls()
        {
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BrandName = b.Name
                        };
            if (!query.Any())
            {
                Console.WriteLine("Model siyahisi boshdur!");
                return;
            }

            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.BrandName}");
            }

            Console.WriteLine("\n");

        }

        private static void DeleteModel()
        {
            int deleteId;
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BrandName = b.Name
                        };
            Console.WriteLine();
            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.BrandName}");
            }
        l1:
            deleteId = Helper.ReadInt("Silmek istediyiniz modelin Id-sini daxil edin!", "Sehv daxil etdiniz !");
             var model = db.Models.FirstOrDefault(m => m.Id == deleteId);
            if (model is null)
            {
                Console.WriteLine("Daxil etdiyiniz Id- ile model movcud deil!");
                goto l1;
            }

            db.Models.Remove(model);
            db.SaveChanges();
            Console.WriteLine("Silindi!\n");

        }

        private static void AddNewModel()
        {
            if (!db.Brands.Any())
            {
                Console.WriteLine("Marka siyahisi boshdu ! Zehmet olmasa Marka elave edin!");
                return;
            }

            string modelName = Helper.ReadString("Modelin adini daxil edin :", "Sehv daxil etdiniz");
            int markaId;
            foreach (var item in db.Brands)
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }

        l1:
            markaId = Helper.ReadInt("Modelin Markasini secin !", "Sehv daxil etdiniz !");
            var marka = db.Brands.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine("Sehv Id- daxil etmisiz!");
                goto l1;
            }

            Models.Entities.Model model = new Models.Entities.Model();
            model.BrandId = markaId;
            model.Name = modelName;
            model.CreatedAt = DateTime.Now;
            model.CreatedBy = 1;
            db.Models.Add(model);

            db.SaveChanges();
            Console.WriteLine("Elave olundu ! \n");
            
        }

        private static void EditMarka()
        {
            int markaId;
            foreach (Brand item in db.Brands)
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }
        l1:
            markaId = Helper.ReadInt("Deyisiklik etmek istediyiniz Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Brand marka = db.Brands.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
                goto l1;

            }

            string newMarkaName = Helper.ReadString("Markanin yeni adini daxil edin:", "Sehv daxil etdiniz");
            marka.Name = newMarkaName;

            Console.WriteLine("Deyisiklik edildi! \n");

            db.SaveChanges();
        }

        private static void GetMarkaById()
        {
            int markaId = Helper.ReadInt("Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Brand marka = db.Brands.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
            }

            Console.WriteLine($"Id - {marka.Id} Adi - {marka.Name} \n");
        }

        private static void DeleteMarka()
        {
            if (!db.Brands.Any())
            {
                Console.WriteLine("Siyahida marka yoxdu !");
                return;
            }

        l1:
            int markaId = Helper.ReadInt("Markanin Id-sini daxil edin", "Sehv daxil etdiniz");
            Brand marka = db.Brands.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi");
                goto l1;
            }

            db.Brands.Remove(marka);
            db.SaveChanges();
            Console.WriteLine("Silindi ! \n");

        }

        private static void GetAllMarka()
        {
            if (db.Brands.Any())
            {
                foreach (var item in db.Brands)
                {
                    Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
                }
            }
            else
            {
                Console.WriteLine("Marka siyahisi boshdu ! \n");
            }

            db.SaveChanges();

        }

        private static void AddNewMarka()
        {


            string markaName;
        l1:
            Console.Write("Markanin adini daxil edin: ");
            markaName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(markaName) || markaName.Length < 2)
            {
                Console.WriteLine("Bosh olmaz ve minimum simvol 3 eded !");
                goto l1;
            }

            Brand marka = new Brand()
            {
                Name = markaName,
            };
            marka.CreatedAt = DateTime.Now;
            marka.CreatedBy = 1;

            db.Brands.Add(marka);
            db.SaveChanges();
            Console.WriteLine("Elave olundu! \n");


        }
    }
}

