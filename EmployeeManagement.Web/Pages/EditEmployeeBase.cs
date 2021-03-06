﻿using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase :ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public string PageHeaderText { get; set; }

        private Employee Employee { get; set; } = new Employee();

        public EditEmployeeModel EditEmployeeModel { get; set; } = new EditEmployeeModel();

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new list<Department>();
        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            if (employeeId != 0)
            {
                PageHeaderText = "Edit Employee";
                Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            }
            else
            {
                PageHeaderText = "Create Employee";
                Employee = new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/noImage.jpg"
                };
            }
            Departments = (await DepartmentService.GetDepartments()).ToList();

            Mapper.Map(Employee, EditEmployeeModel);

            //EditEmployeeModel.EmployeeId = Employee.EmployeeId;
            //EditEmployeeModel.FirstName = Employee.FirstName;
            //EditEmployeeModel.LastName = Employee.LastName;
            //EditEmployeeModel.DateOfBirth = Employee.DateOfBirth;
            //EditEmployeeModel.Email = Employee.Email;
            //EditEmployeeModel.ConfirmEmail = Employee.Email;
            //EditEmployeeModel.Department = Employee.Department;
            //EditEmployeeModel.DepartmentId = Employee.DepartmentId;
            //EditEmployeeModel.Gender = Employee.Gender;
            //EditEmployeeModel.PhotoPath = Employee.PhotoPath;

        }

        protected async Task HandleValidSubmit()
        {
            Employee result = null;
            Mapper.Map(EditEmployeeModel,Employee);

            if (Employee.EmployeeId != 0)
            {
                result = await EmployeeService.UpdateEmployee(Employee);
            }
            else
            {
                result = await EmployeeService.CreateEmployee(Employee);
            }
           
            if (result != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }
        public AKSB.Components.ConfirmBase DeleteConfirmation { get; set; }
        protected void Delete_Click()
        {
            DeleteConfirmation.Show();
        }
        [Parameter]
        public EventCallback<int> OnEmployeeDeleted { get; set; }
        protected async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(Employee.EmployeeId);
                await OnEmployeeDeleted.InvokeAsync(Employee.EmployeeId);
                NavigationManager.NavigateTo("/");
            }
        }
        //protected async Task Delete_Click()
        //{
        //    await EmployeeService.DeleteEmployee(Employee.EmployeeId);
        //    NavigationManager.NavigateTo("/");
        //}
    }
}
