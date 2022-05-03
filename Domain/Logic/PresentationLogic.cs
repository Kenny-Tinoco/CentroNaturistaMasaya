using Domain.DAO;
using Domain.Entities;

namespace Domain.Logic
{
    public class PresentationLogic : BaseLogic<Presentation>
    {
        public PresentationLogic( DAOFactory parameter ) : base(parameter.presentationDAO)
        {
            entity = new Presentation();
        }

        public override void resetEntity()
        {
            var element = new Presentation
            {
                idPresentation = 0,
                name = ""
            };
            entity = element;
        }

        public override int getId(Presentation parameter)
        {
            return parameter.idPresentation;
        }
    }
}
