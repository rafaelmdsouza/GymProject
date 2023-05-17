namespace Gym.Domain.AggregateModels.Member
{
    public class Member
    {
        private Member() { }

        public Member(string name, int age, string email, GymPlan plan, GymSubscription subscription)
        {
            Id = Guid.NewGuid();
            Name = name;
            Age = age;
            Email = email;
            SelectedPlan = plan;
            Subscription = subscription;
            RegisterDate = DateTime.Now;
            IsActive = true;
            TrainerId = null;
            LastModified = DateTime.Now;
            SubscriptionExpirationDate = CalculateSubscriptionExpirationDate(RegisterDate, Subscription);
        }

        public Guid Id { get; private  set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public GymPlan SelectedPlan { get; private set; }
        public GymSubscription Subscription { get; private set; }
        public Guid? TrainerId { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime RegisterDate { get; private set; }
        public DateTime LastModified { get; private set; }
        public DateTime SubscriptionExpirationDate { get; private set; }

        public static DateTime CalculateSubscriptionExpirationDate(DateTime registerDate, GymSubscription subscription)
        {
            switch (subscription)
            {
                case GymSubscription.Monthly:
                    registerDate = registerDate.AddMonths(1);
                    break;

                case GymSubscription.Yearly:
                    registerDate = registerDate.AddYears(1);
                    break;

            }
            return registerDate;
        }

        public void AddTrainer(Guid trainerId)
        {
            TrainerId = trainerId;
            LastModified = DateTime.Now;
        }
        public void ChangePlan(GymPlan plan)
        {
            SelectedPlan = plan;
            LastModified = DateTime.Now;
        }
        public void ChangeSubscription(GymSubscription subscription)
        {
            Subscription = subscription;
            LastModified = DateTime.Now;
            SubscriptionExpirationDate = CalculateSubscriptionExpirationDate(LastModified, subscription);
        }
        public void Update(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
            LastModified = DateTime.Now;
        }
        public void Disable()
        {
            IsActive = false;
            LastModified = DateTime.Now;
        }
        public void Enable()
        {
            IsActive = true;
            LastModified = DateTime.Now;
        }
    }
}
