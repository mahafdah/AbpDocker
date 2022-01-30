using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;

namespace AbpDocker
{
    public class RedisCachService : ApplicationService, ITransientDependency
    {
        private readonly IDistributedCache<string> _cache;

        public RedisCachService(IDistributedCache<string> cache)
        {
            _cache = cache;
        }

        public async Task<string> OnGetAsync(string key)
        {
            return await _cache.GetAsync(key);
        }

        public async Task<string> OnPostAsync(string key,string value)
        {
            //var options = new DistributedCacheEntryOptions()
            //    .SetSlidingExpiration(TimeSpan.FromSeconds(20));
            await _cache.SetAsync(key, value);

            return key;
        }
    }
}
