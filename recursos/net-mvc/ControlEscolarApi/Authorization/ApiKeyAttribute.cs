using Microsoft.AspNetCore.Mvc;

namespace ControlEscolarApi.Authorization
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute()
        : base(typeof(ApiKeyAuthorizationFilter)) {
        }
    }
}
