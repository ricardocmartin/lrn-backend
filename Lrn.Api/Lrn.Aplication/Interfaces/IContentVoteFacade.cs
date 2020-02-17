using System.Collections.Generic;
using Lrn.Domain.Entities;

namespace Lrn.Aplication.Interfaces
{
    public interface IContentVoteFacade
    {
        void Delete(int _Id);
        ContentVote Get(int Id);
        void Insert(ContentVote obj);
        IList<ContentVote> List();
        void Update(ContentVote obj);
    }
}