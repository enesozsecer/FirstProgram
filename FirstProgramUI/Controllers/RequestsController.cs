using FirstProgramUI.Models.CompanyModel;
using FirstProgramUI.Models.RequestModel;
using FirstProgramUI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.CompanyDto;
using Model.Dtos.RequestDto;
using Model.Dtos.UserDto;
using Model.Entities;

namespace FirstProgramUI.Controllers
{
    public class RequestsController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public RequestsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<RequestGetDto>>(url + "Requests/GetRequests");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(RequestGetViewModel addViewModel)
        {
            RequestGetDto postDto = new RequestGetDto()
            {
                ID = addViewModel.ID,
                Description = addViewModel.Description,
                DesiredQuantity = addViewModel.DesiredQuantity,
                CategoryName = addViewModel.CategoryName,
                StatusName = addViewModel.StatusName,
                UserName = addViewModel.UserName,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Requests/AddNewRequest", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<RequestPutDto>(url + "Requests/GetById/" + id);
            RequestUpdateViewModel updateViewModels = new RequestUpdateViewModel()
            {
                ID = val.ID,
                Description=val.Description,
                DesiredQuantity = val.DesiredQuantity,
                CategoryID = val.CategoryID,
                StatusID = val.StatusID,
                UserID = val.UserID,

            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, RequestUpdateViewModel updateViewModels)
        {
            RequestPutDto putDto = new RequestPutDto()
            {
                Description = updateViewModels.Description,
                DesiredQuantity = updateViewModels.DesiredQuantity,
                CategoryID = updateViewModels.CategoryID,
                StatusID = updateViewModels.StatusID,
                UserID = updateViewModels.UserID,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Requests/UpdateRequest", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<RequestGetViewModel>(url + "Requests/GetById/" + id);

            RequestGetViewModel deleteViewModel = new RequestGetViewModel()
            {
                ID = val.ID,
                Description = val.Description,
                DesiredQuantity = val.DesiredQuantity,
                CategoryName = val.CategoryName,
                StatusName = val.StatusName,
                UserName = val.UserName
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Requests/DeleteRequest/" + id);
            return RedirectToAction("Index");
        }
    }
}
