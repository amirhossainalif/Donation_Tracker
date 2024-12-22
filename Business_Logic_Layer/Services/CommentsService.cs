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
    public class CommentsService
    {
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Comment, CommentDTO>();
                cfg.CreateMap<CommentDTO, Comment>();
            });
            return new Mapper(config);
        }

        public static bool Create(CommentDTO d)
        {
            var data = GetMapper().Map<Comment>(d);
            return DataAccessFactory.CommentData().Create(data);
        }

        public static bool Update(CommentDTO d)
        {
            var data = GetMapper().Map<Comment>(d);
            return DataAccessFactory.CommentData().Update(data);

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CommentData().Delete(id);
        }
    }
}
