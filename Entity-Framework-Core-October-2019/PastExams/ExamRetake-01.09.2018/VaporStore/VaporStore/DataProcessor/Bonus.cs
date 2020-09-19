namespace VaporStore.DataProcessor
{
    using Data;
    using System.Linq;

    public static class Bonus
	{
		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
            var user = context.Users.SingleOrDefault(u => u.Username == username);
            if (user == null)
            {
                return $"User {username} not found";
            }

            var emailAlreadyTaken = context.Users.Any(u => u.Email == newEmail);
            if (emailAlreadyTaken)
            {
                return $"Email {newEmail} is already taken";
            }

            user.Email = newEmail;
            context.SaveChanges();

            return $"Changed {username}'s email successfully";
        }
	}
}
