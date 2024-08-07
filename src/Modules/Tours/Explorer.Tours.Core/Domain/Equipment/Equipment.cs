﻿using Explorer.BuildingBlocks.Core.Domain;
using System.Xml.Linq;
using Explorer.Tours.Core.Domain.Tours;

namespace Explorer.Tours.Core.Domain.Equipment;

public class Equipment : Entity
{
    public string Name { get; init; }
    public string? Description { get; init; }
    public List<Tour> Tours { get; init; }

    public Equipment(string name, string? description)
    {
        Name = name;
        Description = description;

        Validate();
    }

    private void Validate()
    {
        if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name.");
    }
}