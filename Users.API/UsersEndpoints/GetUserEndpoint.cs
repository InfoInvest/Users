using Core.API;
using MediatR;

namespace Users.API.UsersEndpoints
{
    public class GetUserEndpoint : IEndpointDefinition
    {
        public void DefineEndpoints(WebApplication app)
        {
            app.MapGet("api/users/getUser", GetUser);
        }

        private async Task<UserVM> GetUser(IMediator mediator)
        {
            throw new NotImplementedException();
        }
    }
}
