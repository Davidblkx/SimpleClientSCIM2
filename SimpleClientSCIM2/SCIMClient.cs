using SimpleClientSCIM2.Schema;
using SimpleClientSCIM2.Exceptions;
using RestSharp;
using RestSharp.Authenticators;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using NSER = RestSharp.Serializers.Newtonsoft.Json;

namespace SimpleClientSCIM2
{
    public class SCIMClient
    {
        private readonly RestClient _client;

        public SCIMClient(string baseUrl)
        {
            BaseURL = baseUrl;
            Endpoint = new SCIMEndpoint();
            _client = new RestClient(baseUrl);
        }

        public SCIMClient(string baseUrl, IAuthenticator authenticator)
        {
            BaseURL = baseUrl;
            Endpoint = new SCIMEndpoint();
            _client = new RestClient(baseUrl)
            {
                Authenticator = authenticator
            };
        }

        /// <summary>
        /// Url to use as request base
        /// </summary>
        public string BaseURL { get; }

        /// <summary>
        /// Requests endpoints
        /// </summary>
        public SCIMEndpoint Endpoint { get; set; }

        /// <summary>
        /// Authenticator to use in requests, null if not required
        /// </summary>
        public IAuthenticator Authenticator
        {
            get { return _client.Authenticator; }
            set { _client.Authenticator = value; }
        }

        private bool HandleStatus(IRestResponse res, HttpStatusCode expected)
        {
            if (res.StatusCode == expected) return true;

            ErrorResponse err;
            try
            {
                err = JsonConvert.DeserializeObject<ErrorResponse>(res.Content);
            } catch
            {
                err = new ErrorResponse();
            }

            switch (res.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new BadRequestException(err);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedException(err);
                case HttpStatusCode.Forbidden:
                    throw new ForbiddenException(err);
                case HttpStatusCode.NotFound:
                    throw new NotFoundException(err);
                case HttpStatusCode.Conflict:
                    throw new ConflitException(err);
                case HttpStatusCode.PreconditionFailed:
                    throw new PreconditionException(err);
                case HttpStatusCode.RequestEntityTooLarge:
                    throw new LimitException(err);
                case HttpStatusCode.InternalServerError:
                    throw new ServerException(err);
            }

            throw new UnxpectedResponseException((int)res.StatusCode);
        }

        /// <summary>
        /// Gets a resource from the server, the endpoint is calculated based on the tyoe fo T
        /// </summary>
        /// <typeparam name="T">Resource type</typeparam>
        /// <param name="id">Resource ID, only when User or Group</param>
        /// <returns></returns>
        public async Task<T> GetResource<T>(string id = "")
            where T : Resource
        {
            var endpoint = Endpoint.GetEndpoint<T>();
            if (id?.Length > 0)
                endpoint += $"/{id}";

            var req = new RestRequest(endpoint, Method.GET);
            var res = await _client.ExecuteTaskAsync(req).ConfigureAwait(false);

            HandleStatus(res, HttpStatusCode.OK);

            return JsonConvert.DeserializeObject<T>(res.Content);
        }

        /// <summary>
        /// Creates a resource of T and expects a return of type R
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<R> CreateResource<T, R>(T resource)
            where T : Resource
            where R : Resource
        {
            var endpoint = Endpoint.GetEndpoint<T>();

            var req = new RestRequest(endpoint, Method.POST)
            {
                JsonSerializer = new NSER.NewtonsoftJsonSerializer()
            };
            req.AddJsonBody(resource);

            var res = await _client.ExecuteTaskAsync(req).ConfigureAwait(false);

            HandleStatus(res, HttpStatusCode.Created);

            return JsonConvert.DeserializeObject<R>(res.Content);
        }

        public Task<T> CreateResource<T>(T resource)
            where T : Resource
        {
            return CreateResource<T, T>(resource);
        }

        /// <summary>
        /// Updates a resource of type T and expects a return of type R
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R"></typeparam>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<R> UpdateResource<T, R>(T resource)
            where T : Resource
            where R : Resource
        {
            var endpoint = Endpoint.GetEndpoint<T>();
            endpoint += $"/{resource.Id}";

            var req = new RestRequest(endpoint, Method.PUT)
            {
                JsonSerializer = new NSER.NewtonsoftJsonSerializer()
            };
            req.AddJsonBody(resource);

            var res = await _client.ExecuteTaskAsync(req).ConfigureAwait(false);

            HandleStatus(res, HttpStatusCode.OK);

            return JsonConvert.DeserializeObject<R>(res.Content);
        }

        public Task<T> UpdateResource<T>(T resource)
            where T : Resource
        {
            return UpdateResource<T, T>(resource);
        }

        /// <summary>
        /// Delete an resource, returns true if successfully deleted
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteResource<T>(string id)
            where T : Resource
        {
            var endpoint = Endpoint.GetEndpoint<T>();
            endpoint += $"/{id}";

            var req = new RestRequest(endpoint, Method.DELETE);
            var res = await _client.ExecuteTaskAsync(req).ConfigureAwait(false);

            return res.StatusCode == HttpStatusCode.NoContent;
        }

        public Task<bool> DeleteResource<T>(T resource)
            where T : Resource
        {
            return DeleteResource<T>(resource.Id);
        }
    }
}
