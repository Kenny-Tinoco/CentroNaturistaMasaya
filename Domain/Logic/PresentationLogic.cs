using Domain.DAO;
using Domain.Entities;
using Domain.Logic.Base;

namespace Domain.Logic
{
    public class PresentationLogic : BaseLogic<Presentation>
    {
        public PresentationLogic( DAOFactory parameter ) : base(parameter.presentationDAO)
        {
            entity = new Presentation();
        }

        public override void ResetEntity()
        {
            var element = new Presentation
            {
                IdPresentation = 0,
                Name = "",
                Status = true
            };

            entity = element;
        }
    }
}
