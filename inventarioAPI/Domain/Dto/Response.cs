

namespace Domain.Dto
{
    public class Response<T>
    {
        public Response()
        {

        }

        public Response(T data, string mensaje = null) {
           success= true;
           Message = mensaje;
           Result = data;
        }

        public Response(string i, bool j)
        {
            success= j;
            Message = i;
        }

        public bool success { get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
    }
}
