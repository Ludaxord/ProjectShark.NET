using System.Collections.Generic;

namespace ProjectShark.Library.Extensions{
    internal static class ListExtension{
        
        private static readonly List<string> DefaultOptions = new List<string>{
            "--disable-gpu",
            "--disable-extensions",
            "disable-gpu",
            "disable-extensions",
            "--window-size=1920,1080",
            "window-size=1920,1080",
            "--start-maximized",
            "start-maximized",
            "no-sandbox",
            "--proxy-server='direct://'",
            "--proxy-bypass-list=*",
            "--headless",
            "headless"
        };
        
        internal static void SetDefaultOptions(this List<string> options){
            options.AddRange(DefaultOptions);
        }
    }
}