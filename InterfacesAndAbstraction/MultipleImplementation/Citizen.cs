﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IBirthable, IIdentifiable, IPerson
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Birthdate { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
