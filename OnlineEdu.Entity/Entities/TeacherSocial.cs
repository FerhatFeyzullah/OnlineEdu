﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.Entity.Entities
{
    public class TeacherSocial
    {
        public int TeacherSocialId { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public int TeacherId { get; set; }
        public  AppUser Teacher { get; set; }
    }
}
