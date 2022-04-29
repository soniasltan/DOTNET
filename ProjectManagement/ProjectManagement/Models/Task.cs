﻿using System;
using System.Collections.Generic;

namespace ProjectManagement.Models
{
    public partial class Task
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string TaskTitle { get; set; } = null!;
        public string? TaskDescription { get; set; }
        public string? TaskStatus { get; set; }
        public int? AssignedToId { get; set; }
        public int? AssignedById { get; set; }
        public string? CreatedDate { get; set; }
        public int? UpdatedById { get; set; }
        public string? Attachment { get; set; }
    }
}
