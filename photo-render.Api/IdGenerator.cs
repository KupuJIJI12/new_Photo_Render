namespace photo_render.Api
{
    /*генератор Id для временных файлов, его можно легко улучшить (например чтобы ибежать переполения int)
     но пока в этом нет необходимости*/
    public static class IdGenerator
    {
        private static int _ids;
        public static int GenerateId() => _ids++;
    }
}