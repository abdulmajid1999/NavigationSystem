using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using navitem.Models;

public class AdminController : Controller
{
    private readonly IRepository<NavigationItem> _repository;

    public AdminController(IRepository<NavigationItem> repository)
    {
        _repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _repository.GetAllAsync();
        return View(items); 
    }

    public async Task<IActionResult> Create()
    {
        var items = await _repository.GetAllAsync();
        var viewModel = new NavigationItemViewModel
        {
            ParentItems = items.ToList()
        };
        return View(viewModel); 
    }

    [HttpPost]
    public async Task<IActionResult> Create(NavigationItemViewModel viewModel)
    {
            var item = new NavigationItem
            {
                Name = viewModel.Name,
                ParentId = viewModel.ParentId
            };
            await _repository.AddAsync(item);
            return RedirectToAction(nameof(Index));
       
    }

    public async Task<IActionResult> Edit(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null) return NotFound();

        var items = await _repository.GetAllAsync();
        var viewModel = new NavigationItemViewModel
        {
            Id = item.Id,
            Name = item.Name,
            ParentId = item.ParentId,
            ParentItems = items.Where(i => i.Id != id).ToList()
        };
        return View(viewModel); 
    }

    [HttpPost]
    public async Task<IActionResult> Edit(NavigationItemViewModel viewModel)
    {
   
            var item = await _repository.GetByIdAsync(viewModel.Id);
            if (item == null) return NotFound();

            item.Name = viewModel.Name;
            item.ParentId = viewModel.ParentId;
            await _repository.UpdateAsync(item);
            return RedirectToAction(nameof(Index));
        
    }

   
    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
