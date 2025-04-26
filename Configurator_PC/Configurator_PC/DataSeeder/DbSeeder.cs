using Configurator_PC.Data;
using Configurator_PC.Models;
using System;

namespace Configurator_PC.DataSeeder
{
    public static class DbSeeder
    {
        public static void Seed(DataContext context)
        {
            if (!context.ComponentTypes.Any())
            {
                var motherboard = new ComponentType { Id = 1, Name = "Motherboard" };
                var cpu = new ComponentType { Id = 2, Name = "Processor" };

                context.ComponentTypes.AddRange(motherboard, cpu);

                var asus = new Component
                {
                    Id = 1,
                    Name = "ASUS B850",
                    TypeId = 1,
                    Price = 600,
                    ImageUrl = "http://example.com/asus_b850.jpg"
                };

                var intel = new Component
                {
                    Id = 2,
                    Name = "Intel i5 14400F",
                    TypeId = 2,
                    Price = 900,
                    ImageUrl = "http://example.com/i5_14400f.jpg"
                };

                var socketParam = new ParameterName { Id = 1, Name = "Socket" };

                var asusParam = new ComponentParameter { Id = 1, ComponentId = 1, ParameterNameId = 1, Value = "LGA1700" };
                var intelParam = new ComponentParameter { Id = 2, ComponentId = 2, ParameterNameId = 1, Value = "LGA1700" };

                var compatibility = new Compatibility
                {
                    Id = 1,
                    Component1Id = 1,
                    Component2Id = 2,
                    ParameterNameId = 1,
                    Value1 = "LGA1700",
                    Value2 = "LGA1700",
                    IsCompatible = true
                };

                context.Components.AddRange(asus, intel);
                context.ParameterNames.Add(socketParam);
                context.ComponentParameters.AddRange(asusParam, intelParam);
                context.Compatibilities.Add(compatibility);

                context.SaveChanges();
            }
        }

    }
}
