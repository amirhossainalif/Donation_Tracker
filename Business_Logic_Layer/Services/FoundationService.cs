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
    public class FoundationService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Foundation, FoundationDTO>();
                cfg.CreateMap<FoundationDTO, Foundation>();
            });
            return new Mapper(config);
        }

        public static bool Create(FoundationDTO d)
        {
            var data = GetMapper().Map<Foundation>(d);
            return DataAccessFactory.FundationData().Create(data);
        }

        public static List<FoundationDTO> Get()
        {
            var data = DataAccessFactory.FundationData().Read();
            return GetMapper().Map<List<FoundationDTO>>(data);
        }
        public static FoundationDTO GetID(int id)
        {
            var data = DataAccessFactory.FundationData().Read(id);
            return GetMapper().Map<FoundationDTO>(data);
        }
        public static bool Update(FoundationDTO d)
        {
            var data = GetMapper().Map<Foundation>(d);
            return DataAccessFactory.FundationData().Update(data);

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.FundationData().Delete(id);
        }
    }
}
