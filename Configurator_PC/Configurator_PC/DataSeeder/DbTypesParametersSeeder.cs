using Configurator_PC.Data;
using Configurator_PC.Models;

namespace Configurator_PC.DataSeeder
{
    public static class DbTypesParametersSeeder
    {
        public static void Seed(DataContext context)
        {
            if (!context.ComponentTypes.Any())
            {
                // 1. Component Types
                var componentTypes = new[]
                {
                    new ComponentType { Id = 1, Name = "Motherboard" },
                    new ComponentType { Id = 2, Name = "CPU" },
                    new ComponentType { Id = 3, Name = "RAM" },
                    new ComponentType { Id = 4, Name = "GPU" },
                    new ComponentType { Id = 5, Name = "Storage" },
                    new ComponentType { Id = 6, Name = "PSU" },
                    new ComponentType { Id = 7, Name = "Case" },
                    new ComponentType { Id = 8, Name = "CPU Cooler" }
                };
                context.ComponentTypes.AddRange(componentTypes);

                // 2. Parameter Names
                var parameterNames = new[]
                {
                    new ParameterName { Id = 1, Name = "Socket" },
                    new ParameterName { Id = 2, Name = "FormFactor" },
                    new ParameterName { Id = 3, Name = "MemoryType" },
                    new ParameterName { Id = 4, Name = "MemorySlots" },
                    new ParameterName { Id = 5, Name = "M2Slots" },
                    new ParameterName { Id = 6, Name = "SataPorts" },
                    new ParameterName { Id = 7, Name = "CoreCount" },
                    new ParameterName { Id = 8, Name = "ThreadCount" },
                    new ParameterName { Id = 9, Name = "BaseClock" },
                    new ParameterName { Id = 10, Name = "BoostClock" },
                    new ParameterName { Id = 11, Name = "Tdp" },
                    new ParameterName { Id = 12, Name = "RamCapacity" },
                    new ParameterName { Id = 13, Name = "StorageCapacity" },
                    new ParameterName { Id = 14, Name = "RamSpeed" },
                    new ParameterName { Id = 15, Name = "PcieInterface" },
                    new ParameterName { Id = 16, Name = "StorageInterface" },
                    new ParameterName { Id = 17, Name = "GpuMemoryType" },
                    new ParameterName { Id = 18, Name = "GpuMemoryCapacity" },
                    new ParameterName { Id = 19, Name = "GpuPowerRequired" },
                    new ParameterName { Id = 20, Name = "PsuWattage" },
                    new ParameterName { Id = 21, Name = "GpuMaxLength" }
                };
                context.ParameterNames.AddRange(parameterNames);

                // 3. ComponentTypeParameterName (connections)
                var connections = new[]
                {
                    // CPU
                    new ComponentTypeParameterName { Id = 1, TypeId = 2, ParameterNameId = 1 },
                    new ComponentTypeParameterName { Id = 2, TypeId = 2, ParameterNameId = 7 },
                    new ComponentTypeParameterName { Id = 3, TypeId = 2, ParameterNameId = 8 },
                    new ComponentTypeParameterName { Id = 4, TypeId = 2, ParameterNameId = 9 },
                    new ComponentTypeParameterName { Id = 5, TypeId = 2, ParameterNameId = 10 },
                    new ComponentTypeParameterName { Id = 6, TypeId = 2, ParameterNameId = 11 },

                    // Motherboard
                    new ComponentTypeParameterName { Id = 7, TypeId = 1, ParameterNameId = 1 },
                    new ComponentTypeParameterName { Id = 8, TypeId = 1, ParameterNameId = 2 },
                    new ComponentTypeParameterName { Id = 9, TypeId = 1, ParameterNameId = 3 },
                    new ComponentTypeParameterName { Id = 10, TypeId = 1, ParameterNameId = 4 },
                    new ComponentTypeParameterName { Id = 11, TypeId = 1, ParameterNameId = 5 },
                    new ComponentTypeParameterName { Id = 12, TypeId = 1, ParameterNameId = 6 },
                    new ComponentTypeParameterName { Id = 13, TypeId = 1, ParameterNameId = 15 },
                    new ComponentTypeParameterName { Id = 14, TypeId = 1, ParameterNameId = 16 },

                    // RAM
                    new ComponentTypeParameterName { Id = 15, TypeId = 3, ParameterNameId = 3 },
                    new ComponentTypeParameterName { Id = 16, TypeId = 3, ParameterNameId = 12 },
                    new ComponentTypeParameterName { Id = 17, TypeId = 3, ParameterNameId = 14 },

                    // GPU
                    new ComponentTypeParameterName { Id = 18, TypeId = 4, ParameterNameId = 15 },
                    new ComponentTypeParameterName { Id = 19, TypeId = 4, ParameterNameId = 17 },
                    new ComponentTypeParameterName { Id = 20, TypeId = 4, ParameterNameId = 18 },
                    new ComponentTypeParameterName { Id = 21, TypeId = 4, ParameterNameId = 19 },
                    new ComponentTypeParameterName { Id = 22, TypeId = 4, ParameterNameId = 21 },

                    // Storage
                    new ComponentTypeParameterName { Id = 23, TypeId = 5, ParameterNameId = 13 },
                    new ComponentTypeParameterName { Id = 24, TypeId = 5, ParameterNameId = 16 },

                    // PSU
                    new ComponentTypeParameterName { Id = 25, TypeId = 6, ParameterNameId = 20 },

                    // Case
                    new ComponentTypeParameterName { Id = 26, TypeId = 7, ParameterNameId = 2 },

                    // CPU Cooler
                    new ComponentTypeParameterName { Id = 27, TypeId = 8, ParameterNameId = 1 }
                };
                context.ComponentTypeParameterNames.AddRange(connections);
                context.SaveChanges();
            }
        }
    }
}
