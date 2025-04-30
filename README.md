# PC_Configutrator

In the database, each PC component type is represented by an Id in the ComponentType table. Here's the mapping:
    ID	Component Type
    1	Motherboard
    2	CPU
    3	RAM
    4	GPU
    5	Storage
    6	PSU
    7	Case
    8	CPU Cooler

This table maps each DTO property to its corresponding logical parameter name and its suggested ParameterNameId (used in the database):
| DTO Property              | Logical Parameter Name      |        `ParameterNameId`     |
|---------------------------|-----------------------------|------------------------------|
| `Socket` (CPU)            | socket                      | 1                            |
| `Socket` (Motherboard)    | socket                      | 1                            |
| `SupportedSocket` (Cooler)| socket                      | 1                            |
| `FormFactor` (Motherboard)| form_factor                 | 2                            |
| `FormFactor` (Case)       | form_factor                 | 2                            |
| `SupportedMemoryType`     | memory_type                 | 3                            |
|     (Motherboard)         |                             |                              |
| `MemtoryType` (RAM)       | memory_type                 | 3                            |
| `MemorySlots`             | memory_slots                | 4                            |
| `M2Slots`                 | m2_slots                    | 5                            |
| `SataPorts`               | sata_ports                  | 6                            |
| `CoreCount`               | core_count                  | 7                            |
| `ThreadCount`             | thread_count                | 8                            |
| `BaseClock`               | base_clock                  | 9                            |
| `BoostClock`              | boost_clock                 | 10                           |
| `TDP`                     | tdp                         | 11                           |
| `Capacity` (RAM)          | ram_capacity                | 12                           |
| `Capacity` (Storage)      | storage_capacity            | 13                           |
| `Speed` (RAM)             | ram_speed                   | 14                           |
| `Inteface` (GPU)          | pcie_interface              | 15                           |
| `Interface` (Storage)     | storage_interface           | 16                           |
| `MemoryType` (GPU)        | gpu_memory_type             | 17                           |
| `MemoryCapacity`          | gpu_memory_capacity         | 18                           |
| `PowerSupply` (GPU)       | gpu_power_required          | 19                           |
| `Wattage`                 | psu_wattage                 | 20                           |
| `MaxLength`               | gpu_max_length              | 21                           |
|---------------------------|-----------------------------|------------------------------|

##  Compatibility Rules

Below are the basic rules that ensure selected components are compatible with each other in the PC configuration:

---

### CPU and Motherboard Socket Compatibility  
The **CPU** and **Motherboard** must have the same `socket` value.  


---

### Cooler and CPU Socket Compatibility  
The **CPU Cooler** must support the same `socket` type as the **CPU**.  

---

### Motherboard and Case Form Factor Match  
The `form_factor` of the **Motherboard** and **Case** must match (e.g., ATX, microATX).  

---

### RAM and Motherboard Memory Type Match  
The `memory_type` of the **RAM** must match the supported memory type of the **Motherboard** (e.g., DDR4, DDR5).  

---

### GPU and Motherboard PCIe Interface Match  
The `pcie_interface` of the **GPU** must match the PCIe slot type of the **Motherboard**.  

---

### Storage Device and Motherboard Interface Match  
The `storage_interface` (e.g., SATA, NVMe) of the **Storage** device must be supported by the **Motherboard**.  

---

### Power Supply Wattage Meets GPU Requirement  
The **PSU's** `psu_wattage` must be greater than or equal to the **GPU’s** `gpu_power_required`.  

---

