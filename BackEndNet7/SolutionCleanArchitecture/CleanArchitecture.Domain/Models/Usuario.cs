using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Models
{
    public partial class Usuario
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? UserName { get; set; }

        public string? Password { get; set; }

        public string? Token { get; set; }
    }
}