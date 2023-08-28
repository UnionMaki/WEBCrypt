using ConsoleApp1;
using Domain.Entity;
using Domain.Repositories;

namespace Infrastucture;
internal class FieldRepository: IFieldRepository
{
    private readonly ApplicationContext _context;

    public FieldRepository( ApplicationContext context )
    {
        _context = context;
    }

    public void AddField(Field field)
    {
        _context.Data.Add(field);
    }

    public Field? GetField( int fieldId )
    {
        return _context.Data.FirstOrDefault( x => x.Id == fieldId );
    }

    public List<Field> GetAllFields()
    {
        return _context.Data.ToList();
    }
}
