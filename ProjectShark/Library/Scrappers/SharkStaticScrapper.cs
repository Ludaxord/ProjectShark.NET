using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using ProjectShark.Library.Interfaces;

namespace ProjectShark.Library.Scrappers{
    /// <summary>
    /// Abstract class that can be inherit by web page scrapper, defines methods for scrapping web page. It allows to make actions with scrapping web page without selenium features, packed in methods of class.
    /// </summary>
    public abstract class SharkStaticScrapper : IStaticScrapper{
        /// <summary>
        /// Getter, Setter for passed html
        /// </summary>
        public string Url{ get; set; }
        /// <summary>
        /// Getter, Setter for passed htmlDocument
        /// </summary>
        public string Html{ get; set; }

        /// <summary>
        /// Find elements by class name in html
        /// </summary>
        /// <param name="htmlDocument">passed htmlDocument object</param>
        /// <param name="className">passed class name</param>
        /// <returns>collection of nodes</returns>
        /// <exception cref="Exception"></exception>
        public IEnumerable<HtmlNode> GetElementsByClassName(HtmlDocument htmlDocument, string className){
            try{
                var nodes =
                    htmlDocument.DocumentNode.Descendants(0).Where(n => n.HasClass(className));
                return nodes;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find elements by className of {className}");
            }
        }

        /// <summary>
        /// Find elements by tag name in html
        /// </summary>
        /// <param name="htmlDocument">passed htmlDocument object</param>
        /// <param name="tagName">passed tag name</param>
        /// <returns>collection of nodes</returns>
        /// <exception cref="Exception">Problem with finding tag name</exception>
        public IEnumerable<HtmlNode> GetElementsByTagName(HtmlDocument htmlDocument, string tagName){
            try{
                var nodes = htmlDocument.DocumentNode.Descendants(tagName);
                return nodes;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find elements by tagName of {tagName}");
            }
        }

        /// <summary>
        /// Find element by tag name in html
        /// </summary>
        /// <param name="htmlDocument">passed htmlDocument object</param>
        /// <param name="tagName">passed tag name</param>
        /// <returns>single node with passed tag</returns>
        /// <exception cref="Exception">Problem with finding element by tag name</exception>
        public HtmlNode GetElementByTagName(HtmlDocument htmlDocument, string tagName){
            try{
                var nodes = htmlDocument.DocumentNode.SelectSingleNode($"//*[contains(local-name(), '{tagName}')]");
                return nodes;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by tagName of {tagName}");
            }
        }

        /// <summary>
        /// Get all elements from parent node
        /// </summary>
        /// <param name="htmlNode">passed parent node</param>
        /// <returns>collection of child nodes</returns>
        /// <exception cref="Exception">Problem with finding child nodes</exception>
        public IEnumerable<HtmlNode> GetElementsFromParent(HtmlNode htmlNode){
            try{
                var nodes = htmlNode.ChildNodes;
                return nodes;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find elements by htmlNode of {htmlNode}");
            }
        }

        /// <summary>
        /// Finding elements by xPath
        /// </summary>
        /// <param name="htmlDocument">passed htmlDocument object</param>
        /// <param name="xPath">passed xPath</param>
        /// <returns>collection of elements by xPath</returns>
        /// <exception cref="Exception">Problem with finding xPath elements</exception>
        public IEnumerable<HtmlNode> GetElementsByXPath(HtmlDocument htmlDocument, string xPath){
            try{
                var nodes = htmlDocument.DocumentNode.SelectNodes(xPath);
                return nodes;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find elements by xPath of {xPath}");
            }
        }

        /// <summary>
        /// Finding element by xPath
        /// </summary>
        /// <param name="htmlDocument">passed htmlDocument object</param>
        /// <param name="xPath">passed xPath</param>
        /// <returns>element by xPath</returns>
        /// <exception cref="Exception">Problem with finding xPath</exception>
        public HtmlNode GetElementByXPath(HtmlDocument htmlDocument, string xPath){
            try{
                var node =
                    htmlDocument.DocumentNode.SelectSingleNode(xPath);
                return node;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by xPath of {xPath}");
            }
        }

        /// <summary>
        /// Find element with passed class name
        /// </summary>
        /// <param name="htmlDocument">passed htmlDocument object</param>
        /// <param name="className">passed class name</param>
        /// <returns>element with passed class name</returns>
        /// <exception cref="Exception">Problem with finding element by class name</exception>
        public HtmlNode GetElementByClassName(HtmlDocument htmlDocument, string className){
            try{
                var node =
                    htmlDocument.DocumentNode.SelectSingleNode($"//*[contains(@class, '{className}')]");
                return node;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by className of {className}");
            }
        }

        /// <summary>
        /// Find element by id
        /// </summary>
        /// <param name="htmlDocument">passed htmlDocument object</param>
        /// <param name="id">passed id</param>
        /// <returns>return html node with element</returns>
        /// <exception cref="Exception">Problem with finding element by id</exception>
        public HtmlNode GetElementById(HtmlDocument htmlDocument, string id){
            try{
                var node =
                    htmlDocument.DocumentNode.SelectSingleNode($"//*[contains(@id, '{id}')]");
                return node;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find element by id of {id}");
            }
        }

        /// <summary>
        /// Finding Attribute of element
        /// </summary>
        /// <param name="htmlNode">passed html node</param>
        /// <param name="attribute">passed attribute</param>
        /// <returns>Attribute of element</returns>
        /// <exception cref="Exception">Problem with finding attribute</exception>
        public HtmlAttribute GetElementAttributeFromNode(HtmlNode htmlNode, string attribute){
            try{
                var node = htmlNode.Attributes[attribute];
                return node;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot find attribute of {attribute}");
            }
        }

        /// <summary>
        /// Finding value of attribute
        /// </summary>
        /// <param name="htmlNode">passed html node</param>
        /// <param name="attribute">passed attribute</param>
        /// <returns>Value of Attribute</returns>
        /// <exception cref="Exception">Problem with finding element</exception>
        public string GetElementAttributeValue(HtmlNode htmlNode, string attribute){
            try{
                var attributeNode = GetElementAttributeFromNode(htmlNode, attribute);
                return attributeNode.Value;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot get value from attribute {attribute}");
            }
        }

        /// <summary>
        /// Return full page html
        /// </summary>
        /// <param name="htmlDocument">passed htmlDocument object</param>
        /// <returns>html page string</returns>
        /// <exception cref="Exception">Problem with returning html page</exception>
        public string GetFullPage(HtmlDocument htmlDocument){
            try{
                var node = htmlDocument.DocumentNode.OuterHtml;
                return node;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot get full page");
            }
        }
    }
}