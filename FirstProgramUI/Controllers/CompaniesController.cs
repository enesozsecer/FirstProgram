﻿using Azure;
using FirstProgramUI.Models.CompanyModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CompanyDto;
using Model.Dtos.ProductDto;
using Model.Entities;
using Newtonsoft.Json;


namespace FirstProgramUI.Controllers
{
    public class CompaniesController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public CompaniesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<CompanyGetDto>>(url + "Companies/GetCompanies");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CompanyViewModel addViewModel)
        {
            Company postDto = new Company()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Companies/AddNewCompany", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<CompanyGetDto>(url + "Companies/GetById/" + id);

            CompanyViewModel updateViewModels = new CompanyViewModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, CompanyViewModel updateViewModels)
        {

            CompanyPutDto putDto = new CompanyPutDto()
            {
                Name = updateViewModels.Name,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Companies/UpdateCompany", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<CompanyGetDto>(url + "Companies/GetById/" + id);

            CompanyViewModel deleteViewModel = new CompanyViewModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Companies/DeleteCompany/" + id);
            return RedirectToAction("Index");
        }
    }
}
