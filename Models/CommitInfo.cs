﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGit.Models
{
    public partial class CommitInfo : ObservableObject
    {
        [ObservableProperty]
        private String? _message;

        [ObservableProperty]
        private String? _author;

        [ObservableProperty]
        private String? _branch;

        [ObservableProperty]
        private DateTime _dateTime;
    }
}