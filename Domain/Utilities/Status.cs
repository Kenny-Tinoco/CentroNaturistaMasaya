using System.ComponentModel;

namespace Domain.Utilities
{
    public enum Status
    {
        [Description("Inactivo")]
        inactive,
        [Description("Activo")]
        active
    }
}
