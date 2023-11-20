using BlazorWasmSample.wwwroot.Data;

namespace BlazorTest.Classes
{
    public interface IFunkoAPI
    {
        Task<List<FunkoPops>> GetFunkos();
    }

    public class TestClassUsingFunkoAPI : IFunkoAPI
    {
        private readonly IFunkoAPI _funkoAPI;

        public TestClassUsingFunkoAPI(IFunkoAPI funkoAPI)
        {
            _funkoAPI = funkoAPI;
        }

        public async Task<List<FunkoPops>> GetFunkos()
        {
            return await _funkoAPI.GetFunkos();
        }
    }

}
