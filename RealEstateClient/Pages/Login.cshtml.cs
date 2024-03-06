﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BusinessObject.BusinessObject;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using RealEstateClient.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RealEstateClient.Pages
{
    public class LoginModel : PageModel
    {
        private readonly HttpClient client;
        private string ApiUrl = "";

        public LoginModel()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            ApiUrl = "https://localhost:7088/api/Auth/Login";
        }

        [BindProperty]
        public User User { get; set; } = default!;
        [BindProperty]
        public LoginVM loginVM { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                string strData = JsonSerializer.Serialize(loginVM);
                var contentData = new StringContent(strData, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await client.PostAsync(ApiUrl, contentData);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = await response.Content.ReadAsStringAsync();
                    var token = JsonSerializer.Deserialize<string>(responseData);

                    if (!string.IsNullOrEmpty(token))
                    {
                        TempData["JwtToken"] = token;

                        var handler = new JwtSecurityTokenHandler();
                        var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                        var roleClaim = jsonToken?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role);

                        if (roleClaim?.Value == "1") //customer
                        {
                            return RedirectToPage("./Admin/Index");
                        }
                        else if (roleClaim?.Value == "Admin") //Admin
                        {
                            return RedirectToPage("./Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            ViewData["ErrorMessage"] = "Email or Password is wrong!";
            return Page();
        }
    }
}