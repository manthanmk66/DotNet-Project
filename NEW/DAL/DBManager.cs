namespace DAL;

using BLL;

using System.Net.Security;
using MySql.Data.MySqlClient;


public static class DBUser{
    public static string conString="server=localhost;port=3306;user=root;password=admin;database=mk";

    public static void register(Signup ui)
    {
        MySqlConnection conn=new MySqlConnection();

        conn.ConnectionString=conString;
        string query="insert into login(emailid,password) values(@emailid,@password)";
        MySqlCommand cmd=new MySqlCommand(query,conn);
        conn.Open();

      
        cmd.Parameters.AddWithValue("@emailid",ui.emailid);

        cmd.Parameters.AddWithValue("@password",ui.password);
        cmd.ExecuteNonQuery();
      conn.Close();
   
}





public static bool Login(string email, string password)
{
    bool isValid = false;

    MySqlConnection conn = new MySqlConnection();
    conn.ConnectionString = conString; // Assuming conString is defined somewhere with the connection string

    string query = "SELECT COUNT(*) FROM login WHERE emailid = @emailid AND password = @password";
    MySqlCommand cmd = new MySqlCommand(query, conn);

    cmd.Parameters.AddWithValue("@emailid", email);
    cmd.Parameters.AddWithValue("@password", password);

    conn.Open();

    int count = Convert.ToInt32(cmd.ExecuteScalar());

    if (count > 0)
    {
        // Credentials are valid
        isValid = true;
    }

    conn.Close();

    return isValid;
}
}

