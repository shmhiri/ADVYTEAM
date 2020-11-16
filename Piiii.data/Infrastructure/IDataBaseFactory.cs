using System;

namespace Piiii.data.Infrastrucutre
{
    public interface IDatabaseFactory : IDisposable
    {
        Context DataContext { get; }
    }
}
