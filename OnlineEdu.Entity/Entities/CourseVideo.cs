﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Entity.Entities
{
    public class CourseVideo
    {
        public int CourseVideoId { get; set; }
        public int VideoNumber { get; set; }
        public string VideoName { get; set; }
        public string VideoUrl { get; set; }


        public int CourseId { get; set; }
        public  Course Course { get; set; }
    }
}
