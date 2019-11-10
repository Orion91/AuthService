using System;

namespace AuthService.Core.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string AvatarUrl { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] SaltHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime LastActive  { get; set; }

        public User(int id, 
                    string username, 
                    string email, 
                    string avatarUrl,
                    byte[] passwordHash, 
                    byte[] saltHash)
        {
            this.Id = id;
            this.Username = username;
            this.Email = email;
            this.AvatarUrl = avatarUrl;
            this.PasswordHash = passwordHash;
            this.SaltHash = saltHash;
            this.CreatedAt = DateTime.UtcNow;
            this.LastActive = DateTime.UtcNow;
        }
    }
}