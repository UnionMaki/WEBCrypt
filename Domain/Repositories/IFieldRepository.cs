using Domain.Entity;

namespace Domain.Repositories;
public interface IFieldRepository
{
    void AddField( Field field );
    Field? GetField( int fieldId );
    List<Field> GetAllFields();
}
