using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.RoleModel;
using FirstProgramUI.Models.OfferModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.RoleDto;
using Model.Dtos.OfferDto;
using Model.Entities;
using Model.Dtos.SupplierDto;
using Model.Dtos.ProductDto;
using Model.Dtos.InvoiceDto;
using Model.Dtos.StatusDto;

namespace FirstProgramUI.Controllers
{
    public class OffersController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public OffersController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        FirstProgramContext db = new FirstProgramContext();
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<OfferGetDto>>(url + "Offers/GetOffers");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var val1 = await _httpClient.GetFromJsonAsync<List<SupplierGetDto>>(url + "Suppliers/GetSuppliers/");
            var val2 = await _httpClient.GetFromJsonAsync<List<ProductGetDto>>(url + "Products/GetProducts/");
            OfferGetModel addViewModels = new OfferGetModel()
            {
                Supplier=val1,
                Product=val2,
            };
            return View(addViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Add(OfferGetModel addViewModel)
        {
            OfferPostDto postDto = new OfferPostDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
                OfferAmount= addViewModel.OfferAmount,
                OfferPrice= addViewModel.OfferPrice,
                ProductID= addViewModel.ProductID,
                InvoiceID= addViewModel.InvoiceID,
                SupplierID= addViewModel.SupplierID,
                StatusID= addViewModel.StatusID,

            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Offers/AddNewOffer", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateAll(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<OfferGetDto>(url + "Offers/GetById/" + id);
            var val1 = await _httpClient.GetFromJsonAsync<List<SupplierGetDto>>(url + "Suppliers/GetSuppliers/");
            var val2 = await _httpClient.GetFromJsonAsync<List<ProductGetDto>>(url + "Products/GetProducts/");
            var val3 = await _httpClient.GetFromJsonAsync<List<InvoiceGetDto>>(url + "Invoices/GetInvoices/");
            var val4 = await _httpClient.GetFromJsonAsync<List<StatusGetDto>>(url + "Statuses/GetStatuses/");
            OfferGetModel updateViewModels = new OfferGetModel()
            {
                Product = val2,
                Invoice = val3,
                ID = val.ID,
                Name = val.Name,
                OfferAmount = val.OfferAmount,
                OfferPrice = val.OfferPrice,
                ProductID = val.ProductID,
                InvoiceID = val.InvoiceID,
                SupplierID = val.SupplierID,
                StatusID = val.StatusID,
                ProductName = val.ProductName,
                SupplierName = val.SupplierName,
                InvoiceName = val.InvoiceName,
                StatusName = val.StatusName,
                Supplier = val1,
                Status = val4,
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAll(Guid id, OfferGetModel updateViewModels)
        {
            OfferPutDto putDto = new OfferPutDto()
            {
                Name = updateViewModels.Name,
                OfferAmount = updateViewModels.OfferAmount,
                OfferPrice = updateViewModels.OfferPrice,
                ProductID = updateViewModels.ProductID,
                InvoiceID = updateViewModels.InvoiceID,
                SupplierID = updateViewModels.SupplierID,
                StatusID = updateViewModels.StatusID,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Offers/UpdateAll", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<OfferGetDto>(url + "Offers/GetById/" + id);
            var val1 = await _httpClient.GetFromJsonAsync<List<SupplierGetDto>>(url + "Suppliers/GetSuppliers/");
            var val2 = await _httpClient.GetFromJsonAsync<List<ProductGetDto>>(url + "Products/GetProducts/");
            var val3 = await _httpClient.GetFromJsonAsync<List<InvoiceGetDto>>(url + "Invoices/GetInvoices/");
            var val4 = await _httpClient.GetFromJsonAsync<List<StatusGetDto>>(url + "Statuses/GetStatuses/");
            OfferGetModel updateViewModels = new OfferGetModel()
            {
                
                Product = val2,
                Invoice= val3,ID = val.ID,
                Name = val.Name,
                OfferAmount = val.OfferAmount,
                OfferPrice = val.OfferPrice,
                ProductID=val.ProductID,
                InvoiceID=val.InvoiceID,
                SupplierID=val.SupplierID,
                StatusID=val.StatusID,
                ProductName=val.ProductName,
                SupplierName=val.SupplierName,
                InvoiceName=val.InvoiceName,
                StatusName=val.StatusName,
                Supplier=val1,
                Status=val4,
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, OfferGetModel updateViewModels)
        {
            OfferPutDto putDto = new OfferPutDto()
            {
                Name = updateViewModels.Name,
                OfferAmount = updateViewModels.OfferAmount,
                OfferPrice = updateViewModels.OfferPrice,
                ProductID = updateViewModels.ProductID,
                InvoiceID = updateViewModels.InvoiceID,
                SupplierID = updateViewModels.SupplierID,
                StatusID = updateViewModels.StatusID,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Offers/UpdateOffer", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<OfferGetModel>(url + "Offers/GetById/" + id);

            OfferGetModel deleteViewModel = new OfferGetModel()
            {
                ID = val.ID,
                Name = val.Name,
                OfferAmount = val.OfferAmount,
                OfferPrice = val.OfferPrice,
                ProductName = val.ProductName,
                InvoiceID = val.InvoiceID,
                SupplierID = val.SupplierID,
                StatusID = val.StatusID,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Offers/DeleteOffer/" + id);
            return RedirectToAction("Index");
        }
    }
}
