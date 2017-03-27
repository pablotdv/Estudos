using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestingControllersSample.Models
{
    [Table("StormSessions")]
    public class StormSession
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public int IdeaCount { get; set; }
    }
}