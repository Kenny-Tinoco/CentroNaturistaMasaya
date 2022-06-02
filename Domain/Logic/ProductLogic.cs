using Domain.DAO;
using Domain.Entities;
using Domain.Logic.Base;

namespace Domain.Logic
{
    public class ProductLogic : BaseLogic<Product>
    {
        public ProductLogic(DAOFactory parameter) : base(parameter.productDAO)
        {
        }

        public static bool SearchLogic(Product element, string parameter) => 
            element.IdProduct.ToString().Contains(parameter) ||
            element.Name.ToLower().StartsWith(parameter.ToLower());

        public override void ResetEntity()
        {
            var element = new Product
            {
                IdProduct = 0,
                Name = "",
                Description = ""
            };
            entity = element;
        }
    }
}
