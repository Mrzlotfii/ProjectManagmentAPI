﻿namespace ProjectManagementApp.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
