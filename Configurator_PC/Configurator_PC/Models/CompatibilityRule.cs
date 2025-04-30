using System.ComponentModel.DataAnnotations.Schema;

namespace Configurator_PC.Models
{
    public class CompatibilityRule
    {
        public int Id { get; set; }

        public int ComponentType1Id { get; set; }

        [ForeignKey(nameof(ComponentType1Id))]
        public ComponentType? ComponentType1 { get; set; }

        public int ComponentType2Id { get; set; }

        [ForeignKey(nameof(ComponentType2Id))]
        public ComponentType? ComponentType2 { get; set; }

        public int ParameterNameId { get; set; }

        public ParameterName? ParameterName { get; set; }

        public string Operator { get; set; } = "=";
    }
}
