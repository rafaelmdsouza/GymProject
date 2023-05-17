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
							m.trainer_id as TrainerId,
                            m.register_date as RegisterDate,
                            m.subscription_expiration_date as SubscriptionExpirationDate,
                            m.last_modified as LastModified,
                            m.is_active as IsActive
                            FROM dbo.members m";

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
							m.trainer_id as TrainerId,
                            m.register_date as RegisterDate,
                            m.subscription_expiration_date as SubscriptionExpirationDate,
                            m.last_modified as LastModified,
                            m.is_active as IsActive
                            FROM dbo.members m
                            WHERE m.Id = @Id";
            var result = await con.QueryFirstOrDefaultAsync<Member>(query, new {Id = id});
            return result;

        }
        public async void Add(Member entity)
        {
            var query = @"INSERT INTO dbo.Members 
                        (id, name, age, email, [plan], subscription, trainer_id, register_date, subscription_expiration_date, is_active, last_modified)
                        VALUES (@Id, @Name, @Age, @Email, @SelectedPlan, @Subscription, @TrainerId, @RegisterDate, @SubscriptionExpirationDate, @IsActive, @LastModified)
                        ";
            using var con = new SqlConnection(connectionString);
            await con.ExecuteAsync(query, entity);
        }

        public void Delete(Guid id, Member entity)
        {
            throw new NotImplementedException();
        }

        public async void Update(Guid id, Member entity)
        {
            var query = @"UPDATE [dbo].[members]
                                SET [name] = @Name,
                                   [email] = @Email,
                                   [plan] = @SelectedPlan,
                                   [subscription] = @Subscription,
                                   [is_active] = @IsActive
                                WHERE id = @Id";

            using var con = new SqlConnection(connectionString);
            await con.ExecuteAsync(query, entity);
        }

    }
}
