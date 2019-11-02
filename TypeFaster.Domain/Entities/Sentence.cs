
using System.Collections.Generic;

namespace TypeFaster.Domain.Entities
{
    public class Sentence
    {
        public int Id { get; set; }
        public IList<string> Words { get; set; } = new List<string>();
    }
}
