﻿namespace Configurator_PC.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; } = string.Empty;
        public int Password { get; set; }
    }
}
