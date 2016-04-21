using System.Web.Mvc;

namespace SCA.Helpers
{
    public static class HelpersUi
    {
        public static MvcHtmlString GetBreadcrumb(this HtmlHelper helper,string firstIconCss = "", string firstUrl = "", params string[] names)
        {
            TagBuilder ol = new TagBuilder("ol");
            ol.AddCssClass("breadcrumb");
            bool firstTag = true;
            
            #region Створюємо HTML
            foreach (var text in names)
            {
                TagBuilder li = new TagBuilder("li");
                if (firstTag)
                {
                    TagBuilder iFirst = null;
                    MvcHtmlString innerText = new MvcHtmlString(text);
                    if (firstIconCss != string.Empty)
                    {
                        iFirst = new TagBuilder("i");
                        iFirst.AddCssClass(firstIconCss);
                        innerText = new MvcHtmlString( iFirst.ToString() + " " + text);
                    }

                    if (firstUrl != string.Empty)
                    {
                        TagBuilder aFirst = new TagBuilder("a");
                        aFirst.MergeAttribute("href", firstUrl);
                        if (iFirst!=null)                        
                            aFirst.InnerHtml = innerText.ToString();
                        else
                            aFirst.InnerHtml = text;
                        li.InnerHtml = aFirst.ToString();
                    }
                    else
                    {
                        li.InnerHtml = innerText.ToString();
                    }
                    ol.InnerHtml += li.ToString();
                    firstTag = false;
                    continue;
                }
                else
                {
                    li.InnerHtml = text;
                    ol.InnerHtml += li.ToString();
                }
                
            }
            #endregion

            return new MvcHtmlString(ol.ToString());

        }
    }
}