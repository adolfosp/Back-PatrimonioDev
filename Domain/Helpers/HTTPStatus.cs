namespace Domain.Helpers
{
    public static class HTTPStatus
    {
        public static int RetornaStatus(object classe)
        {
            if (classe is null)
                return 204;

            return 200;
        }
    }
}
