using AutoMapper;
using demo.PL.ViewModel;
using Demo.DAL.Models;

namespace demo.PL.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
        }
    }
}
