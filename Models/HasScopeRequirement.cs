using Microsoft.AspNetCore.Authorization;

namespace Models
{
    public class HasScopeRequirement : IAuthorizationRequirement
    {       
        public string Scope { get; set; }

         public HasScopeRequirement(string scope)
        {
            this.Scope = scope;

        }
    }
}