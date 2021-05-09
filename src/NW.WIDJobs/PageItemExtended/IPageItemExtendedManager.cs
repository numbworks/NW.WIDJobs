namespace NW.WIDJobs
{
    public interface IPageItemExtendedManager
    {
        PageItemExtended Get(PageItem pageItem);
        string GetContent(string url);
    }
}