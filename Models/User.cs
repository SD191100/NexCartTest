﻿using System;
using NexCart.Enums;

namespace NexCart.Models
{
   

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ContactNumber { get; set; }
        public UserRole Role { get; set; } = UserRole.Customer; // Default to Customer
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiry { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection<Order> orders { get; set; }
        public Address address { get; set; }
    }
}


