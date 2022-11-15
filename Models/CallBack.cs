using System.ComponentModel.DataAnnotations;

namespace VersionTwo.Models
{
    public class CallBack
    {
        public int id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; } = null!;
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string EmailAddress { get; set; } = null!;
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = null!;
        [Display(Name = "Call back logged date")]
        [DataType(DataType.DateTime)]
        public DateTime CallBackDate { get; set; } = DateTime.Now;
    }
}