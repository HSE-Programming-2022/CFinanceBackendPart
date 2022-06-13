using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;


namespace CFinance.Context.Models
{
    public abstract class DbEntity
    {
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    [Table("users")]
    public class User : DbEntity
    {
        [Column("user_id")][Key] public int UserID { get; set; }
        [Column("username")] public string UserName { get; set; }
        [Column("password")] public string Password { get; set; }
        [Column("email")] public string Email { get; set; }

        public bool CheckPassword(int attemptPassword)
        {
            return (attemptPassword == Password.GetHashCode());
        }
    }

    [Table("company")]
    public class Company : DbEntity
    {
        [Column("ticker")][Key] public string Ticker { get; set; }
        [Column("name")] public string Name { get; set; }
        [Column("description")] public string Description { get; set; }
        [Column("country")] public string Country { get; set; }
        [Column("address")] public string Address { get; set; }
        [Column("industry_id")] public int IndusrtyID { get; set; }
        [Column("sector_id")] public int SectorID { get; set; }

    }
}
