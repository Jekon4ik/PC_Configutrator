# PC_Configutrator

In the database, each PC component type is represented by an Id in the ComponentType table. Here's the mapping:
|ID	|Component Type|
|---|--------------|
|1	|Motherboard|
|2	|CPU|
|3	|RAM|
|4	|GPU|
|5	|Storage|
|6	|PSU|
|7	|Case|
|8	|CPU Cooler|

This table maps each DTO property to its corresponding logical parameter name and its suggested ParameterNameId (used in the database):
| DTO Property              | Logical Parameter Name      |        `ParameterNameId`     |
|---------------------------|-----------------------------|------------------------------|
| `Socket` (CPU)            | socket                      | 1                            |
| `Socket` (Motherboard)    | socket                      | 1                            |
| `SupportedSocket` (Cooler)| socket                      | 1                            |
| `FormFactor` (Motherboard)| form_factor                 | 2                            |
| `FormFactor` (Case)       | form_factor                 | 2                            |
| `SupportedMemoryType` (Motherboard)  | memory_type                 | 3                            |
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


##  Compatibility Rules

| Rule # | Component 1         | Component 2         | Parameter Name(s)             | ParameterNameId(s) | Operator | Description                                                                 |
|----------|------------------------|------------------------|----------------------------------|------------------------|-------------|---------------------------------------------------------------------------------|
| 1        | CPU (`2`)              | Motherboard (`1`)      | `socket`                         | `1`                    | `=`         | CPU and motherboard must have the same socket.                                 |
| 2        | CPU Cooler (`8`)       | CPU (`2`)              | `socket`                         | `1`                    | `=`         | Cooler must support the same socket as the CPU.                                |
| 3        | Motherboard (`1`)      | Case (`7`)             | `form_factor`                    | `2`                    | `=`         | Motherboard and case must support the same form factor (e.g., ATX, mATX).      |
| 4        | RAM (`3`)              | Motherboard (`1`)      | `memory_type`                    | `3`                    | `=`         | RAM must match the memory type supported by the motherboard.                   |
| 5        | GPU (`4`)              | Motherboard (`1`)      | `pcie_interface`                 | `15`                   | `=`         | GPU interface must match the motherboard’s PCIe slot type.                     |
| 6        | Storage (`5`)          | Motherboard (`1`)      | `storage_interface`              | `16`                   | `=`         | Storage interface must be supported by the motherboard (e.g., SATA, NVMe).     |
| 7        | GPU (`4`)              | PSU (`6`)              | `gpu_power_required` vs `psu_wattage` | `19` vs `20`      | `<=`        | PSU must provide enough power for the GPU.                                     |
| 8        | GPU (`4`)              | Case (`7`)             | `gpu_max_length`                 | `21`                   | `>=`        | Case must support the physical length of the GPU.                              |