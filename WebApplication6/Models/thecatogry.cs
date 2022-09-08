using System.Collections.Generic;

namespace WebApplication6.Models
{
    public class thecatogry
    {
        internal static thecatogry c;

        public int Id { get; set; }
        public string Name { get; set; }
        public string discraption { get; set; }
        public List<thenews> thenews { get; set; }
    }
}
