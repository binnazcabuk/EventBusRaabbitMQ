namespace BookAPI.Service.MongoSettings
{
    public interface IDatabaseSettings
    {
        public string BookCollectionName { get; set; }

        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }


    }
}
