using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Global.DataAccess.Data;
using Global.DataAccess.Data.Table;
using Global.Domain.Model;
using Global.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Global.Domain.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        private FunBooksAndVideosStoreDbContext _funBooksAndVideosStoreDbContext;
        private IMapper _mapper;

        public MembershipRepository(FunBooksAndVideosStoreDbContext funBooksAndVideosStoreDbContext, IMapper mapper)
        {
            _funBooksAndVideosStoreDbContext = funBooksAndVideosStoreDbContext;
            _mapper = mapper;
        }

        public async Task<List<MembershipModel>> GetAllMembershipAsync()
        {
            var records = await _funBooksAndVideosStoreDbContext.Memberships.ToListAsync();
            return _mapper.Map<List<MembershipModel>>(records);
        }

        public async Task<MembershipModel> GetMembershipByIdsAsync(int membershipId)
        {
            var record = await _funBooksAndVideosStoreDbContext.Memberships.FindAsync(membershipId);
            return _mapper.Map<MembershipModel>(record);
        }

        public async Task<int> AddMemberAsync(MembershipModel model)
        {
            var membership = _mapper.Map<Membership>(model);
            _funBooksAndVideosStoreDbContext.Memberships.Add(membership);
            _funBooksAndVideosStoreDbContext.SaveChanges();
            return membership.Id;
        }
    }
}
