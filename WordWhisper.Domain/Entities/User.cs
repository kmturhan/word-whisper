﻿using System.Security.AccessControl;

namespace WordWhisper.Domain;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int RoleId { get; set; }
    public DateTime CreatedDate { get; set; }
    public bool IsActive { get; set; }
    public Role Role { get; set; }
}
