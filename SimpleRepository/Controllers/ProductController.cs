using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleRepository.Core.Interfaces;
using AutoMapper;
using SimpleRepository.Persistence.Model;
using SimpleRepository.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SimpleRepository.Controllers
{
    public class ProductController : Controller
    {
        private readonly IRepository<Category> repoCategory;
        private readonly IRepository<Product> repoProduct;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IRepository<Category> repoCateg, IRepository<Product> repo, IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.repoProduct = repo;
            this.repoCategory = repoCateg;
            this._mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            
            var list = repoProduct.GetAll();

            var result = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(list);
            return View(result);
        }

        public IActionResult Create()
        {
            var listCateg = repoCategory.GetAll();
            var listCategView = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(listCateg);
            ViewData["Categories"] = new SelectList(listCategView, "Id","Name");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var listCateg = repoCategory.GetAll();
                var listCategView = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(listCateg);
                ViewData["Categories"] = new SelectList(listCategView, "Id", "Name");
                return View(viewModel);
            }

            var model = _mapper.Map<ProductViewModel, Product>(viewModel);
            repoProduct.Insert(model);
            await unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}