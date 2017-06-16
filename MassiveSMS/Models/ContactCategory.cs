using System; 

namespace MassiveSMS.Models
{
    public class ContactCategories
    {
        public ContactCategories()
        {
        } 
        public long Id {get;set;}   
        public long ContactId { get; set; }
        public long CategoryId { get; set; }

	}
}
