using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Access_Layer;
using Data_Access_Layer.Repos;
using Data_Access_Layer.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer.Services
{
    public class DonationService
    {
        public static List<DonationDTO> Get()
        {
            var data = DataAccessFactory.DonationData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Donation, DonationDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<DonationDTO>>(data);
            return mapped;
        }

        public static DonationDTO GetId(int id) { 
            var data = DataAccessFactory.DonationData().Read(id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Donation, DonationDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<DonationDTO>(data); 
        }

        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg=>
            {
                cfg.CreateMap<Donation, DonationDTO>();
                cfg.CreateMap<DonationDTO, Donation>();
            });
            return new Mapper(config);
        }
        public static bool Create(DonationDTO d)
        {
            /*var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Donation, DonationDTO>();
            });
            var mapper = new Mapper(cfg);*/

            var data = GetMapper().Map<Donation>(d);
            return DataAccessFactory.DonationData().Create(data);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.DonationData().Delete(id);
        }

        public static DonationDTO GetDonarId(int D_Id)
        {
            var data = DataAccessFactory.DonationData().Read(D_Id);
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Donation, DonationDTO>();
            });
            var mapper = new Mapper(cfg);
            return mapper.Map<DonationDTO>(data);
        }
    }
}
