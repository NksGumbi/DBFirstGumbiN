using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstGumbi.Models
{
    public enum SortOrder { Ascending = 0, Descending = 1 }

    [Table("Client *")]
    public partial class Client
    {
        public Client()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("ClientID")]
        public int ClientId { get; set; }
        [StringLength(50)]
        public string Name { get; set; } = null!;
        [StringLength(50)]
        public string Surname { get; set; } = null!;
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ClientBalance { get; set; }

        [InverseProperty("Client")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
