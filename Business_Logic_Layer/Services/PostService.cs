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
    public class PostService
    {
        public static List<PostDTO> Get()
        {
            var data = DataAccessFactory.PostData().Read();
            var cfg = new MapperConfiguration(c =>
            {
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<List<PostDTO>>(data);
            return mapped;
        }

        public static PostDTO Get(int id) 
        {
            var data = DataAccessFactory.PostData().Read(id);
            var cfg = new MapperConfiguration(c => { 
                c.CreateMap<Post, PostDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostDTO>(data);
            return mapped;
        }

        public static PostCommentDTO GetwithComments(int id)
        {
            var data = DataAccessFactory.PostData().Read(id);
            var cfg = new MapperConfiguration(c => {
                c.CreateMap<Post, PostCommentDTO>();
                c.CreateMap<Comment, CommentDTO>();
            });
            var mapper = new Mapper(cfg);
            var mapped = mapper.Map<PostCommentDTO>(data);
            return mapped;
        }
        static Mapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>();
                cfg.CreateMap<PostDTO, Post>();
            });
            return new Mapper(config);
        }

        public static bool Create(PostDTO d)
        {
            var data = GetMapper().Map<Post>(d);
            return DataAccessFactory.PostData().Create(data);
        }

        public static bool Update(PostDTO d)
        {
            var data = GetMapper().Map<Post>(d);
            return DataAccessFactory.PostData().Update(data);

        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.PostData().Delete(id);
        }
    }
}
