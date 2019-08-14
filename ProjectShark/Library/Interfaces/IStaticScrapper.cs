using System.Collections.Generic;
using HtmlAgilityPack;

namespace ProjectShark.Library.Interfaces{
    internal interface IStaticScrapper{
        IEnumerable<HtmlNode> GetElementsByClassName(HtmlDocument htmlDocument, string className);
        HtmlNode GetElementByClassName(HtmlDocument htmlDocument, string className);
        string GetFullPage(HtmlDocument htmlDocument);
        IEnumerable<HtmlNode> GetElementsByXPath(HtmlDocument htmlDocument, string xPath);
        HtmlNode GetElementByXPath(HtmlDocument htmlDocument, string xPath);
        HtmlAttribute GetElementAttributeFromNode(HtmlNode htmlNode, string attribute);
        string GetElementAttributeValue(HtmlNode htmlNode, string attribute);
        IEnumerable<HtmlNode> GetElementsFromParent(HtmlNode htmlNode);
        HtmlNode GetElementByTagName(HtmlDocument htmlDocument, string tagName);
        IEnumerable<HtmlNode> GetElementsByTagName(HtmlDocument htmlDocument, string tagName);
        HtmlNode GetElementById(HtmlDocument htmlDocument, string id);
    }
}