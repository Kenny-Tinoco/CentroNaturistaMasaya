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
                element.idProduct.ToString().Contains(parameter.Trim()) ||
                element.name.ToLower().StartsWith(parameter.Trim().ToLower());
        }
        public override void resetEntity()
        {
            var element = new Product
            {
                idProduct = 0,
                name = "",
                description = ""
            };
            entity = element;
        }

        public override int getId(Product parameter)
        {
            return parameter.idProduct;
        }

    }
}
