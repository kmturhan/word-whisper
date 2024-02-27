using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordWhisper.Entities.Concrete
{
    public class Word : BaseEntity
    {
        public int Id { get; set; }
        public string Wordle { get; set; }
    }
}
