using HtmlAgilityPack;

namespace ProjectShark.Library.Interfaces{
    internal interface IRequest{
        void InitRequest();
        string GetHtml(string url);
        HtmlDocument GetDocument(string html);
    }
}