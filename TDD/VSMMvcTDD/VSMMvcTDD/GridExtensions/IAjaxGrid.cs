using Grid.Mvc.Ajax.GridExtensions;

namespace VSMMvcTDD.GridExtensions
{
    public interface IAjaxGrid<TView> where TView : class
    {
        AjaxGrid<TView> GridData { get; set; }
        IAjaxGrid AjaxGrid { get; set; }
    }
}
