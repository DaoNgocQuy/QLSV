using System.Data.SqlClient;


namespace DAL_QuanLy
{
    public class DBConnect
    {
        protected SqlConnection _conn = new SqlConnection("Data Source=.; Initial Catalog=QLSV;Integrated Security=True");
    }
}
