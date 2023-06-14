using DomainLayer.Exceptions;

namespace ServiceLayer.Validations;
public static class ValidationStorageObj
{
    public static void  GenericValidation<TEntity>(TEntity entity, int id)
    {
        if (entity is null)
        {
            throw new NotFoundException($"Couldn't find object with  given id: {id}");
        }
    }
}


