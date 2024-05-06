﻿using Explorer.BuildingBlocks.Core.Domain;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain.Equipment;

public class Equipment : Entity
{
    public string Name { get; init; }
    public string? Description { get; init; }
    public List<Tour> Tours { get; init; }

    public Equipment(string name, string? description)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Invalid Name.");
        Name = name;
        Description = description;
    }
}