using System.ComponentModel.DataAnnotations.Schema;

namespace CodigoPenalCDA.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}