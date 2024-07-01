using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCity.Models {
    public class LearnPage {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Source { get; set; }
        public DateOnly DateCreated { get; set; }
        public DateOnly LastEdited { get; set; }
        public string LastEditedBy { get; set; }
        public string Contributors { get; set; }
    }
}
