﻿namespace Domain.Models
{
    public class Person
    {
        public Person(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
    }
}