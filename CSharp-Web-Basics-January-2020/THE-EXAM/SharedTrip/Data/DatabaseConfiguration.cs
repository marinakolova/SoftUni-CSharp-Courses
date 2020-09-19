namespace SharedTrip.Data
{
    public class DatabaseConfiguration
    {
        public const string ConnectionString =
            @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=SharedTrip-MarinaKolova;Trusted_Connection=True;Integrated Security=True;";

        //Default:
        //  @"Server=.;Database=SharedTrip;Trusted_Connection=True;Integrated Security=True;";

        //Mine:
        //  @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=SharedTrip;Trusted_Connection=True;Integrated Security=True;";

        //For Easy Checking:
        //  @"Server=.;Database=SharedTrip-MarinaKolova;Trusted_Connection=True;Integrated Security=True;";

        //For Tests at home:
        //  @"Server=LAPTOP-DTGPHD2G\SQLEXPRESS;Database=SharedTrip-MarinaKolova;Trusted_Connection=True;Integrated Security=True;";
    }
}