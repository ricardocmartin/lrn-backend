using System.Collections.Generic;
using System.Threading.Tasks;
using GraphQL;
using Lrn.Aplication.ModelQuery;
using Lrn.Domain.Entities;

namespace Lrn.Aplication.Interfaces
{
    public interface ICourseFacade
    {
        void Delete(int _Id);
        Course Get(int Id);
        Task<ExecutionResult> FindAsync(GraphQLQuery query);
        void Insert(Course obj);
        IList<Course> List();
        void Update(Course obj);
    }
}