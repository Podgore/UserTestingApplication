﻿namespace UserTestingApp.Entities;

public class Test : EntityBase
{
    public string Lable { get; set; } = string.Empty;
    public int MaxMark { get; set; }

    public List<TestUser> TestUsers { get; set; } = null!;
    public List<TestTask> Tasks { get; set; } = null!;
}