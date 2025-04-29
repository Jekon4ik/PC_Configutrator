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
            if (!context.ComponentTypes.Any())
            {
                // 1. Create ComponentTypes
                var componentTypes = new[]
                {
                    new ComponentType { Id = 1, Name = "Motherboard" },
                    new ComponentType { Id = 2, Name = "Processor" },
                    new ComponentType { Id = 3, Name = "RAM" },
                    new ComponentType { Id = 4, Name = "Graphics Card" },
                    new ComponentType { Id = 5, Name = "Storage" },
                    new ComponentType { Id = 6, Name = "Power Supply" },
                    new ComponentType { Id = 7, Name = "Case" }
                };
                context.ComponentTypes.AddRange(componentTypes);

                // 2. Create ParameterNames
                var socketParam = new ParameterName { Id = 1, Name = "Socket" };
                var ramTypeParam = new ParameterName { Id = 2, Name = "RAM Type" };
                context.ParameterNames.AddRange(socketParam, ramTypeParam);

                // 3. Create Components
                var components = new[]
                {
                    // Motherboards
                    new Component { Id = 1, Name = "ASUS B850", TypeId = 1, Price = 600, ImageUrl = "http://example.com/asus_b850.jpg" },
                    new Component { Id = 2, Name = "MSI Z690", TypeId = 1, Price = 750, ImageUrl = "http://example.com/msi_z690.jpg" },

                    // CPUs
                    new Component { Id = 3, Name = "Intel i5 14400F", TypeId = 2, Price = 900, ImageUrl = "http://example.com/i5_14400f.jpg" },
                    new Component { Id = 4, Name = "AMD Ryzen 5 7600X", TypeId = 2, Price = 950, ImageUrl = "http://example.com/ryzen_7600x.jpg" },

                    // RAM
                    new Component { Id = 5, Name = "Corsair Vengeance 16GB", TypeId = 3, Price = 300, ImageUrl = "http://example.com/corsair_16gb.jpg" },
                    new Component { Id = 6, Name = "Kingston Fury 32GB", TypeId = 3, Price = 450, ImageUrl = "http://example.com/kingston_32gb.jpg" },

                    // GPUs
                    new Component { Id = 7, Name = "NVIDIA RTX 4070", TypeId = 4, Price = 2500, ImageUrl = "http://example.com/rtx4070.jpg" },
                    new Component { Id = 8, Name = "AMD Radeon RX 7800XT", TypeId = 4, Price = 2400, ImageUrl = "http://example.com/rx7800xt.jpg" },

                    // Storage
                    new Component { Id = 9, Name = "Samsung 980 Pro 1TB", TypeId = 5, Price = 400, ImageUrl = "http://example.com/980pro_1tb.jpg" },
                    new Component { Id = 10, Name = "Crucial P5 Plus 2TB", TypeId = 5, Price = 550, ImageUrl = "http://example.com/crucial_p5plus.jpg" },

                    // Power Supplies
                    new Component { Id = 11, Name = "Corsair RM750x", TypeId = 6, Price = 350, ImageUrl = "http://example.com/rm750x.jpg" },
                    new Component { Id = 12, Name = "Seasonic Focus GX-650", TypeId = 6, Price = 320, ImageUrl = "http://example.com/seasonic_gx650.jpg" },

                    // Cases
                    new Component { Id = 13, Name = "NZXT H510", TypeId = 7, Price = 250, ImageUrl = "http://example.com/nzxt_h510.jpg" },
                    new Component { Id = 14, Name = "Lian Li Lancool II", TypeId = 7, Price = 300, ImageUrl = "http://example.com/lancool_ii.jpg" }
                };
                context.Components.AddRange(components);

                // 4. Create Component Parameters
                var componentParameters = new[]
                {
                    // Motherboards
                    new ComponentParameter { Id = 1, ComponentId = 1, ParameterNameId = 1, Value = "LGA1700" },
                    new ComponentParameter { Id = 2, ComponentId = 2, ParameterNameId = 1, Value = "LGA1700" },

                    // CPUs
                    new ComponentParameter { Id = 3, ComponentId = 3, ParameterNameId = 1, Value = "LGA1700" },
                    new ComponentParameter { Id = 4, ComponentId = 4, ParameterNameId = 1, Value = "AM5" },

                    // RAM
                    new ComponentParameter { Id = 5, ComponentId = 5, ParameterNameId = 2, Value = "DDR4" },
                    new ComponentParameter { Id = 6, ComponentId = 6, ParameterNameId = 2, Value = "DDR5" },
                };
                context.ComponentParameters.AddRange(componentParameters);

                // 5. Create Compatibilities
                var compatibilities = new[]
                {
                    // Motherboard ASUS B850 <--> Intel i5 14400F
                    new Compatibility { Id = 1, Component1Id = 1, Component2Id = 3, ParameterNameId = 1, Value1 = "LGA1700", Value2 = "LGA1700", IsCompatible = true },

                    // Motherboard MSI Z690 <--> Intel i5 14400F
                    new Compatibility { Id = 2, Component1Id = 2, Component2Id = 3, ParameterNameId = 1, Value1 = "LGA1700", Value2 = "LGA1700", IsCompatible = true },

                    // Motherboard ASUS B850 <--> Ryzen 7600X (NOT compatible)
                    new Compatibility { Id = 3, Component1Id = 1, Component2Id = 4, ParameterNameId = 1, Value1 = "LGA1700", Value2 = "AM5", IsCompatible = false },

                    // RAM types (example: Corsair works with DDR4 motherboard)
                    new Compatibility { Id = 4, Component1Id = 5, Component2Id = 1, ParameterNameId = 2, Value1 = "DDR4", Value2 = "DDR4", IsCompatible = true }
                };
                context.Compatibilities.AddRange(compatibilities);

                context.SaveChanges();
            }
        }
    }
}
