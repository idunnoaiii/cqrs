namespace Application.Wrappers;

public class Response<T>
{
    public Response(T data, string message = null)
    {
        Data = data;
        Message = message;
        Suceeded = true;
    }

    public Response(string message)
    {
        Message = message;
        Suceeded = false;
    }

    public bool Suceeded { get; set; }
    public List<string> Errors { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

}