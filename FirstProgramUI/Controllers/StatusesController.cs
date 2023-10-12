using DataAccessLayer.EF.Context;
using FirstProgramUI.Models.StatusModel;
using FirstProgramUI.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using Model.Dtos.StatusDto;

namespace FirstProgramUI.Controllers
{
    public class StatusesController : Controller
    {
        #region Defines
        private readonly HttpClient _httpClient;
        private string url = "https://localhost:7161/api/";
        #endregion

        #region Constructor
        public StatusesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        FirstProgramContext db = new FirstProgramContext();
        #endregion
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var val = await _httpClient.GetFromJsonAsync<List<StatusGetDto>>(url + "Statuses/GetStatuses");
            return View(val);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var val = new StatusGetModel
            {
                Status = db.Statuses.ToList(),
                Request = db.Requests.ToList(),
            };
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StatusGetModel addViewModel)
        {
            StatusGetDto postDto = new StatusGetDto()
            {
                ID = addViewModel.ID,
                Name = addViewModel.Name,
            };
            HttpResponseMessage responseMessage = await _httpClient.PostAsJsonAsync(url + "Statuses/AddNewStatus", postDto);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<StatusPutDto>(url + "Statuses/GetById/" + id);
            StatusGetModel updateViewModels = new StatusGetModel()
            {
                Status = db.Statuses.ToList(),
                Request = db.Requests.ToList(),
                ID = val.ID,
                Name = val.Name,
            };

            return View(updateViewModels);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Guid id, StatusGetModel updateViewModels)
        {
            StatusPutDto putDto = new StatusPutDto()
            {
                Name = updateViewModels.Name,
                ID = id
            };
            HttpResponseMessage httpResponseMessage = await _httpClient.PutAsJsonAsync(url + "Statuses/UpdateStatus", putDto);
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var val = await _httpClient.GetFromJsonAsync<StatusGetModel>(url + "Statuses/GetById/" + id);

            StatusGetModel deleteViewModel = new StatusGetModel()
            {
                ID = val.ID,
                Name = val.Name,
            };

            return View(deleteViewModel);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _httpClient.DeleteAsync(url + "Statuses/DeleteStatus/" + id);
            return RedirectToAction("Index");
        }
    }
}
