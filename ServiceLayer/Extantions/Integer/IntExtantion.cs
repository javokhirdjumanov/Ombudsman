using DomainLayer.Exceptions;
using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.Extantions;
public static class IntExtantion
{
    public static void IsDefault(this int id)
    {
        if(id <= 0 || id > int.MaxValue)
        {
            throw new ValidationExceptions("Id is not valid !");
        }
    }
}
