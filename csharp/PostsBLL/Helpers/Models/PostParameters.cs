namespace PostsBLL.Helpers.Models;

public class PostParameters : QueryStringParameters
{
    public PostParameters()
    {
        OrderBy = "CreatedAt";
    }
    public string Title;
}