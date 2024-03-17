
using Azure.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Diagnostics;
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

   
        static void Main(string[] args)
        {
 
            Helper.Print("Welcome to Turbo.Az!");
        l1:
            Enum menuOption = Helper.ChooseOption<MenuOptions>("Choose an Option: ");
            switch (menuOption)
            {
                // Car
                case MenuOptions.AddAd:
                    Console.Clear();
                    AddAnnouncement();
                    Console.ReadKey();
                    goto l1;
                case MenuOptions.EditAd:
                    Console.Clear();
                    EditAnnouncement();
                    Console.ReadKey();
                    goto l1;
                case MenuOptions.DeleteAd:
                    Console.Clear();
                    DeleteAnnouncement();
                    Console.ReadKey();
                    goto l1;
                case MenuOptions.SearchAdById:
                    Console.Clear();
                    GetAnnouncementById();
                    Console.ReadKey();
                  
                    goto l1;
                case MenuOptions.ShowAllAds:
                    Console.Clear();
                    GetAllAnnouncements();
                    Console.ReadKey();
              
                    goto l1;


                // Model
                case MenuOptions.AddModel:
                    Console.Clear();
                    AddNewModel();
               
                    goto l1;
                case MenuOptions.EditModel:
                    Console.Clear();
                    EditModel();
                    goto l1;
                case MenuOptions.DeleteModel:
                    Console.Clear();
                    DeleteModel();
                  
                    goto l1;
                case MenuOptions.SearchModelById:
                    Console.Clear();
                    GetModelById();
                    Console.ReadKey();
                    
                    goto l1;
                case MenuOptions.ShowAllModels:
                    Console.Clear();
                    GetAllModels();
                    Console.ReadKey();
                    
                    goto l1;


                //Brand

                case MenuOptions.AddBrand:
                    Console.Clear();
                    AddNewMarka();
                    db.SaveChanges();
                    
                    goto l1;
                case MenuOptions.EditBrand:
                    Console.Clear();
                    EditMarka();
                    
                    goto l1;
                case MenuOptions.DeleteBrand:
                    Console.Clear();
                    DeleteMarka();
                   
                    goto l1;
                case MenuOptions.SearchBrandById:
                    Console.Clear();
                    GetMarkaById();
                    Console.ReadKey();
                   
                    goto l1;
                case MenuOptions.ShowAllBrands:
                    Console.Clear();
                    GetAllMarka();
                    Console.ReadKey();
                  
                    goto l1;

                case MenuOptions.Exit:
                    Console.WriteLine();
                    Helper.Print("Thanks for using our Program!");
                    Environment.Exit(0);
                    break;
            }


        }

        public static void GetAllAnnouncements()
        {
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        join c in db.CarAnnouncements on m.Id equals c.ModelId
                        select new
                        {
                            c.Id,
                            c.Banner,
                            c.March,
                            c.GearBox,
                            c.FuelType,
                            ModelName = m.Name,
                            BrandName = b.Name,
                            c.Price,
                            c.Transmission

                        };

            if (query.Any())
            {
                foreach (var item in query)
                {
                    Console.WriteLine($"Info : Id-{item.Id}\nBanner-{item.Banner}\nYurush - {item.March}\n" +
                      $"Suretler qutusu novu - {item.GearBox}\nFuel Type - {item.FuelType}\nModeli - {item.ModelName}\n" +
                      $"Marka - {item.BrandName}\nQiymeti - {item.Price}\nOturucu novu - {item.Transmission}\n");
                }
            }
            else
            {
                Console.WriteLine("Elan siyahisi boshdu ! \n");
            }

            db.SaveChanges();




        }

        public static void GetAnnouncementById()
        {
            int announcementId;

            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        join c in db.CarAnnouncements on m.Id equals c.ModelId
                        select new
                        {
                            c.Id,
                            c.Banner,
                            c.March,
                            c.GearBox,
                            c.FuelType,
                            ModelName=m.Name,
                            BrandName= b.Name,
                            c.Price,
                            c.Transmission


                        };

            foreach (var item in query)
            {
                Console.WriteLine($"Id- {item.Id}");
            }


        l1:
            announcementId = Helper.ReadInt("Tapmaq istediyiniz Elanin Id-sini daxil edin", "Sehv daxil etdiniz");

            var announcement = query.FirstOrDefault(x => x.Id == announcementId);
            if (announcement == null)
            {
                Console.WriteLine("Bu Id-ile elan tapilmadi!");
                goto l1;
            }
            Console.WriteLine($"Info : Id-{announcement.Id}\n Banner-{announcement.Banner}\nYurush - {announcement.March}\n " +
                      $" Suretler qutusu novu - {announcement.GearBox}\n Fuel Type - {announcement.FuelType}\nModeli - {announcement.ModelName}\n " +
                      $" Marka - {announcement.BrandName}\nQiymeti - {announcement.Price}\n Oturucu novu - {announcement.Transmission}\n");

            db.SaveChanges();
            Console.WriteLine("\n");
        }

        private static void EditAnnouncement()
        {
            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        join c in db.CarAnnouncements on m.Id equals c.ModelId
                        select new
                        {
                            c.Id,
                            c.Banner,
                            c.March,
                            c.GearBox,
                            c.FuelType,
                            ModelName = m.Name,
                            BrandName = b.Name,
                            c.Price,
                            c.Transmission

                        };

            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Info : Id-{item.Id}, Banner-{item.Banner} Yurush - {item.March} " +
                    $" Suretler qutusu novu - {item.GearBox} Fuel Type - {item.FuelType},  Modeli - {item.ModelName} " +
                    $" Marka - {item.BrandName}  Qiymeti - {item.Price} Oturucu novu - {item.Transmission}");

            }
        l1:
            var announcementId = Helper.ReadInt("Duzelish etmek istediyiniz Elanin Id-sini daxil edin !", "Sehv daxil etdiniz");
            var announcement = db.CarAnnouncements.FirstOrDefault(m => m.Id == announcementId);
            if (announcement == null)
            {
                Console.WriteLine($"{announcementId} - Id li Elan siyahida yoxdur!");
                goto l1;
            }

        l2:
            var price = Helper.ReadDouble("Qiymeti daxil edin", "Sehv daxil etdiniz!");
            if (price < 300)
            {
                Console.WriteLine("Daxil etdiyiniz giymet minimumdan balacadi!");
                goto l2;
            }

            int modelId;


            foreach (var item in db.Models.ToList())
            {
                Console.WriteLine($"Id - {item.Id}, Adi - {item.Name}");
            }


        l3:




            modelId = Helper.ReadInt("Yeni model Id-sini daxil ele", "Sehv daxil etdiniz!");
            var model = db.Models.FirstOrDefault(m => m.Id == announcementId);
            if (model == null)
            {
                Console.WriteLine($"{modelId} - Id li Model siyahida yoxdur!");
                goto l2;
            }
        l4:
            var march = Helper.ReadInt("Avtomobilin yurushunu daxil edin!", "Sehv daxil etdiniz!");
            if (march < 0)
            {
                Console.WriteLine("Yurush 0-dan balaca ola bilmez!");
                goto l3;
            }

            foreach (var item in Enum.GetValues(typeof(FuelType)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            FuelType fuelType;
        l5:
            var fuelTypeNum = Helper.ReadInt("FuelType Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(FuelType), fuelTypeNum))
            {
                fuelType = (FuelType)fuelTypeNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l4;
            }

            GearBox gearBox;
        l6:
            foreach (var item in Enum.GetValues(typeof(GearBox)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            var gearBoxNum = Helper.ReadInt("Suretler qutusunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(GearBox), gearBoxNum))
            {
                gearBox = (GearBox)gearBoxNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l5;
            }

            Transmission transmission;
            foreach (var item in Enum.GetValues(typeof(Transmission)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
        l7:
            var transmissionNum = Helper.ReadInt("Oturucunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(Transmission), transmissionNum))
            {
                transmission = (Transmission)transmissionNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l6;
            }
        l8:
            BanType banner;
            foreach (var item in Enum.GetValues(typeof(BanType)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }

            var bannerNum = Helper.ReadInt("Ban novunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(BanType), bannerNum))
            {
                banner = (BanType)bannerNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l7;
            }


            
            announcement.Banner = banner;
            announcement.Transmission = transmission;
            announcement.Price = price;
            announcement.GearBox = gearBox;
            announcement.FuelType = fuelType;
            announcement.March = march;
            announcement.ModelId = modelId;
            announcement.LastModifiedAt = DateTime.Now;

            db.SaveChanges();

            foreach (var item in query.ToList())
            {

                Console.WriteLine($"Info : Id-{item.Id}, Banner-{item.Banner} Yurush - {item.March} " +
                  $" Suretler qutusu novu - {item.GearBox} Fuel Type - {item.FuelType},  Modeli - {item.ModelName} " +
                  $" Marka - {item.BrandName}  Qiymeti - {item.Price} Oturucu novu - {item.Transmission}");


            }


            Console.WriteLine("Deyisiklik edildi ! \n");


        }

        private static void DeleteAnnouncement() {

            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        join c in db.CarAnnouncements on m.Id equals c.ModelId
                        select new
                        {
                            c.Id,
                            c.Banner,
                            c.March,
                            c.GearBox,
                            c.FuelType,
                            ModelName = m.Name,
                            BrandName = b.Name,
                            c.Price,
                            c.Transmission

                        };




            if (!query.Any())
            {
                Console.WriteLine("Elan yoxdu !");
                return;
            }

            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Info : Id-{item.Id}, Banner-{item.Banner} Yurush - {item.March} " +
                    $" Suretler qutusu novu - {item.GearBox} Fuel Type - {item.FuelType},  Modeli - {item.ModelName} " +
                    $" Marka - {item.BrandName}  Qiymeti - {item.Price} Oturucu novu - {item.Transmission}");

            }




        l1:
            int AnnouncementId = Helper.ReadInt("Elanin Id-sini daxil edin", "Sehv daxil etdiniz");
            var announcement = db.CarAnnouncements.FirstOrDefault(m => m.Id == AnnouncementId);
            if (announcement is null)
            {
                Console.WriteLine($"{AnnouncementId}-li marka tapilmadi");
                goto l1;
            }

            db.CarAnnouncements.Remove(announcement);
            db.SaveChanges();
            Console.WriteLine("Silindi ! \n");




        }

        private static void AddAnnouncement()
        {
            int modelId;
            double price;
            int march;
            int fuelTypeNum;
            int gearBoxNum;
            int transmissionNum;
            int bannerNum;

            var query = from m in db.Models
                        join b in db.Brands on m.BrandId equals b.Id
                        select new
                        {
                            m.Id,
                            m.Name,
                            m.BrandId,
                            BrandName = b.Name
                        };

            Console.WriteLine("Elan yaratmaq ucun Modellerden birini secin");

            foreach (var item in query.ToList())
            {
                Console.WriteLine($"Id - {item.Id} Adi - {item.Name}  Marka - {item.BrandName}");
            }
        l1:
            modelId = Helper.ReadInt("Modelin Id-sini daxil edin", "Sehv daxil etdiniz");
            var model = query.FirstOrDefault(m => m.Id == modelId);
            if (model == null)
            {
                Console.WriteLine("Secdiyiniz Id-ile model yoxdur !");
                goto l1;
            }

        l2:
            price = Helper.ReadDouble("Qiymeti daxil edin", "Sehv daxil etdiniz!");
            if (price < 300)
            {
                Console.WriteLine("Daxil etdiyiniz giymet minimumdan balacadi!");
                goto l2;
            }
        l3:
            march = Helper.ReadInt("Avtomobilin yurushunu daxil edin!", "Sehv daxil etdiniz!");
            if (march < 0)
            {
                Console.WriteLine("Yurush 0-dan balaca ola bilmez!");
                goto l3;
            }


            foreach (var item in Enum.GetValues(typeof(FuelType)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            FuelType fuelType;
        l4:
            fuelTypeNum = Helper.ReadInt("FuelType Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(FuelType), fuelTypeNum))
            {
                fuelType = (FuelType)fuelTypeNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l4;
            }

            GearBox gearBox;
        l5:
            foreach (var item in Enum.GetValues(typeof(GearBox)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
            gearBoxNum = Helper.ReadInt("Suretler qutusunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(GearBox), gearBoxNum))
            {
                gearBox = (GearBox)gearBoxNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l5;
            }

            Transmission transmission;
            foreach (var item in Enum.GetValues(typeof(Transmission)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }
        l6:
            transmissionNum = Helper.ReadInt("Oturucunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(Transmission), transmissionNum))
            {
                transmission = (Transmission)transmissionNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l6;
            }
        l7:
            BanType banner;
            foreach (var item in Enum.GetValues(typeof(BanType)))
            {
                Console.WriteLine($"{(int)item}-{item}");
            }

            bannerNum = Helper.ReadInt("Ban novunu Secin:", "Sehv daxil etdiniz!");

            if (Enum.IsDefined(typeof(BanType), bannerNum))
            {
                banner = (BanType)bannerNum;
            }
            else
            {
                Console.WriteLine("Sehv secim etdiniz1 yeniden cehd edin!");
                goto l7;
            }

            CarAnnouncement announcement = new CarAnnouncement();
      
            announcement.Banner = banner;
            announcement.Transmission = transmission;
            announcement.Price = price;
            announcement.GearBox = gearBox;
            announcement.FuelType = fuelType;
            announcement.March = march;
            announcement.ModelId = modelId;
            announcement.CreatedAt = DateTime.Now;
            announcement.CreatedBy = 1;
            db.CarAnnouncements.Add(announcement);
            db.SaveChanges();

            Console.WriteLine("Yeni elan elave edildi !");
            Console.WriteLine($"Info : Id-{announcement.Id}, Banner-{announcement.Banner} Yurush - {announcement.March} " +
                $" Suretler qutusu novu - {announcement.GearBox} Fuel Type - {announcement.FuelType} Modeli - {announcement.ModelId}" +
                $"Marka - {model.Name}  Qiymeti - {announcement.Price} Oturucu novu - {announcement.Transmission}");
    
        }

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
            var brand = db.Brands.FirstOrDefault(m => m.Id == brandId);
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

            foreach (var item in query)
            {
                Console.WriteLine($"Id- {item.Id}");
            }


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

        private static void GetAllModels()
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
            int markaId = Helper.ReadInt("Markanin Id-sini daxil edin ", "Sehv daxil etdiniz ");
            var marka = db.Brands.FirstOrDefault(m => m.Id == markaId);
            if (marka is null)
            {
                Console.WriteLine($"{markaId}-li marka tapilmadi ");
                return;
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


            foreach (Brand item in db.Brands)
            {

                Console.WriteLine($"Id- {item.Id}, Name- {item.Name}");



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

