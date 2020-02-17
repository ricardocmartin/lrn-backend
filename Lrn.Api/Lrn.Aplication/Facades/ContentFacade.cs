using Lrn.Aplication.Interfaces;
using Lrn.Domain.Entities;
using Lrn.Service.Services;
using Lrn.Service.Validators;
using System.Collections.Generic;

namespace Lrn.Aplication.Facades
{
    public class ContentFacade : IContentFacade
    {
        private BaseService<Content> service = new BaseService<Content>();

        public Content Get(int Id)
        {
            return service.Get(Id);
        }

        public IList<Content> List()
        {
            return service.Get();
        }

        public void Update(Content obj)
        {
            service.Put<ContentValidator>(obj);
        }

        public void Insert(Content obj)
        {
            service.Post<ContentValidator>(obj);
        }
        public void Delete(int _Id)
        {
            service.Delete(new Content { Id = _Id });
        }
    }
}
