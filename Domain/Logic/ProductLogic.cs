using Domain.DAO;
using Domain.Entities;

namespace Domain.Logic
{
    public class ProductLogic : BaseLogic<Product>
    {
        public ProductLogic(DAOFactory parameter) : base(parameter.productDAO)
        {
        }

        public bool searchLogic(Product element, string parameter)
        {
            return
                element.IdProduct.ToString().Contains(parameter.Trim()) ||
                element.Name.ToLower().StartsWith(parameter.Trim().ToLower());
        }
        public override void resetEntity()
        {
            var element = new Product
            {
                IdProduct = 0,
                Name = "",
                Description = ""
            };
            entity = element;
        }

        public override int getId(Product parameter)
        {
            return parameter.IdProduct;
        }

    }
}
