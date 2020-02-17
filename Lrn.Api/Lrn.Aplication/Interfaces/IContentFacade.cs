using System.Collections.Generic;
using Lrn.Domain.Entities;

namespace Lrn.Aplication.Interfaces
{
    public interface IContentFacade
    {
        void Delete(int _Id);
        Content Get(int Id);
        void Insert(Content obj);
        IList<Content> List();
        void Update(Content obj);
    }
}