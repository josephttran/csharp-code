namespace ListModificationChallenge
{
    public class PersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName}";
            }
        }
    }
}
