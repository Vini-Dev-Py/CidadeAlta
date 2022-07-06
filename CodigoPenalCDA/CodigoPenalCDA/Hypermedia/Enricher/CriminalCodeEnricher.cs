using System;
using System.Text;
using System.Threading.Tasks;
using CodigoPenalCDA.Data.VO;
using CodigoPenalCDA.Hypermedia.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CodigoPenalCDA.Hypermedia.Enricher
{
    public class CriminalCodeEnricher : ContentResponseEnricher<CriminalCodeVO>
    {
        private readonly object _lock = new object();

        protected override Task EnrichModel(CriminalCodeVO content, IUrlHelper urlHelper)
        {
            var path = "api/v1/CriminalCode";

            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });

            return null;
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };

                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };
        }
    }
}