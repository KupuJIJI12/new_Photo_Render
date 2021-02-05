namespace photo_render.Api.Filters
{
    /*Абстракция, которую реализует каждый фильтр*/
    public interface IFilter
    {
        string Filter(string path); // основной метод, который вызывается в рендере
    }
}