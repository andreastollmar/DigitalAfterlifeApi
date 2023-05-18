using DigitalAfterlifeApi.Models;

namespace DigitalAfterlifeApi.DAL
{
    public class StreamingServiceManager
    {
        public static List<StreamService> StreamServices { get; set; }
        public static int IdCounter { get; set; }

        public static async Task<List<StreamService>> GetStreamList()
        {
            if (StreamServices == null)
            {
                StreamServices = new List<StreamService>();
                StreamServices.Add(new StreamService { Id = 1, Name = "Netflix" });
                StreamServices.Add(new StreamService { Id = 2, Name = "Viaplay" });
                StreamServices.Add(new StreamService { Id = 3, Name = "Disney Plus" });
                StreamServices.Add(new StreamService { Id = 4, Name = "HBO Max" });
                IdCounter = 5;
            }
            return StreamServices;
        }

        public static async Task<StreamService> GetOneStreamService(int id)
        {
            if (StreamServices == null)
            {
                await GetStreamList();
            }

            var existingService = StreamServices.Where(x => x.Id == id).SingleOrDefault();

            if (existingService != null)
            {
                return existingService;
            }
            else
            {
                return null;
            }


        }

        public static async Task AddStreamingService(StreamService service)
        {
            if (StreamServices == null)
            {
                StreamServices = new List<StreamService>();
            }

            service.Id = IdCounter;
            IdCounter++;
            service.IsChecked = null;
            StreamServices.Add(service);
        }

        public static async Task UpdateStreamService(StreamService service, int id)
        {
            var existingService = StreamServices.Where(x => x.Id == id).FirstOrDefault();
            if (existingService != null)
            {
                existingService.Name = service.Name;
            }
        }


        public static async Task RemoveStreamingService(int id)
        {
            StreamServices.RemoveAt(id);   
        }

    }
}
