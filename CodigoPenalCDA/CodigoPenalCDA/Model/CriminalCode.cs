using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CodigoPenalCDA.Model.Base;

namespace CodigoPenalCDA.Model
{
    [Table("criminalcode")]
    public class CriminalCode : BaseEntity
    {
        [Column("name")]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
        [Column("penalty")]
        public decimal Penalty { get; set; }
        [Column("prisontime")]
        public int PrisonTime { get; set; }
        [Column("statusid")]
        public int StatusId { get; set; }
        [Column("createdate")]
        public DateTime CreateDate { get; set; }
        [Column("updatedate")]
        public DateTime UpdateDate { get; set; }
        [Column("createuserid")]
        public int CreateUserId { get; set; }
        [Column("updateuserid")]
        public int UpdateUserId { get; set; }
    }
}