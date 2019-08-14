using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;
using ProjectShark.Library.Scrappers;

namespace ProjectShark.Library.Requests{
    /// <summary>
    /// sealed class defines static download of page and make request without call selenium.
    /// </summary>
    public sealed class SharkRequest{
        /// <summary>
        /// Getter, Setter for passed url
        /// </summary>
        public string Url{ get; set; }

        /// <summary>
        /// Getter, Setter for passed html
        /// </summary>
        public string Html{ get; set; }

        /// <summary>
        /// Getter, Setter for passed htmlDocument
        /// </summary>
        public HtmlDocument HtmlDocument{ get; set; }

        /// <summary>
        /// Getter, Setter for passed scrapper
        /// </summary>
        public SharkStaticScrapper Scrapper{ get; set; }

        /// <summary>
        /// Constructor that create request with default parameters
        /// </summary>
        /// <param name="url">passed url of web page</param>
        /// <param name="scrapper">passed scrapper of page</param>
        public SharkRequest(string url, SharkStaticScrapper scrapper){
            Url = url;
            Scrapper = scrapper;
            Scrapper.Url = url;
            InitRequest();
        }

        /// <summary>
        /// Initializer of request
        /// </summary>
        public void InitRequest(){
            Html = GetHtml(Url);
            Scrapper.Html = Html;
            HtmlDocument = GetDocument(Html);
        }

        /// <summary>
        /// Get html from url. Make HTTP Request to page
        /// </summary>
        /// <param name="url">passed Url</param>
        /// <returns>string with HTML</returns>
        /// <exception cref="Exception">Problem with getting html from url</exception>
        public string GetHtml(string url){
            string sHtml;
            try{
                var webRequest = (HttpWebRequest) WebRequest.Create(url);

                webRequest.Method = "GET";

                var webResponse = (HttpWebResponse) webRequest.GetResponse();

                var webSource = new StreamReader(webResponse.GetResponseStream() ??
                                                 throw new Exception("Cannot get request from stream"));

                sHtml = webSource.ReadToEnd();
                webResponse.Close();
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot get html from url {url}");
            }

            return sHtml;
        }

        /// <summary>
        /// Change html to HTMLDocument object
        /// </summary>
        /// <param name="html">html obtained from http request</param>
        /// <returns>HtmlDocument object with all web page nodes</returns>
        /// <exception cref="Exception">Problem with getting document</exception>
        public HtmlDocument GetDocument(string html){
            try{
                var doc = new HtmlDocument();
                doc.LoadHtml(html);
                return doc;
            }
            catch (Exception e){
                Console.WriteLine(e);
                throw new Exception($"Cannot get document from html {html}");
            }
        }
    }
}