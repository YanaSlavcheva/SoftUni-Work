namespace MessagesRestService.Controllers
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Messages.Data;

    using MessagesRestService.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using Microsoft.Owin.Testing;

    [Authorize]
    [RoutePrefix("api/account")]
    public class AccountController : ApiController
    {
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager,
            ISecureDataFormat<AuthenticationTicket> accessTokenFormat)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // POST api/user/login
        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public async Task<HttpResponseMessage> LoginUser(UserAccountBindingModel model)
        {
            if (model == null)
            {
                return await this.BadRequest("Invalid user data").ExecuteAsync(new CancellationToken());
            }

            // Invoke the "token" OWIN service to perform the login (POST /api/token)
            var testServer = TestServer.Create<Startup>();
            var requestParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", model.Username),
                new KeyValuePair<string, string>("password", model.Password)
            };
            var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
            var tokenServiceResponse = await testServer.HttpClient.PostAsync(
                Startup.TokenEndpointPath, requestParamsFormUrlEncoded);
            var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
            var responseCode = tokenServiceResponse.StatusCode;

            var responseMsg = new HttpResponseMessage(responseCode)
            {
                Content = new StringContent(responseString, Encoding.UTF8, "application/json")
            };
            return responseMsg;
        }

        // POST api/user/register
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<HttpResponseMessage> RegisterUser(UserAccountBindingModel model)
        {
            if (model == null)
            {
                return await this.BadRequest("Invalid user data").ExecuteAsync(new CancellationToken());
            }

            if (!ModelState.IsValid)
            {
                return await this.BadRequest(this.ModelState).ExecuteAsync(new CancellationToken());
            }

            var user = new User
            {
                UserName = model.Username
            };

            var identityResult = await this.UserManager.CreateAsync(user, model.Password);

            if (!identityResult.Succeeded)
            {
                return await this.GetErrorResult(identityResult).ExecuteAsync(new CancellationToken());
            }

            // Auto login after registrаtion (successful user registration should return access_token)
            var loginResult = this.LoginUser(new UserAccountBindingModel()
            {
                Username = model.Username,
                Password = model.Password
            });
            return await loginResult;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
