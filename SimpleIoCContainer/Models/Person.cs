namespace SimpleIoCContainer.Models
{
    public class Person
    {
        public Person(int id, string name, short age, Gender gender, decimal scores)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            Scores = scores;
        }

        public int Id { get; }
        
        public string Name { get; set; }

        public short Age { get; set; }

        public Gender Gender { get; set; }

        public decimal Scores { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Person item && Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Name} {Gender.ToString()} {Scores}";
        }
    }
}