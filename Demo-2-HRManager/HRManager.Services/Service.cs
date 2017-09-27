using HRManager.Data;

namespace HRManager.Services
{
    public class Service
    {
        private HRManagerContext context;
        protected Service()
        {
            this.context = Data.Data.Context;
        }

        protected HRManagerContext Context => this.context;
    }
}
