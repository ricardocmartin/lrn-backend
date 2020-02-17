using Lrn.Aplication.Interfaces;
using Lrn.Domain.Entities;
using Lrn.Service.Services;
using Lrn.Service.Validators;
using System.Collections.Generic;

namespace Lrn.Aplication.Facades
{
    public class ContentVoteFacade : IContentVoteFacade
    {
        private BaseService<ContentVote> service = new BaseService<ContentVote>();

        public ContentVote Get(int Id)
        {
            return service.Get(Id);
        }

        public IList<ContentVote> List()
        {
            return service.Get();
        }

        public void Update(ContentVote obj)
        {
            service.Put<ContentVoteValidator>(obj);
        }

        public void Insert(ContentVote obj)
        {
            service.Post<ContentVoteValidator>(obj);
        }
        public void Delete(int _Id)
        {
            service.Delete(new ContentVote { Id = _Id });
        }


    }
}
