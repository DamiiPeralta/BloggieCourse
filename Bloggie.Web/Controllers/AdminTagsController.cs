using Bloggie.Web.Data;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Bloggie.Web.Repositories;

namespace Bloggie.Web.Controllers
{
    //si lo ponemos aca afecta a todos los endpoints
    [Authorize(Roles = "Admin")]
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;
        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        //este endpoint es accesible solo por un usuario cuyo rol sea admin
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            ValidateAddTagRequest(addTagRequest);
            if (!ModelState.IsValid)
            {
                return View();
            }
            //Mapping AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };
            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List(
            string? searchQuery, 
            string? sortBy, 
            string? sortDirection,
            int pageSize = 3,
            int pageNumber = 1)
        {
            var totalRecords = await tagRepository.CountAsync();
            var totalPages = Math.Ceiling((decimal)totalRecords / pageSize);

            if(pageNumber > totalPages)
            {
                pageNumber--;
            }
            if(pageNumber < 1)
            {
                pageNumber++;
            }

            ViewBag.TotalPages = totalPages;
            ViewBag.PageSize = pageSize;
            ViewBag.SearchQuery = searchQuery;
            ViewBag.SortBy = sortBy;
            ViewBag.PageNumber = pageNumber;
            ViewBag.SortDirection = sortDirection;
            //use dbContext to read the tags
            var tags = await tagRepository.GetAllAsync(searchQuery, sortBy, sortDirection, pageNumber, pageSize);

            return View(tags);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            // 1st method
            // var tag = bloggieDbContext.Tags.Find(id);

            // 2nd Method
            var tag = await tagRepository.GetAsync(id);
            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,
                };
                return View(editTagRequest);
            }
            return View(null);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName,
            };
            var existingTag = await tagRepository.UpdateAsync(tag);
            if (existingTag != null)
            {
                // Show success notification
            }
            else
            {
                //Show failure notification
            }
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var tag = await tagRepository.DeleteAsync(editTagRequest.Id);
            if (tag != null)
            {
                //Show a success notification
                return RedirectToAction("List");
            }
            //Show an error notification
            return RedirectToAction("Edit", new {id = editTagRequest.Id});
        }

        private void ValidateAddTagRequest(AddTagRequest request)
        {
            if(request.Name is not null && request.DisplayName is not null)
            {
                if(request.Name == request.DisplayName)
                {
                    ModelState.AddModelError("DisplayName", "Name and Display Name cannot be the same");
                }
            }
        }
    }
}
