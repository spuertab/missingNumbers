namespace PuntosColombia.MissingNumbers.Core.Entities
{
    public class Result<T>
    {
        public bool Successful { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }

        public Result()
        {
            Successful = false;
        }
    }
}
