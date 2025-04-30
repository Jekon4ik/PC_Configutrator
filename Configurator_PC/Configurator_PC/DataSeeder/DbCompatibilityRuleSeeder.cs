using Configurator_PC.Data;
using Configurator_PC.Models;

namespace Configurator_PC.DataSeeder
{
    public static class DbCompatibilityRuleSeeder
    {
        public static void Seed(DataContext context)
        {
            if (!context.CompatibilityRules.Any())
            {
                var rules = new[]
                {
                    // CPU and Motherboard socket compatibility
                    new CompatibilityRule
                    {
                        Id = 1,
                        ComponentType1Id = 2, // CPU
                        ComponentType2Id = 1, // Motherboard
                        ParameterNameId = 1,  // socket
                        Operator = "="
                    },

                    // CPU Cooler and CPU socket compatibility
                    new CompatibilityRule
                    {
                        Id = 2,
                        ComponentType1Id = 8, // CPU Cooler
                        ComponentType2Id = 2, // CPU
                        ParameterNameId = 1,  // socket
                        Operator = "="
                    },

                    // Motherboard and Case form factor match
                    new CompatibilityRule
                    {
                        Id = 3,
                        ComponentType1Id = 1, // Motherboard
                        ComponentType2Id = 7, // Case
                        ParameterNameId = 2,  // form_factor
                        Operator = "="
                    },

                    // RAM and Motherboard memory type match
                    new CompatibilityRule
                    {
                        Id = 4,
                        ComponentType1Id = 3, // RAM
                        ComponentType2Id = 1, // Motherboard
                        ParameterNameId = 3,  // memory_type
                        Operator = "="
                    },

                    // GPU and Motherboard PCIe interface match
                    new CompatibilityRule
                    {
                        Id = 5,
                        ComponentType1Id = 4, // GPU
                        ComponentType2Id = 1, // Motherboard
                        ParameterNameId = 15, // pcie_interface
                        Operator = "="
                    },

                    // Storage and Motherboard interface match
                    new CompatibilityRule
                    {
                        Id = 6,
                        ComponentType1Id = 5, // Storage
                        ComponentType2Id = 1, // Motherboard
                        ParameterNameId = 16, // storage_interface
                        Operator = "="
                    },

                    // PSU wattage must meet or exceed GPU power requirement
                    new CompatibilityRule
                    {
                        Id = 7,
                        ComponentType1Id = 6, // PSU
                        ComponentType2Id = 4, // GPU
                        ParameterNameId = 19, // gpu_power_required
                        Operator = ">="
                    }
                };

                context.CompatibilityRules.AddRange(rules);
                context.SaveChanges();
            }
        }
    }
}
