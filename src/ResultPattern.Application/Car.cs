﻿namespace ResultPattern.Application
{
    public class Car
    {
        public Guid Id { get; init; }
        public string Name { get; init; }

        public Car(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        // For EF
        private Car() { }
    }
}
