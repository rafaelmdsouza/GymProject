using Dapper;
using Gym.Domain.AggregateModels.Member;

using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Gym.Infrastructure.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionString;
        public MemberRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Default");
        }
        public async Task<IReadOnlyList<Member>> GetAllAsync()
        {
            using var con = new SqlConnection(connectionString);

            var query = @"SELECT 
                            m.id as Id,
                            m.name as Name, 
                            m.age as Age,
                            m.email as Email,
                            m.[plan] as SelectedPlan,
                            m.subscription as Subscription,
                            t.id as TrainerId,
                            m.register_date as RegisterDate,
                            m.subscription_expiration_date as SubscriptionExpirationDate,
                            m.is_active as IsActive
                            FROM dbo.members m 
                            JOIN dbo.trainer t ON m.trainer_id = t.id";

            var result = await con.QueryAsync<Member>(query);

            return result.ToList();
        }
        public async Task<Member> GetByIdAsync(Guid id)
        {
            using var con = new SqlConnection(connectionString);

            var query = @"SELECT 
                            m.id as Id,
                            m.name as Name, 
                            m.age as Age,
                            m.email as Email,
                            m.[plan] as SelectedPlan,
                            m.subscription as Subscription,
                            t.id as TrainerId,
                            m.register_date as RegisterDate,
                            m.subscription_expiration_date as SubscriptionExpirationDate,
                            m.is_active as IsActive
                            FROM dbo.members m 
                            JOIN dbo.trainer t ON m.trainer_id = t.id
                            WHERE m.Id = @Id";
            var result = await con.QueryFirstOrDefaultAsync<Member>(query, new {Id = id});
            return result;

        }

        public void Add(Member entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Member entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Member entity)
        {
            throw new NotImplementedException();
        }
    }
}
