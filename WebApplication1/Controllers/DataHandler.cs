using System.Collections;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public static class DataHandler
{
    public static List<Room> Roomdata = new List<Room>();
    public static List<Reservation> ReservationData = new List<Reservation>();
    
    public static void InitializeRoomData()
    {
        Room r1 = new Room("1", "B", 0, 20, true, true);
        Room r2 = new Room("2", "B", 0, 20, true, true);
        Room r3 = new Room("1", "A", 1, 36, false, true);
        Room r4 = new Room("2", "A", 1, 55, true, false);
        Roomdata.Add(r1);
        Roomdata.Add(r2);
        Roomdata.Add(r3);
        Roomdata.Add(r4);
        
        Reservation res1 = new Reservation
        (
            1,
            "Robert Lewandowski",
            "Szkolenie: Architektura Mikroserwisów",
            new DateOnly(2026, 05, 10),
            new TimeOnly(9, 0, 0),
            new TimeOnly(12, 0, 0),
            "confirmed"
        );

        Reservation res2 = new Reservation
        (
            2,
            "Marta Żmuda",
            "Konsultacje UX/UI",
            new DateOnly(2026, 05, 10),
            new TimeOnly(13, 0, 0),
            new TimeOnly(15, 30, 0),
            "planned"
        );

        Reservation res3 = new Reservation
        (
            3,
            "Adam Małysz",
            "Warsztaty: Zarządzanie czasem pod presją",
            new DateOnly(2026, 05, 11),
            new TimeOnly(10, 0, 0),
            new TimeOnly(14, 0, 0),
            "confirmed"
        );

        Reservation res4 = new Reservation
        (
            4,
            "Iga Świątek",
            "Strategia rozwoju Centrum",
            new DateOnly(2026, 05, 11),
            new TimeOnly(8, 30, 0),
            new TimeOnly(10, 30, 0),
            "confirmed"
        );
        Reservation res5 = new Reservation
        (
            5,
            "Krzysztof Gonciarz",
            "Podstawy montażu wideo",
            new DateOnly(2026, 05, 12),
            new TimeOnly(16, 0, 0),
            new TimeOnly(19, 0, 0),
            "cancelled"
        );
        
        Reservation res6 = new Reservation
        (
            2,
            "Monika Brodka",
            "Kreatywne pisanie tekstów",
            new DateOnly(2026, 05, 12),
            new TimeOnly(9, 0, 0),
            new TimeOnly(11, 0, 0),
            "planned"
        );
        
        ReservationData.Add(res1);
        ReservationData.Add(res2);
        ReservationData.Add(res3);
        ReservationData.Add(res4);
        ReservationData.Add(res5);
        ReservationData.Add(res6);
    }
}