namespace formula1.Models
{
    public class Response<T>
    {
        public int statusCode { get; set; }

        public string statusDescription { get; set; }

        public T? data { get; set; } 

        public Response(int code, string description, T res)
        {
            statusCode = code;
            statusDescription = description;
            data = res;
        }

        public Response(int code, string description)
        {
            statusCode = code;
            statusDescription = description;
        }
    }
}
