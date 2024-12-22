using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer.Models.Tables;
using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class EmployeeService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDTO>();
                cfg.CreateMap<EmployeeDTO, Employee>();
            });
            return new Mapper(config);
        }

        public static bool Create(EmployeeDTO d)
        {
            var data = GetMapper().Map<Employee>(d);
            return DataAccessFactory.EmployeeData().Create(data);
        }

        public static List<EmployeeDTO> Get()
        {
            var data = DataAccessFactory.EmployeeData().Read();
            return GetMapper().Map<List<EmployeeDTO>>(data);
        }
        public static EmployeeDTO GetID(int id)
        {
            var data = DataAccessFactory.EmployeeData().Read(id);
            return GetMapper().Map<EmployeeDTO>(data);
        }
        public static bool Update(EmployeeDTO d)
        {
            var data = GetMapper().Map<Employee>(d);
            return DataAccessFactory.EmployeeData().Update(data);

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.EmployeeData().Delete(id);
        }
    }
}
