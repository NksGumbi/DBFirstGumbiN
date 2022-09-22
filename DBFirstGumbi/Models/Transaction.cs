using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstGumbi.Models
{
    [Table("Transaction")]
    public partial class Transaction
    {
        [Key]
        [Column("TransactionID")]
        public long TransactionId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        [Column("TransactionTypeID")]
        public short TransactionTypeId { get; set; }
        [Column("ClientID")]
        public int ClientId { get; set; }
        [StringLength(100)]
        public string? Comment { get; set; }

        [ForeignKey("ClientId")]
        [InverseProperty("Transactions")]
        public virtual Client Client { get; set; } = null!;
        [ForeignKey("TransactionTypeId")]
        [InverseProperty("Transactions")]
        public virtual TransactionType TransactionType { get; set; } = null!;
    }
}
