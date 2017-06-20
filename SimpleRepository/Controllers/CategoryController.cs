using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleRepository.Core.Interfaces;
using SimpleRepository.Persistence.Model;
using SimpleRepository.ViewModels;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleRepository.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category> repoCategory;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IRepository<Category> repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repoCategory = repo;
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var list = repoCategory.GetAll();
            var result = _mapper.Map<IEnumerable<Category>,IEnumerable<CategoryViewModel>>(list);
            return View(result);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryViewModel viewModel)
        {
            var model = _mapper.Map<CategoryViewModel, Category>(viewModel);
            repoCategory.Insert(model);
            await unitOfWork.Complete();
            return RedirectToAction("Index");
        }
    }
}