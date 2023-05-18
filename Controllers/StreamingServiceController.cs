using DigitalAfterlifeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DigitalAfterlifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingServiceController : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<StreamService>> GetStreamServicesAsync()
        {
            return await DAL.StreamingServiceManager.GetStreamList();
        }

        [HttpGet("{id}")]
        public async Task<StreamService> GetOneStreamService(int id)
        {
            return await DAL.StreamingServiceManager.GetOneStreamService(id);
        } 

        [HttpPost]
        public async Task AddStreamingService([FromBody]StreamService service)
        {
            await DAL.StreamingServiceManager.AddStreamingService(service);
        }

        [HttpPut("{id}")]
        public async Task UpdateStreamingservice(int id, [FromBody] StreamService service)
        {
            await DAL.StreamingServiceManager.UpdateStreamService(service, id);
        }

        [HttpDelete("{id}")]
        public async Task DeleteStreamingService(int id)
        {
            await DAL.StreamingServiceManager.RemoveStreamingService(id);
        }
    }
}
