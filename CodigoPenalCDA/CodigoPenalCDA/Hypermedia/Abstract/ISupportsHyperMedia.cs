using System.Collections.Generic;

namespace CodigoPenalCDA.Hypermedia.Abstract
{
    public interface ISupportsHyperMedia
    {
        List<HyperMediaLink> Links { get; set; }
    }
}