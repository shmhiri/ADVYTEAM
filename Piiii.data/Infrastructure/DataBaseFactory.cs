using Piiii.data;

namespace Piiii.data.Infrastrucutre
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private Context dataContext;
        public Context DataContext { get { return dataContext; } }

        public DatabaseFactory()
        {
            dataContext = new Context();
        }
        protected override void DisposeCore()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }
}
