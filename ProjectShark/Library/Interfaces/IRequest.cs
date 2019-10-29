using System.Net;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ProjectShark.Library.Interfaces{
    internal interface IRequest{
        void InitRequest(bool withCookies, WebProxy withWebProxy = null);
        string GetHtml(string url, WebProxy withWebProxy = null);
        Task<string> GetHtmlWithCookies(string url, WebProxy withWebProxy = null);
        HtmlDocument GetDocument(string html);
    }
}