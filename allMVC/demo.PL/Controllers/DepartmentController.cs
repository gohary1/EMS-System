using Demo.BLL.Interfaces;
using Demo.BLL.Repo;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;

namespace demo.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private IUnitOfWork _IUnitOfWork;
        public DepartmentController(IUnitOfWork UnitOfWork)
        {
            _IUnitOfWork=UnitOfWork;
        }
        public IActionResult Index()
        {
            var deparment = _IUnitOfWork.DepRepo.GetAll();
            return View(deparment);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(Department department)
        {
            if(ModelState.IsValid)
            {
                _IUnitOfWork.DepRepo.Add(department);
                var count = _IUnitOfWork.complete();
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(department);
        }
        
        public IActionResult details(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var department= _IUnitOfWork.DepRepo.Get(id);
            if(department == null)
            {
                return NotFound();
            }
            return View(department);
            
        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var department = _IUnitOfWork.DepRepo.Get(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult edit(Department department)
        {
            try
            {
            if (ModelState.IsValid)
            {
                 _IUnitOfWork.DepRepo.Update(department);
                    var count = _IUnitOfWork.complete();
                if (count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,ex.Message);
            }
            return View(department);
        }
        [HttpGet]
        public IActionResult delete(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var department = _IUnitOfWork.DepRepo.Get(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        [HttpPost]
        public IActionResult delete(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _IUnitOfWork.DepRepo.Delete(department);
                    var count = _IUnitOfWork.complete();
                        return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(nameof(Index));
        }

    }
}
