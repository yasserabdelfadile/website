using System;

namespace WebApplication6.Models
{
    public class thenews
    {
        public int Id { get; set; }
        public string tital { get; set; }
        public string Description { get; set; }
        public DateTime thedate { get; set; }
        public int thecatogryId { get; set; }
        public thecatogry thecatogry { get; set; }

    }
}
