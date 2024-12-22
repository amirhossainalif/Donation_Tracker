using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class DonorService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Donor, DonorDTO>();
                cfg.CreateMap<DonorDTO, Donor>();
            });
            return new Mapper(config);
        }

        public static bool Create(DonorDTO d)
        {
            var data = GetMapper().Map<Donor>(d);
            return DataAccessFactory.DonarData().Create(data);
        }

        public static List<DonorDTO> Get()
        {
            var data = DataAccessFactory.DonarData().Read();
            return GetMapper().Map<List<DonorDTO>>(data);
        }
        public static DonorDTO GetID(int id) {
            var data = DataAccessFactory.DonarData().Read(id);
            return GetMapper().Map<DonorDTO>(data);
        }
        public static bool Update(DonorDTO d) {
            var data = GetMapper().Map<Donor>(d);
            return DataAccessFactory.DonarData().Update(data);

        }
        public static bool Delete(int id) {
            return DataAccessFactory.DonarData().Delete(id);
        }
    }
}
