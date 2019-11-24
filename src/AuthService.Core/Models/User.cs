using System;

namespace AuthService.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime CreatedAt { get;  set; }
        public DateTime LastActive  { get; set; }

		public User()
		{

		}

        public User(string username, 
                    string email,
                    byte[] passwordHash, 
                    byte[] passwordSalt, 
                    string avatarUrl = null)
        {
            this.Username = username;
            this.Email = email;
            this.AvatarUrl = avatarUrl;
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.CreatedAt = DateTime.UtcNow;
            this.LastActive = DateTime.UtcNow;
        }
    }
}