using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodigoPenalCDA.Model.Base;

namespace CodigoPenalCDA.Model
{
    [Table("status")]
    public class Status : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
    }
}