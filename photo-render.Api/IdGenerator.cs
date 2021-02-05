namespace photo_render.Api
{
    public static class IdGenerator
    {
        private static int _ids;
        public static int GenetateId() => _ids++;
    }
}