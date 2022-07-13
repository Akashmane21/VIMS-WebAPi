using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vims_Webapi.Model
{
    public class Customer
    {
        [Key]
        public int custid { get; set; }
        [StringLength(25)]

        public string first_name { get; set; }
        [StringLength(25)]

        public string last_name { get; set; }
        [StringLength(30)]

        public string email { get; set; }
        [StringLength(15)]

        public string phone_no { get; set; }
        [StringLength(30)]

        public string address { get; set; }
        public string password { get; set; }


    }

    public class Admin
    {
        [Key]
        public int adminid { get; set; }
        [StringLength(25)]

        public string first_name { get; set; }
        [StringLength(25)]

        public string last_name { get; set; }
        [StringLength(30)]

        public string email { get; set; }
        [StringLength(15)]

        public string phone_no { get; set; }
        [StringLength(30)]

        public string address { get; set; }
        public string password { get; set; }

    }

    public class Vehicles
    {
        [Key]
        public int Vehicles_id { get; set; }
        public string model { get; set; }
    }
    
    public class AllPolicies
    {
        [Key]
        public int policyid { get; set; }

        public int premium_amount { get; set; }

        public int gst_amount { get; set; }

        public int total_amount { get; set; }
        public string duration { get; set; }
    }
  

    public class Vehicle_info
    {
        [Key]
        public int vehid { get; set; }
        [StringLength(10)]
        public string regi_no { get; set; }
        [StringLength(17)]
        public string veh_chassis_no { get; set; }
        [StringLength(11)]
        public string Veh_engine_no { get; set; }
        public int purchase_year { get; set; }
       
        [StringLength(10)]
        public string model { get; set; }

        public int custid { get; set; }
     

    }

    public class policy
    {
        [Key]
        public int id { get; set; }

        public int premium_amount { get; set; }

        public int gst_amount { get; set; }

        public int total_amount { get; set; }
        public DateTime renew_date { get; set; }

        public int policyid { get; set; }

        [ForeignKey("Customer")]
        public int custid { get; set; }
        

        [ForeignKey("Vehicle_info")]
        public int vehid { get; set; }


    }


        public class renew_policy
    {
        [Key]
        public int id { get; set; }
        public int Initial_policy_Id { get; set; }
        public int renew_amount { get; set; }
        public int gst_amount { get; set; }
        public int total_amount { get; set; }
        public DateTime Next_renew_date { get; set; }

        [ForeignKey("Vehicle_info")]
        public int vehid { get; set; }

        [ForeignKey("Customer")]
        public int custid { get; set; }

    }



    public class payment_info
    {
        [Key]
        public int pay_id { get; set; }
        public DateTime payment_date { get; set; }
        public int paid_amount { get; set; }
        public int custid { get; set; }
        public int policyid { get; set; }
    }

    public class Claim
    {
        [Key]
        public int claim_id { get; set; }
        public int claim_amount { get; set; }
        public DateTime claim_date { get; set; }
        public string damage_des { get; set; }
        public char is_approved { get; set; }
        public int custid { get; set; }
        public int vehid { get; set; }
        public int policyid { get; set; }

    }
    }
