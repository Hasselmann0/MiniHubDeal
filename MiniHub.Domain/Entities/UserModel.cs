using MiniHub.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MiniHub.Domain.Entities
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public RoleEnum Roles { get; set; }

    }
}