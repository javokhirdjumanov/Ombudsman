using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using ServiceLayer.Services;

namespace Ombudsman.API.Attributes;
public class UserActionAttribute : ActionFilterAttribute
{
    private int? _tableId;

    public UserActionAttribute(int tableId = 0)
    {
        _tableId = (tableId == 0) ? null : tableId;

    }
    public override void OnResultExecuting(ResultExecutingContext context)
    {
        base.OnResultExecuting(context);
        throw new NotImplementedException();
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }
}
