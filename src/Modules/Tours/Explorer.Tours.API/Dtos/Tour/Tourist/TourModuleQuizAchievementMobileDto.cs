﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Tours.API.Dtos.Tour.Tourist
{
    public class QuizAchievementMobileDto
    {
        public List<TourModuleQuizMobileDto> Questions { get; set; }
        public  TourModuleAchievementMobileDto Achievement { get; set; }
    }
}
