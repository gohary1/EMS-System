using AutoMapper;
using demo.PL.ViewModel;
using Demo.BLL.Interfaces;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections;
using System.Collections.Generic;
using Demo.BLL.Interfaces;
using System.Reflection.Metadata;
using demo.PL.Helpers;
namespace demo.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private IUnitOfWork _UnitOfWork;
        private IMapper _Mapper;
        public EmployeeController(IUnitOfWork UnitOfWork, IMapper mapper)
        {
            _UnitOfWork = UnitOfWork;
            _Mapper = mapper;
        }
        public IActionResult Index(string nameEmp)
        {
            if (string.IsNullOrEmpty(nameEmp))
            {
                var deparment = _UnitOfWork.EmployeeRepo.GetAll();
                var mapped = _Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(deparment);
                return View(mapped);
            }
            else
            {
                var emp= _UnitOfWork.EmployeeRepo.GetEmpByName(nameEmp);
                var mapped = _Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(emp);
                return View(mapped);
            }
             
            
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(EmployeeViewModel Employee)
        {
            if (ModelState.IsValid)
            {
                Employee.ImageName =DocumentSetting.UploadFile(Employee.Image, "Images");
                var mapped = _Mapper.Map<EmployeeViewModel,Employee>(Employee);
                _UnitOfWork.EmployeeRepo.Add(mapped);
                _UnitOfWork.complete();
                return RedirectToAction(nameof(Index));
            }
            return View(Employee);
        }
        public IActionResult details(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Employee = _UnitOfWork.EmployeeRepo.Get(id);
            var mapped = _Mapper.Map<Employee, EmployeeViewModel>(Employee);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(mapped);

        }
        [HttpGet]
        public IActionResult edit(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var Employee = _UnitOfWork.EmployeeRepo.Get(id);
            var mapped = _Mapper.Map<EmployeeViewModel>(Employee);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(mapped);
        }
        [HttpPost]
        public IActionResult edit(EmployeeViewModel Employee)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    var mapped = _Mapper.Map<EmployeeViewModel, Employee>(Employee);
                    _UnitOfWork.EmployeeRepo.Update(mapped);
                    var count= _UnitOfWork.complete();
                    if (count > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(Employee);
        }
        [HttpGet]
        public IActionResult delete(int id)
        {

            if (id == null)
            {
                return BadRequest();
            }
            var Employee = _UnitOfWork.EmployeeRepo.Get(id);
            var mapped = _Mapper.Map<Employee, EmployeeViewModel>(Employee);
            if (Employee == null)
            {
                return NotFound();
            }
            return View(mapped);
        }
        [HttpPost]
        public IActionResult delete(EmployeeViewModel Employee)//HENA LEEH elid biigy bnull??
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    var mapped = _Mapper.Map<EmployeeViewModel, Employee>(Employee);
                    _UnitOfWork.EmployeeRepo.Delete(mapped);
                    var count = _UnitOfWork.complete();
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
