using FirstProgramUI.Models.InvoiceModel;
using FirstProgramUI.Models.SupplierModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.InvoiceDto;
using Model.Dtos.SupplierDto;
using Model.Entities;

namespace FirstProgramUI.Controllers
{
    public class SuppliersController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public SuppliersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<SupplierGetDto>>(url + "Suppliers/GetSuppliers");
            return View(val);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var val1 = await _httpClient.GetFromJsonAsync<List<Category>>(url + "Categories/GetCategories");
            SupplierGetModel addViewModel = new SupplierGetModel
            {
                Category = val1,
            };
            return View(addViewModel);


        }

        [HttpPost]
        public async Task<IActionResult> Add(SupplierGetModel addViewModel)
        {
            SupplierPostDto postDto = new SupplierPostDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
                CategoryID = addViewModel.CategoryID,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Suppliers/AddNewSupplier", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<SupplierPutDto>(url + "Suppliers/GetById/" + id);
            var val1 = await _httpClient.GetFromJsonAsync<List<Category>>(url + "Categories/GetCategories");
            SupplierGetModel updateViewModels = new SupplierGetModel()
            {
                Category = val1,
                ID = val.ID,
                Name = val.Name,
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, SupplierGetModel updateViewModels)
        {
            SupplierPutDto putDto = new SupplierPutDto()
            {
                Name = updateViewModels.Name,
                CategoryID= updateViewModels.CategoryID,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Suppliers/UpdateSupplier", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<SupplierGetModel>(url + "Suppliers/GetById/" + id);
            var val1 = await _httpClient.GetFromJsonAsync<List<Category>>(url + "Categories/GetCategories");

            SupplierGetModel deleteViewModel = new SupplierGetModel()
            {
                ID = val.ID,
                Name = val.Name,
                Category=val1,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Suppliers/DeleteSupplier/" + id);
            return RedirectToAction("Index");
        }
    }
}
