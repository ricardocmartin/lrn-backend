using Lrn.Domain.Entities;
using System.Collections.Generic;

namespace Lrn.Aplication.Interfaces
{
    public interface ISectionFacade
    {
        void Delete(int _Id);
        Section Get(int Id);
        void Insert(Section obj);
        IList<Section> List();
        void Update(Section obj);
    }
}