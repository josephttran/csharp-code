namespace CachingChallenge
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{ Id } { LastName }, { FirstName }";
        }
    }
}
