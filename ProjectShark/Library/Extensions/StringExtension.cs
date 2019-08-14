namespace ProjectShark.Library.Extensions{
    internal static class StringExtension{
        internal static string UrlGenerator(this string url){
            var u = url;
            if (!u.StartsWith("http://") || !u.StartsWith("https://")){
                u = $"http://{u}";
            }

            return u;
        }
    }
}