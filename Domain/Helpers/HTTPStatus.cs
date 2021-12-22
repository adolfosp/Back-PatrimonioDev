namespace Domain.Helpers
{
    public static class HTTPStatus
    {
        public static int RetornaStatus<T>(T classe)
        {
            if (classe is null)
                return 404;

            return 200;
        }
    }
}
