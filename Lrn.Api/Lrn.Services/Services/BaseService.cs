using FluentValidation;
using Lrn.Domain.Entities;
using Lrn.Domain.Interfaces;
using Lrn.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lrn.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public T Post<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Put<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(T obj)
        {
            if (obj.Id == 0)
                throw new ArgumentException("The id can't be zero.");

            repository.Delete(obj);
        }

        public IList<T> Get() => repository.Select();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Record not found!");

            validator.ValidateAndThrow(obj);
        }
    }
}
