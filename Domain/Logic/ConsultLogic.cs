using Domain.DAO;
using Domain.Entities;
using System.Diagnostics.Contracts;

namespace Domain.Logic
{
    public class ConsultLogic
    {
        private Consult consult;
        private List<PrescriptionProduct> PrescriptionProducts;
        private ConsultDAO consultDAO;


        public ConsultLogic(Consult objectDTO, ConsultDAO objectDAO)
        {
            Contract.Requires(objectDTO != null && objectDTO != null);
            consult = objectDTO;
            consultDAO = objectDAO;
        }


        public void addPrescriptionProduct(Product product)
        {
            Contract.Requires(product != null);
            PrescriptionProducts.Add(convetTo(product));
        }

        public void deletePrescriptionProduct(Product product)
        {
            Contract.Requires(product != null);
            PrescriptionProducts.Remove(convetTo(product));
        }

        public void addSymptom(string symptom)
        {
            Contract.Requires(symptom != null);
        }

        public void deleteSymptom(string symptom)
        {
            Contract.Requires(symptom != null);
        }


        private PrescriptionProduct convetTo(Product parameter)
        {
            return new PrescriptionProduct()
            {
                idConsult = consult.idConsult,
                idProduct = parameter.idProduct
            };
        }
    }
}
