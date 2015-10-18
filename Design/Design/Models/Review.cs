namespace Design.Models
{
    using System;

    public class Review
    {
        public Client Client { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
