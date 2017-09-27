namespace ManagerWepApp.Data
{
    public class Data
    {
        private static ManagerAppContext context;

        public static ManagerAppContext Context => context ?? (context = new ManagerAppContext());
    }
}
