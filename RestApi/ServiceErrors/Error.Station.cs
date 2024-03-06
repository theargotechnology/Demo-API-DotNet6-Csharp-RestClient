using ErrorOr;

namespace RestApi.ServiceErrors;

public static class ServiceErrors
{
    public static class Stations
    {
        public static Error NotFound => Error.NotFound(
            code: "Station.NotFound",
            description: "Station not found"
        );
    }
}