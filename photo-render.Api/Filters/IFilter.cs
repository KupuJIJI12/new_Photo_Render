namespace photo_render.Api.Filters
{
    public interface IFilter
    {
        string Path { get; }

        string Filter();
        
    }
}