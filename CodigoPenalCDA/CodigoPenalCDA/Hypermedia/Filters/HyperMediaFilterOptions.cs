using System.Collections.Generic;
using CodigoPenalCDA.Hypermedia.Abstract;

namespace CodigoPenalCDA.Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}