using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;
using LifeManager_BlazorServerUI.Wrappers;
using Newtonsoft.Json;
using LifeManager_BlazorServerUI.ViewModels;
using LifeManager_BlazorServerUI.Models;

namespace LifeManager_BlazorServerUI.Services
{
    public interface IPropertyService
    {
        Task<List<Car>> GetCars();
    }

    public class PropertyService : IPropertyService
    {
        private readonly IHttpClientWrapper _httpClientWrapper;

        public PropertyService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<List<Car>> GetCars()
        {
            //await Task.Delay(0);
            try
            {
                await Task.Delay(0);
                var httpClient = new HttpClient();
                // Cars gets hydrated when it gets called from the SubmitHander in the ViewModel
                // Still not sure why it isn't working here...maybe something to do
                // with the initialization process?
                var Cars = await httpClient.GetFromJsonAsync<List<Car>>("https://localhost:3001/propertyservice");
                return Cars;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Shit!");
                throw;
            }
        }
    }
}
