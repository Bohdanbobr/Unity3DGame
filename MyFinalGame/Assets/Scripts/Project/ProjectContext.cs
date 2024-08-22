namespace Project
{
    public class ProjectContext
    {
        private static ProjectContext instance;

        public static ProjectContext Instance
        {
            get
            {
                if (instance == null)
                    instance = new ProjectContext();
                return instance;
            }
        }

        public IDataService DataService { get; private set; }
        public IInventoryService InventoryService { get; private set; }

        private ProjectContext()
        {
        }

        public void Init(ItemsConfig itemsConfig)
        {
            DataService = new DataService(itemsConfig);
            InventoryService = new InventoryService(DataService);
        }
    }
}