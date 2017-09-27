using ManagerWepApp.Data;

namespace ManagerWepApp.Services
{
    public class Service
    {
        private ManagerAppContext context;
        protected Service()
        {
            this.context = Data.Data.Context;
        }

        protected ManagerAppContext Context => this.context;
    }
}
