namespace WebApplication1.Models;

using System;
using System.ComponentModel.DataAnnotations;

public class Reservation
{
    private static int _id = 0;
    
    public int Id { get; set; }
    
    public int RoomId { get; set; }

    [Required] public string OrganizerName { get; set; }

    [Required] public string Topic { get; set; }

    [Required] public DateOnly Date { get; set; }

    [Required] public TimeOnly StartTime { get; set; }

    [Required] public TimeOnly EndTime { get; set; }

    [RegularExpression(@"^(confirmed|planned|cancelled)$")]public string Status { get; set; }

    public Reservation(int roomId, string organizerName, string topic, DateOnly date, TimeOnly startTime, TimeOnly endTime, string status )
    {
        Id = _id++;
        RoomId = roomId;
        OrganizerName = organizerName;
        Topic = topic;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        Status = status;
    }

}