using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBFirstGumbi.Models
{
    [Table("TransactionType")]
    public partial class TransactionType
    {
        public TransactionType()
        {
            Transactions = new HashSet<Transaction>();
        }

        [Key]
        [Column("TransactionTypeID")]
        public short TransactionTypeId { get; set; }
        [StringLength(50)]
        public string TransactionTypeName { get; set; } = null!;

        [InverseProperty("TransactionType")]
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
