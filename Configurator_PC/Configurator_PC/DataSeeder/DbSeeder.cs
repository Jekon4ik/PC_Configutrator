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
                    new Component { Id = 1, Name = "ASUS Prime B660M", TypeId = 1, Price = 500 },
                    new Component { Id = 2, Name = "MSI Z790 Tomahawk", TypeId = 1, Price = 700 },
                    new Component { Id = 3, Name = "Gigabyte B650 AORUS", TypeId = 1, Price = 600 },

                    // === CPUs ===
                    new Component { Id = 4, Name = "Intel Core i5-12400F", TypeId = 2, Price = 800 },
                    new Component { Id = 5, Name = "Intel Core i7-13700K", TypeId = 2, Price = 1200 },
                    new Component { Id = 6, Name = "Ryzen 5 7600X", TypeId = 2, Price = 1000 },

                    // === RAM ===
                    new Component { Id = 7, Name = "Corsair 16GB DDR4", TypeId = 3, Price = 300 },
                    new Component { Id = 8, Name = "Kingston Fury 32GB DDR5", TypeId = 3, Price = 500 },
                    new Component { Id = 9, Name = "G.Skill TridentZ 16GB DDR4", TypeId = 3, Price = 350 },

                    // === GPU ===
                    new Component { Id = 10, Name = "NVIDIA RTX 3060", TypeId = 4, Price = 1500 },
                    new Component { Id = 11, Name = "AMD RX 6700 XT", TypeId = 4, Price = 1400 },
                    new Component { Id = 12, Name = "NVIDIA RTX 4080", TypeId = 4, Price = 2500 },

                    // === Storage ===
                    new Component { Id = 13, Name = "Samsung 970 EVO Plus 1TB", TypeId = 5, Price = 400 },
                    new Component { Id = 14, Name = "Crucial MX500 500GB", TypeId = 5, Price = 300 },
                    new Component { Id = 15, Name = "WD Blue SN570 1TB", TypeId = 5, Price = 420 },

                    // === PSU ===
                    new Component { Id = 16, Name = "Corsair RM750", TypeId = 6, Price = 600 },
                    new Component { Id = 17, Name = "Cooler Master MWE 650", TypeId = 6, Price = 500 },
                    new Component { Id = 18, Name = "Seasonic Focus 850W", TypeId = 6, Price = 700 },

                    // === Case ===
                    new Component { Id = 19, Name = "NZXT H510", TypeId = 7, Price = 250 },
                    new Component { Id = 20, Name = "Cooler Master MB520", TypeId = 7, Price = 280 },
                    new Component { Id = 21, Name = "Fractal Design Meshify", TypeId = 7, Price = 300 },

                    // === CPU Coolers ===
                    new Component { Id = 22, Name = "Cooler Master Hyper 212", TypeId = 8, Price = 150 },
                    new Component { Id = 23, Name = "Noctua NH-D15", TypeId = 8, Price = 300 },
                    new Component { Id = 24, Name = "be quiet! Pure Rock 2", TypeId = 8, Price = 200 }
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
