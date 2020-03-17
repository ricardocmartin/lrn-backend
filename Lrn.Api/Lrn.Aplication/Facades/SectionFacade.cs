using Lrn.Aplication.Interfaces;
using Lrn.Domain.Entities;
using Lrn.Service.Services;
using Lrn.Service.Validators;
using System.Collections.Generic;

namespace Lrn.Aplication.Facades
{
    public class SectionFacade : ISectionFacade
    {
        private BaseService<Section> service = new BaseService<Section>();

        public Section Get(int Id)
        {
            return service.Get(Id);
        }


        public IList<Section> List()
        {
            return service.Get();
        }

        public void Update(Section obj)
        {
            service.Put<SectionValidator>(obj);
        }

        public void Insert(Section obj)
        {
            service.Post<SectionValidator>(obj);
        }
        public void Delete(int _Id)
        {
            service.Delete(new Section { Id = _Id });
        }


    }
}
