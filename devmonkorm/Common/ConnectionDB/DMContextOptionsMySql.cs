namespace devmonkorm.Common
{
    public partial class DMContextOptions
    {
        public DMContextOptions UseMySql() 
        {
            var factory = new MySql.Data.MySqlClient.MySqlClientFactory();
            var db = factory.CreateConnection();
            db.ConnectionString = ConnectionString;

            Connection = db;
            return this;
        }
    }
}