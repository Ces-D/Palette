using Domain.Modules.ColorPalette.SharedKernel;
namespace Domain.Modules.ColorPalette.Authors;

public class Author : Entity
{
    public AuthorId AuthorId { get; private set; }
    private string _userName;
    private DateTime _createdDate;

    public static Author Create(Guid id, string userName)
    {
        return new Author(id, userName);
    }

    private Author(Guid id, string userName)
    {
        AuthorId = new AuthorId(id);
        _userName = userName;
        _createdDate = SystemClock.Now;

        // TODO: add event for created
    }
}