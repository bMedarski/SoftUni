using System;
using StartUp.Server.Common;
using StartUp.Server.Handlers.Contracts;
using StartUp.Server.HTTP;
using StartUp.Server.HTTP.Contracts;

namespace StartUp.Server.Handlers
{
	public abstract class RequestHandler : IRequestHandler
	{
		private readonly Func<IHttpRequest, IHttpResponse> handlingFunc;

		protected RequestHandler(Func<IHttpRequest, IHttpResponse> handlingFunc)
		{
			Validator.ThrowIfNull(handlingFunc, nameof(handlingFunc));

			this.handlingFunc = handlingFunc;
		}


		public IHttpResponse Handle(IHttpContext context)
		{
			var response = this.handlingFunc(context.Request);
			response.HeaderCollection.Add(new HttpHeader("Content-Type", "text/html"));

			return response;
		}
	}
}
