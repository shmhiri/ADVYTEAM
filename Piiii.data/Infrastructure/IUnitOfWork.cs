using System;

namespace Piiii.data.Infrastrucutre
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        IRepository<T> getRepository<T>() where T : class;
    }

}

