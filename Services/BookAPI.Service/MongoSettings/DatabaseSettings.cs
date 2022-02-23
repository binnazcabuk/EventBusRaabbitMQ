namespace BookAPI.Service.MongoSettings
{
    public class DatabaseSettings : IDatabaseSettings
    {   
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string BookCollectionName { get ; set; }
    }
}
