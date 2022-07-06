using System;
using System.Collections.Generic;
using CodigoPenalCDA.Hypermedia;
using CodigoPenalCDA.Hypermedia.Abstract;

namespace CodigoPenalCDA.Data.VO
{
    public class CriminalCodeVO : ISupportsHyperMedia
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Penalty { get; set; }
        public int PrisonTime { get; set; }
        public long StatusId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }
        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}