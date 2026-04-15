using System.Collections;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public static class DataHandler
{
    public static ArrayList Roomdata = new ArrayList() ;
    
    public static void InitializeRoomData()
    {
        Room r1 = new Room("1", "B", 0, 20, true);
        Room r2 = new Room("2", "B", 0, 20, true);
        Room r3 = new Room("1", "A", 1, 36, false);
        Room r4 = new Room("2", "A", 1, 55, true);
        Roomdata.Add(r1);
        Roomdata.Add(r2);
        Roomdata.Add(r3);
        Roomdata.Add(r4);
    }
}