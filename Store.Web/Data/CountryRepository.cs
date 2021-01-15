namespace Store.Web.Data
{
    using Store.Web.Data.Entities;


    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(DataContext context) : base(context)
        {

        }

    }
}
