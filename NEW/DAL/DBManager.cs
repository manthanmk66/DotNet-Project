namespace DAL;

using BLL;

using System.Net.Security;
using MySql.Data.MySqlClient;


public static class DBUser{
    public static string conString="server=192.168.10.150;port=3306;user=dac40;password=welcome;database=dac40";

    public static void register(Signup ui)
    {
        MySqlConnection conn=new MySqlConnection();

        conn.ConnectionString=conString;
        string query="insert into login1(emailid,password) values(@emailid,@password)";
        MySqlCommand cmd=new MySqlCommand(query,conn);
        conn.Open();

      
        cmd.Parameters.AddWithValue("@emailid",ui.emailid);

        cmd.Parameters.AddWithValue("@password",ui.password);
        cmd.ExecuteNonQuery();
      conn.Close();
   
}






    public static void Login(Signup ui)
    {
        MySqlConnection conn=new MySqlConnection();

        conn.ConnectionString=conString;
        string query="select * from login1 where @emailid=emailid,@password=password ";
       MySqlCommand cmd =new MySqlCommand(query,conn);
       conn.Open();


        cmd.Parameters.AddWithValue("@emailid",ui.emailid);

        cmd.Parameters.AddWithValue("@password",ui.password);
       
         MySqlDataReader reader = cmd.ExecuteReader();
        


      conn.Close();
   
}
    }

