using Configurator_PC.Data;
using Configurator_PC.Models;
using System;
using System.Linq;

namespace Configurator_PC.DataSeeder
{
    public static class DbSeeder
    {
        public static void Seed(DataContext context)
        {
            if (!context.Components.Any())
            {
                var components = new List<Component>
                {
                    // === Motherboards ===
                    new Component { Id = 1, Name = "ASUS Prime B660M", TypeId = 1, Price = 349, ImageUrl="https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/35/3511322/Plyta-glowna-ASUS-Prime-B660M-K-01-front.jpg" },
                    new Component { Id = 2, Name = "MSI Z790 Tomahawk", TypeId = 1, Price = 985.71m, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/42/4294568/Plyta-glowna-MSI-MAG-Z790-Tomahawk-WiFi-front.jpg" },
                    new Component { Id = 3, Name = "Gigabyte B650 AORUS", TypeId = 1, Price = 799, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/64/6459524/Plyta-glowna-GIGABYTE-B650-AORUS-ELITE-AX-V2-front.jpg" },

                    // === CPUs ===
                    new Component { Id = 4, Name = "Intel Core i5-12400F", TypeId = 2, Price = 473.12m, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/34/3438344/Procesor-INTEL-Core-i5-12400F-front.jpg" },
                    new Component { Id = 5, Name = "Intel Core i7-13700K", TypeId = 2, Price = 1200, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/33/3317278/Procesor-INTEL-Core-i7-12700KF-01-front.jpg" },
                    new Component { Id = 6, Name = "Ryzen 5 7600X", TypeId = 2, Price = 655.32m, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/63/6327950/Procesor-AMD-Ryzen-5-8500G-front.jpg" },

                    // === RAM ===
                    new Component { Id = 7, Name = "Corsair 16GB DDR4", TypeId = 3, Price = 199, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/21/2109893/Pamiec-RAM-CORSAIR-Vengeance-LPX-16-GB-3200-MHz-front.jpg"},
                    new Component { Id = 8, Name = "Kingston Fury 32GB DDR5", TypeId = 3, Price = 389, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/42/4233744/Pamiec-RAM-KINGSTON-Fury-Beast-32GB-5600MHz-front-3.jpg" },
                    new Component { Id = 9, Name = "G.Skill Trident Z 16GB DDR4", TypeId = 3, Price = 132, ImageUrl="https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/25/2562638/Pamiec-Ram-G.SKILL-Tridentz-RGB-DDR4-2X16GB-front.jpg" },

                    // === GPU ===
                    new Component { Id = 10, Name = "NVIDIA RTX 3060", TypeId = 4, Price = 1267, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/30/3031224/Karta-graficzna-GIGABYTE-GeForce-RTX-3060-Gaming-OC-12GB-box.jpg"},
                    new Component { Id = 11, Name = "AMD RX 6700 XT", TypeId = 4, Price = 1109, ImageUrl="https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/55/5544200/Karta-graficzna-GIGABYTE-Radeon-RX-7600-Gaming-01-front.jpg" },
                    new Component { Id = 12, Name = "NVIDIA RTX 4080", TypeId = 4, Price = 3400, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/62/6239412/Karta-graficzna-GIGABYTE-GeForce-RTX-4070-Super-Windforce-OC-12G-frontowe.jpg" },

                    // === Storage ===
                    new Component { Id = 13, Name = "Samsung 970 EVO Plus 1TB", TypeId = 5, Price = 397, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/27/2798359/Dysk-SSD-SAMSUNG-980-1TB-M-bez-linku.jpg" },
                    new Component { Id = 14, Name = "Crucial MX500 500GB", TypeId = 5, Price = 199, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/11/1180321/Dysk-CRUCIAL-MX500-500GB-SSD-front.jpg"},
                    new Component { Id = 15, Name = "WD Blue SN570 1TB", TypeId = 5, Price = 249, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/56/5688840/Dysk-WD-Blue-SN580-1TB-przod-wersja-2.jpg" },

                    // === PSU ===
                    new Component { Id = 16, Name = "Corsair RM750", TypeId = 6, Price = 639, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/68/6871442/Zasilacz-CORSAIR-RM750X-750W-80-Plus-Gold-Bialy-skos.jpg"},
                    new Component { Id = 17, Name = "Cooler Master MWE 650", TypeId = 6, Price = 386, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/25/2541202/Zasilacz-COOLER-MASTER-MWE-Gold-V2-650W-profil-1.jpg" },
                    new Component { Id = 18, Name = "Seasonic Focus 850W", TypeId = 6, Price = 449, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/63/6341960/Zasilacz-GIGABYTE-UD850GM-PG5W-850W-tyl-dol-bok.jpg" },

                    // === Case ===
                    new Component { Id = 19, Name = "NZXT H510", TypeId = 7, Price = 369, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/42/4293628/Obudowa-NZXT-H5-Elite-Flow-skos-lewy.jpg" },
                    new Component { Id = 20, Name = "Cooler Master MB520", TypeId = 7, Price = 480, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/40/4018860/Obudowa-COOLER-MASTER-MasterBox-520-Mesh-Bialy-front.jpg" },
                    new Component { Id = 21, Name = "Fractal Design Meshify", TypeId = 7, Price = 914.87m, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/40/4086902/Obudowa-FRACTAL-DESIGN-Meshify-2-RGB-TG-Light-Ting-Czarny-front-bok-lewy.jpg" },

                    // === CPU Coolers ===
                    new Component { Id = 22, Name = "Cooler Master Hyper 212", TypeId = 8, Price = 149.99m, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/67/6709488/Chlodzenie-CPU-COOLER-MASTER-Hyper-212-Black-front.jpg" },
                    new Component { Id = 23, Name = "Noctua NH-D15", TypeId = 8, Price = 451, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/34/3437552/Chlodzenie-NOCTUA-NH-D15-front.jpg" },
                    new Component { Id = 24, Name = "be quiet! Pure Rock 2", TypeId = 8, Price = 189.99m, ImageUrl = "https://prod-api.mediaexpert.pl/api/images/gallery/thumbnails/images/23/2348874/Chlodzenie-CPU-BE-QUIET-Pure-Rock-2-BK007-front-lewy.jpg" }
                };

                context.Components.AddRange(components);
                context.SaveChanges();

                var parameters = new List<ComponentParameter>
                {
                    // === Motherboards (LGA1700, AM5; ATX, DDR4/5, PCIe 4.0, SATA, NVMe) ===
                    new() { ComponentId = 1, ParameterNameId = 1, Value = "LGA1700" },
                    new() { ComponentId = 1, ParameterNameId = 2, Value = "ATX" },
                    new() { ComponentId = 1, ParameterNameId = 3, Value = "DDR4" },
                    new() { ComponentId = 1, ParameterNameId = 15, Value = "PCIe 4.0" },
                    new() { ComponentId = 1, ParameterNameId = 16, Value = "SATA" },

                    new() { ComponentId = 2, ParameterNameId = 1, Value = "LGA1700" },
                    new() { ComponentId = 2, ParameterNameId = 2, Value = "ATX" },
                    new() { ComponentId = 2, ParameterNameId = 3, Value = "DDR5" },
                    new() { ComponentId = 2, ParameterNameId = 15, Value = "PCIe 5.0" },
                    new() { ComponentId = 2, ParameterNameId = 16, Value = "NVMe" },

                    new() { ComponentId = 3, ParameterNameId = 1, Value = "AM5" },
                    new() { ComponentId = 3, ParameterNameId = 2, Value = "ATX" },
                    new() { ComponentId = 3, ParameterNameId = 3, Value = "DDR5" },
                    new() { ComponentId = 3, ParameterNameId = 15, Value = "PCIe 5.0" },
                    new() { ComponentId = 3, ParameterNameId = 16, Value = "SATA" },

                    // === CPUs ===
                    new() { ComponentId = 4, ParameterNameId = 1, Value = "LGA1700" },
                    new() { ComponentId = 5, ParameterNameId = 1, Value = "LGA1700" },
                    new() { ComponentId = 6, ParameterNameId = 1, Value = "AM5" },

                    // === RAM ===
                    new() { ComponentId = 7, ParameterNameId = 3, Value = "DDR4" },
                    new() { ComponentId = 8, ParameterNameId = 3, Value = "DDR5" },
                    new() { ComponentId = 9, ParameterNameId = 3, Value = "DDR4" },

                    // === GPU ===
                    new() { ComponentId = 10, ParameterNameId = 15, Value = "PCIe 4.0" },
                    new() { ComponentId = 10, ParameterNameId = 19, Value = "550" },

                    new() { ComponentId = 11, ParameterNameId = 15, Value = "PCIe 4.0" },
                    new() { ComponentId = 11, ParameterNameId = 19, Value = "600" },

                    new() { ComponentId = 12, ParameterNameId = 15, Value = "PCIe 5.0" },
                    new() { ComponentId = 12, ParameterNameId = 19, Value = "750" },

                    // === Storage ===
                    new() { ComponentId = 13, ParameterNameId = 16, Value = "NVMe" },
                    new() { ComponentId = 14, ParameterNameId = 16, Value = "SATA" },
                    new() { ComponentId = 15, ParameterNameId = 16, Value = "NVMe" },

                    // === PSU ===
                    new() { ComponentId = 16, ParameterNameId = 20, Value = "750" },
                    new() { ComponentId = 17, ParameterNameId = 20, Value = "650" },
                    new() { ComponentId = 18, ParameterNameId = 20, Value = "850" },

                    // === Case ===
                    new() { ComponentId = 19, ParameterNameId = 2, Value = "ATX" },
                    new() { ComponentId = 20, ParameterNameId = 2, Value = "ATX" },
                    new() { ComponentId = 21, ParameterNameId = 2, Value = "ATX" },

                    // === CPU Coolers ===
                    new() { ComponentId = 22, ParameterNameId = 1, Value = "LGA1700" },
                    new() { ComponentId = 23, ParameterNameId = 1, Value = "LGA1700" },
                    new() { ComponentId = 24, ParameterNameId = 1, Value = "AM5" }
                };

                context.ComponentParameters.AddRange(parameters);
                context.SaveChanges();
            }
        }
    }
}
