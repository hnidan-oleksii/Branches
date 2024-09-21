namespace PostsDAL_EF.Exceptions;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(string message)
        : base(message)
    {
    }

    public EntityNotFoundException()
    {
    }
}