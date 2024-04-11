﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Encounters.API.Dtos
{
    public class EncounterExecutionDto
    {
        public long Id { get; set; }
        public long TouristId { get; set; }
        public long ChallengeId { get; set; }
        public DateTime ActivationTime { get; set; }
        public DateTime? CompletionTime { get; set; }
    }
}