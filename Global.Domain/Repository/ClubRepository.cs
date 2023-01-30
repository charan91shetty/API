using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Global.DataAccess.Data;
using Global.DataAccess.Data.Table;
using Global.Domain.Model;
using Global.Domain.Model.enums;
using Global.Domain.Repository.Interface;

namespace Global.Domain.Repository
{
    public class ClubRepository : IClubRepository
    {
        private FunBooksAndVideosStoreDbContext _funBooksAndVideosStoreDbContext;
        private IMapper _mapper;

        public ClubRepository(FunBooksAndVideosStoreDbContext funBooksAndVideosStoreDbContext, IMapper mapper)
        {
            _funBooksAndVideosStoreDbContext = funBooksAndVideosStoreDbContext;
            _mapper = mapper;
        }
        public async Task<int> CreateClub(ClubModel model)
        {
            try
            {
                var clubModel = _mapper.Map<Club>(model);
                var clubData = _funBooksAndVideosStoreDbContext.Clubs.Add(clubModel);
                _funBooksAndVideosStoreDbContext.SaveChanges();
                //todo -need to identify how map data reverse from dbset object to model object
                // var clubModelObject = _mapper.Map<ClubModel>(clubData);
                return clubData.Entity.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return -1;
            }

        }
    }
}

