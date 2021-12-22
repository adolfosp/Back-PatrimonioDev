namespace PatrimonioDev.Helpers
{
    public static class HTTPStatus
    {
        public static int RetornaStatus(object classe)
        {
            if (classe is null)
                return 404;

            return 200;
        }
    }
}
