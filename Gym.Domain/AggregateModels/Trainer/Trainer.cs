namespace Gym.Domain.AggregateModels.Trainer
{
    public class Trainer
    {
        private Trainer() {}
        public Trainer(string name, int age)
        {
            Name=name;
            Age=age;
            IsActive=true;
        }
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }

        public void Disable()
        {
            IsActive = false;
        }
        public void Enable()
        {
            IsActive = true;
        }
    }
}
