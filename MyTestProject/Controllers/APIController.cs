using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace MyTestProject.Controllers
{
    public class APIController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        public APIController()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IActionResult> GetBarcode(string token, string productCode)
        {
            //Create a HttpClient instance.
            HttpClient httpClient = new HttpClient();

            // Set the bearer token header.
            string bearerToken = token;
            //string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJyb2xlIjpbIkFkbWluIiwiVXNlciIsIlByb2plU29mdCJdLCJzdWIiOiJla3JlbS55YWxjaW5AZG9nb3N0b3JlLmNvbSIsIm5iZiI6MTY4ODYyNDkyNiwiZXhwIjoxNzIwNDI0OTI2LCJpc3MiOiJodHRwczovL2RvZ29zdG9yZS5jb20iLCJhdWQiOiJodHRwczovL2RvZ29zdG9yZS5jb20ifQ.iQBvgymutG9dgX1wtmn4dHiHPqoMoWDKoaT30aeCSM0";
            AuthenticationHeaderValue bearerTokenHeader = new AuthenticationHeaderValue("Bearer", bearerToken);
            httpClient.DefaultRequestHeaders.Authorization = bearerTokenHeader;

            // Send the request.
            var response = await httpClient.GetAsync("https://dogoapi.dogostore.com/api/Nebim/getProductStockByItemCode?itemCode=" + productCode);//dgsnk022-291");

            // Check the response status code.
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string responseData = await response.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject(responseData);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
