namespace bootcamp_caso_practico_backend.Infrastructure.Persistence
{
    public class DevelopmentDataLoader
    {
        private readonly ListContext userListContext;
        public DevelopmentDataLoader(ListContext userListContext)
        {
            this.userListContext = userListContext;
        }
        public void LoadData() { }
    }
}
