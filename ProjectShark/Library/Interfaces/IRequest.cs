using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ProjectShark.Library.Interfaces{
    internal interface IRequest{
        void InitRequest(bool withCookies);
        string GetHtml(string url);
        Task<string> GetHtmlWithCookies(string url);
        HtmlDocument GetDocument(string html);
    }
}