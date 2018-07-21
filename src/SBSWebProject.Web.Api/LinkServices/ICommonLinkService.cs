using System.Net.Http;
using SBSWebProject.Web.Api.Models;

namespace SBSWebProject.Web.Api.LinkServices
{
    public interface ICommonLinkService
    {
        void AddPageLinks(IPageLinkContaining linkContainer,
        string currentPageQueryString,
        string previousPageQueryString,
        string nextPageQueryString);
        Link GetLink(string pathFragment, string relValue, HttpMethod httpMethod);
    }
}
