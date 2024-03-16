using BusinessObject.BusinessObject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

namespace RealEstateClient.Pages.UserPage
{
    public class ProfilePageModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";

        public ProfilePageModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Users";
        }

        [BindProperty]
        public User User { get; set; } = default!;

        public int UserID;
        public RealEstate RealEstate { get; set; } = default!;
        public int RealEstateID;

        
        public async Task<IActionResult> OnGetAsync(int? id)
        {

            var token = HttpContext.Request.Cookies["UserCookie"];

            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("/Login"); // Không tìm thấy token trong cookie
            }
            HttpResponseMessage response = await client.GetAsync($"{ApiUrl}/{id}");
            string strData = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var _user = JsonSerializer.Deserialize<User>(strData, options)!;

            var _realEstate = JsonSerializer.Deserialize<RealEstate>(strData, options)!;

            RealEstate = _realEstate;
            
            User = _user;
            return Page();
        }
    }
}
