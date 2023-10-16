using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.AuthenticationModel;
using FirstProgramUI.Models.OfferModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.AuthenticateDto;
using Model.Dtos.OfferDto;

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
            return View();
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

            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Offers/AddNewOffer", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<OfferPutDto>(url + "Offers/GetById/" + id);
            OfferGetModel updateViewModels = new OfferGetModel()
            {
                ID = val.ID,
                Name = val.Name,
                OfferAmount = val.OfferAmount,
                OfferPrice = val.OfferPrice,
                ProductID = val.ProductID,
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
                ProductPrice = val.ProductPrice,
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
