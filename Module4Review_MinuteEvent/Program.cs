using System.Diagnostics.Tracing;

namespace Module4Review_MinuteEvent
{
    class Program
    {
        static List<Event> events = new List<Event>();
        static int eventIdCounter = 1;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Minute Event!");

            while (true)
            {
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Create an Event");
                Console.WriteLine("2. View All Events");
                Console.WriteLine("3. Delete an Event");
                Console.WriteLine("Exit");

                Console.Write("Make a selection: ");
                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        CreateEvent();
                        break;
                    case "2":
                        ViewAllEvents();
                        break;
                    case "3":
                        DeleteEvent();
                        break;
                    case "4":
                        Console.WriteLine("Exiting application");
                        return;
                }
            }
        }

        static void CreateEvent()
        {
            Console.WriteLine("Create a new event:");

            Event newEvent = new Event();
            newEvent.Id = eventIdCounter++;

            Console.Write("Event Name: ");
            newEvent.Name = Console.ReadLine();

            Console.Write("Event Decription: ");
            newEvent.Description = Console.ReadLine();

            Console.Write("Event Location: ");
            newEvent.Location = Console.ReadLine();

            Console.Write("Event Date (yyyy-MM-dd HH:mm): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd HH:mm", null, System.Globalization.DateTimeStyles.None, out DateTime eventDate))
            {
                newEvent.Date = eventDate;
            }
            else
            {
                Console.WriteLine("Invalid date format. Event not created.");
                return;
            }

            events.Add(newEvent);
            Console.WriteLine("Event created successfully.");
        }

        static void ViewAllEvents()
        {
            Console.WriteLine("List of all events: ");
            foreach (var e in events)
            {
                Console.WriteLine($"Event ID: {e.Id}");
                Console.WriteLine($"Name: {e.Name}");
                Console.WriteLine($"Description: {e.Description}");
                Console.WriteLine($"Location: {e.Location}");
                Console.WriteLine($"Date: {e.Date}");
                Console.WriteLine();
            }
        }

        static void DeleteEvent()
        {
            Console.WriteLine("Please enter the ID of the event you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out int eventId))
            {
                Event eventToDelete = events.Find(e => e.Id == eventId);
                if (eventToDelete != null)
                {
                    events.Remove(eventToDelete);
                    Console.WriteLine("Event successfully deleted!");
                }
                else
                {
                    Console.WriteLine("Event not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid event ID.");
            }
        
        }

    }

}