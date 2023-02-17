namespace Mc2.CrudTest.Shared.Base
{
    public abstract class MainService
    {
        private MainDbContext context;

        public MainService(MainDbContext context)
        {
            this.context = context;
        }
    }
}
