using FirstProgramUI.Models;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CompanyDto;
using Model.Dtos.ProductDto;
using Model.Entities;

namespace FirstProgramUI.Controllers
{
    public class CompaniesController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "http://localhost:7161/api/";
        #endregion

        #region Constructor
        public CompaniesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion
        public async Task<IActionResult> Index()
        {
            //var val = await _httpClient.GetFromJsonAsync<List<CompanyGetDto>>(url + "Companies/getcompanies");
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Add(CompanyViewModel addViewModel)
        //{
        //    Company postDto = new Company()
        //    {
        //        ID = addViewModel.ID,
        //        Name = addViewModel.Name,
               

        //    };
        //    HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Companies/addnewcompany", postDto);
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public async Task<IActionResult> Update(int id)
        //{
        //    var val = await _httpClient.GetFromJsonAsync<CompanyGetDto>(url + "Companies/GetById/" + id);

        //    CompanyViewModel updateViewModels = new CompanyViewModel()
        //    {
        //        ID = val.ID,
        //        Name = val.Name,
        //    };

        //    return View(updateViewModels);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Update(int id, CompanyViewModel updateViewModels)
        //{

        //    CompanyPutDto putDto = new CompanyPutDto()
        //    {
        //        ID = updateViewModels.ID,
        //        Name = updateViewModels.Name,
        //    };
        //    HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Companies/updatecompany", putDto);
        //    if (httpResponseMessage.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        //[HttpGet]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var val = await _httpClient.GetFromJsonAsync<ProductGetDto>(url + "Companies/GetById/" + id);

        //    CompanyViewModel deleteViewModel = new CompanyViewModel()
        //    {
        //        ID = val.ID,
        //        Name = val.Name,

        //    };

        //    return View(deleteViewModel);
        //}
        //[HttpPost, ActionName("deletecompany")]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    await _httpClient.DeleteAsync(url + "Companies/DeleteCompany?id=" + id);
        //    return RedirectToAction("Index");
        //}
    }
}
