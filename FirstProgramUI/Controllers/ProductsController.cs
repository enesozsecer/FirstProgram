using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.ProductModel;
using FirstProgramUI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.ProductDto;
using Model.Dtos.UserDto;

namespace FirstProgramUI.Controllers
{
    public class ProductsController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        FirstProgramContext db= new FirstProgramContext();

        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<ProductGetDto>>(url + "Products/GetProducts");
            return View(val);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var val = new ProductGetModel
            {
                Cateogry = db.Categories.ToList(),
                Product=db.Products.ToList(),
                Offer = db.Offers.ToList(),
            };
            return View(val);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductGetModel addViewModel)
        {
            ProductGetDto postDto = new ProductGetDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
                StockQuantity = addViewModel.StockQuantity,
                ProductPrice = addViewModel.ProductPrice,
                CategoryName = addViewModel.CategoryName,
                OfferName = addViewModel.OfferName,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Products/AddNewProduct", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<ProductPutDto>(url + "Products/GetById/" + id);
            ProductGetModel updateViewModels = new ProductGetModel()
            {
                Cateogry = db.Categories.ToList(),
                Product = db.Products.ToList(),
                Offer = db.Offers.ToList(),
                ID = val.ID,
                Name = val.Name,
                StockQuantity = val.StockQuantity,
                ProductPrice = val.ProductPrice,
                //CategoryID = val.CategoryID,
                //OfferID = val.OfferID,

            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, ProductGetModel updateViewModels)
        {
            ProductPutDto putDto = new ProductPutDto()
            {
                Name = updateViewModels.Name,
                StockQuantity = updateViewModels.StockQuantity,
                ProductPrice = updateViewModels.ProductPrice,
                CategoryID = updateViewModels.CategoryID,
                OfferID = updateViewModels.OfferID,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Products/UpdateProduct", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<ProductGetModel>(url + "Products/GetById/" + id);

            ProductGetModel deleteViewModel = new ProductGetModel()
            {
                ID = val.ID,
                Name = val.Name,
                StockQuantity = val.StockQuantity,
                ProductPrice = val.ProductPrice,
                CategoryName = val.CategoryName,
                OfferName = val.OfferName,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Products/DeleteProduct/" + id);
            return RedirectToAction("Index");
        }
    }
}
