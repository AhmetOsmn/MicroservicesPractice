using StackExchange.Redis;

namespace MicroservicesPractice.Services.Basket.Services.Concrete
{
    public class RedisService
    {
        private readonly string _host;
        private readonly int _port;

        private ConnectionMultiplexer? _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");

        public IDatabase GetDb(int db = 1) => _connectionMultiplexer!.GetDatabase(db);

        public async Task<List<string>> GetKeysAsync(string pattern)
        {
            RedisResult redisResult = await GetDb().ExecuteAsync("KEYS", pattern);

            List<string> keysList = new List<string>();
            foreach (RedisValue key in (RedisValue[])redisResult)
            {
                keysList.Add((string)key);
            }

            return keysList;
        }
    }
}
