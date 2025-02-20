﻿using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using DeveloperEvaluation.Domain.Services;

namespace DeveloperEvaluation.Redis;
public class RedisService : IRedisService
{
    private readonly ConnectionMultiplexer _redis;
    private readonly IDatabase _database;

    public RedisService(IConfiguration configuration)
    {
        try
        {
            //_redis = ConnectionMultiplexer.Connect($"localhost:6379,password=Develop@01");
            _redis = ConnectionMultiplexer.Connect($"localhost:6379,abortConnect=false");
            _database = _redis.GetDatabase();
        }
        catch (RedisConnectionException ex)
        {
            throw new InvalidOperationException("Unable to connect to Redis.", ex);
        }
    }

    public void SetCache(string key, string value)
    {
        _database.StringSet(key, value);
    }

    public string? GetCache(string key)
    {
        return _database.StringGet(key);
    }

    public bool KeyExists(string key)
    {
        return _database.KeyExists(key);
    }

    public void RemoveCache(string key)
    {
        _database.KeyDelete(key);
    }
}
