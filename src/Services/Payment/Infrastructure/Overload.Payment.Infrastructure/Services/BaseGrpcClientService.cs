using Grpc.Core;

namespace Overload.Payment.Infrastructure.Services
{
    public abstract class BaseGrpcClientService
    {
        public Channel _channel;
        public CallOptions _callOptions;

        public BaseGrpcClientService(string host)
        {
            this._channel = new Channel(host, ChannelCredentials.Insecure);
        }
    }
}
