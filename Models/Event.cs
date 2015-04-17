using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [DataContract]
    public class Event
    {
        [DataMember]
        [Key]
        [Required]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Time { get; set; }

        [DataMember]
        public EventType Type { get; set; }

        [DataMember]
        public EventStatus Status { get; set; }
    
    }
}
