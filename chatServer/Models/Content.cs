﻿namespace chatServer.Models;

public class Content
{
    public int From { get; set; }
    public int To { get; set; }
    public string Time { get; set; }
    public string Type { get; set; }
    public string Message { get; set; }
}