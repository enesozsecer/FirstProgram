using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.InvoiceModel;
using FirstProgramUI.Models.ProductModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.InvoiceDto;
using Model.Dtos.ProductDto;
using Model.Dtos.SupplierDto;
using Model.Entities;

namespace FirstProgramUI.Controllers
{
    public class InvoicesController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public InvoicesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<InvoiceGetDto>>(url + "Invoices/GetInvoices");
            return View(val);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var val1 = await _httpClient.GetFromJsonAsync<List<Supplier>>(url + "Suppliers/GetSuppliers");
            InvoiceGetModel addViewModel = new InvoiceGetModel
            {
                Supplier = val1,
            };
            return View(addViewModel);


        }

        [HttpPost]
        public async Task<IActionResult> Add(InvoiceGetModel addViewModel)
        {
            InvoicePostDto postDto = new InvoicePostDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
                OrderAmount = addViewModel.OrderAmount,
                OrderPrice = addViewModel.OrderPrice,
                SupplierID = addViewModel.SupplierID,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Invoices/AddNewInvoice", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<InvoicePutDto>(url + "Invoices/GetById/" + id);
            var val1 = await _httpClient.GetFromJsonAsync<List<Supplier>>(url + "Suppliers/GetSuppliers");
            InvoiceGetModel updateViewModels = new InvoiceGetModel()
            {
                Supplier = val1,
                ID = val.ID,
                Name = val.Name,
                OrderAmount = val.OrderAmount,
                OrderPrice = val.OrderPrice,
                SupplierID = val.SupplierID,

            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, InvoiceGetModel updateViewModels)
        {
            InvoicePutDto putDto = new InvoicePutDto()
            {
                Name = updateViewModels.Name,
                OrderAmount = updateViewModels.OrderAmount,
                OrderPrice = updateViewModels.OrderPrice,
                SupplierID = updateViewModels.SupplierID,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Invoices/UpdateInvoice", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<InvoiceGetModel>(url + "Invoices/GetById/" + id);
            var val1 = await _httpClient.GetFromJsonAsync<List<Supplier>>(url + "Suppliers/GetSuppliers");

            InvoiceGetModel deleteViewModel = new InvoiceGetModel()
            {
                ID = val.ID,
                Name = val.Name,
                OrderAmount = val.OrderAmount,
                OrderPrice = val.OrderPrice,
                Supplier=val1,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Invoices/DeleteInvoice/" + id);
            return RedirectToAction("Index");
        }
    }
}
