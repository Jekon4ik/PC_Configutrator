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
                // 1. Component Types
                var componentTypes = new[]
                {
                    new ComponentType { Id = 1, Name = "Motherboard" },
                    new ComponentType { Id = 2, Name = "Processor" },
                    new ComponentType { Id = 3, Name = "RAM" },
                };
                context.ComponentTypes.AddRange(componentTypes);

                // 2. Parameter Names
                var parameters = new[]
                {
                    new ParameterName { Id = 1, Name = "Socket" },
                    new ParameterName { Id = 2, Name = "RAM Type" }
                };
                context.ParameterNames.AddRange(parameters);

                // 3. Components
                var components = new[]
                {
                    new Component { Id = 1, Name = "ASUS B850", TypeId = 1, Price = 600 },
                    new Component { Id = 2, Name = "MSI Z690", TypeId = 1, Price = 750 },

                    new Component { Id = 3, Name = "Intel i5 14400F", TypeId = 2, Price = 900 },
                    new Component { Id = 4, Name = "Ryzen 5 7600X", TypeId = 2, Price = 950 },

                    new Component { Id = 5, Name = "Corsair 16GB DDR4", TypeId = 3, Price = 300 },
                    new Component { Id = 6, Name = "Kingston 32GB DDR5", TypeId = 3, Price = 450 },
                };
                context.Components.AddRange(components);

                // 4. Component Parameters
                var componentParameters = new[]
                {
                    new ComponentParameter { Id = 1, ComponentId = 1, ParameterNameId = 1, Value = "LGA1700" },
                    new ComponentParameter { Id = 2, ComponentId = 2, ParameterNameId = 1, Value = "LGA1700" },

                    new ComponentParameter { Id = 3, ComponentId = 3, ParameterNameId = 1, Value = "LGA1700" },
                    new ComponentParameter { Id = 4, ComponentId = 4, ParameterNameId = 1, Value = "AM5" },

                    new ComponentParameter { Id = 5, ComponentId = 5, ParameterNameId = 2, Value = "DDR4" },
                    new ComponentParameter { Id = 6, ComponentId = 6, ParameterNameId = 2, Value = "DDR5" },
                };
                context.ComponentParameters.AddRange(componentParameters);

                // 5. Compatibility Rules (based on types, not specific components)
                var compatibilityRules = new[]
                {
                    // Processors and motherboards must have matching socket
                    new CompatibilityRule
                    {
                        Id = 1,
                        ComponentType1Id = 1, // Motherboard
                        ComponentType2Id = 2, // Processor
                        ParameterNameId = 1, // Socket
                        Operator = "="
                    },

                    // RAM and motherboards must have matching RAM type
                    new CompatibilityRule
                    {
                        Id = 2,
                        ComponentType1Id = 3, // RAM
                        ComponentType2Id = 1, // Motherboard
                        ParameterNameId = 2, // RAM Type
                        Operator = "="
                    }
                };
                context.CompatibilityRules.AddRange(compatibilityRules);

                // Save everything
                context.SaveChanges();
            }
        }
    }
}
