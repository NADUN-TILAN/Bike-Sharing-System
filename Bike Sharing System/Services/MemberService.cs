using Bike_Sharing_System.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Bike_Sharing_System.Services
{
    public class MemberService
    {
        private readonly IMongoCollection<Member> _members;

        public MemberService(MongoDBContext context)
        {
            _members = context.GetCollection<Member>("Members");
        }

        public List<Member> GetAllMembers() => _members.Find(member => true).ToList();

        public Member GetMemberByEmail(string email) => _members.Find(member => member.Email == email).FirstOrDefault();

        public void Register(Member member) => _members.InsertOne(member);
    }
}