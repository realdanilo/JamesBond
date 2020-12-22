using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JamesBond.Models
{
    public class GadgetModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [DisplayName("Appears In")]
        [Required]
        public string AppearsIn { get; set; }
        [DisplayName("With This Actor")]
        [Required]
        public string  WithThisActor { get; set; }

        public GadgetModel()
        {
            Id = 1;
            Name = "";
            Description = "";
            AppearsIn = "";
            WithThisActor = "";
        }

        public GadgetModel(int id, string name, string description, string appearsIn, string withThisActor)
        {
            Id = id;
            Name = name;
            Description = description;
            AppearsIn = appearsIn;
            WithThisActor = withThisActor;
        }
    }
}
