using MasayaNaturistCenter.Model.Utilities;

namespace MasayaNaturistCenter.Model.DTO
{
    public class ProviderDTO
    {
        public int idProvider {get; set;}
        public Name name {get; set;}
        public string address {get; set;}
        public string ruc {get; set;}
    }
}