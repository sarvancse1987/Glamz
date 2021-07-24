﻿using Glamz.Domain.Configuration;

namespace Glamz.Domain.Courses
{
    public class CourseSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether guests are allowed to access to the course
        /// </summary>
        public bool AllowGuestsToAccessCourse { get; set; }
    }
}
