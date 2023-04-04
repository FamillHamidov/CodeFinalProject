namespace Travel.Web.Models
{
	public class UserViewModel
	{
        public string Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string City { get; set; } = null!;
        public IEnumerable<string> GetUserProps()
        {
            yield return Username;
            yield return Email;
            yield return City;
        }
    }
}
