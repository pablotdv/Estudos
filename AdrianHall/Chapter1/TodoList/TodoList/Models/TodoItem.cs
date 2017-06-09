﻿using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Abstractions;

namespace TodoList.Models
{
    public class TodoItem : TableData
    {
        public string Text { get; set; }
        public bool Complete { get; set; }
    }
}
