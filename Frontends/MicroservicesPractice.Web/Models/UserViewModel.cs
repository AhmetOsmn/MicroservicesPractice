namespace MicroservicesPractice.Web.Models
{
    public class UserViewModel
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? City { get; set; }

        public IEnumerable<string?> GetUserProps()
        {
            yield return UserName;
            yield return Email;
            yield return City;
        }
    }
}
