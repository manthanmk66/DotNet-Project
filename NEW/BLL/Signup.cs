namespace BLL;

public class Signup{

    public string emailid{get;set;}
   public string password{get;set;}



    public Signup(string emailid,string password){
        this.emailid=emailid;
        this.password=password;

    }


}