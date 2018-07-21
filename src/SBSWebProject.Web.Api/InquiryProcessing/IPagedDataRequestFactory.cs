using System;
using SBSWebProject.Data;

namespace SBSWebProject.Web.Api.InquiryProcessing
{
    public interface IPagedDataRequestFactory
    {
        PagedDataRequest Create(Uri requestUri);
    }
}
