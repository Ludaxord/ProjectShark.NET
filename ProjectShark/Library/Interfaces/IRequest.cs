using HtmlAgilityPack;

namespace ProjectShark.Library.Interfaces{
    internal interface IRequest{
        void InitRequest(bool withCookies);
        string GetHtml(string url);
        string GetHtmlWithCookies(string url);
        HtmlDocument GetDocument(string html);
    }
}