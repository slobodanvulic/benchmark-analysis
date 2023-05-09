using FluentResults;

namespace ResultBenchmark;

public class EventService
{
    public static Event RaiseEvent_WithExceptions(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            throw new ValidationException("message null or empty");
        }

        var eventToSend = CreateEvent(message);
        SendEvent(eventToSend);

        return eventToSend;
    }

    public static Result<Event> RaiseEvent_WithResult(string message)
    {
        if (string.IsNullOrEmpty(message))
        {
            return Result.Fail("message null or empty");
        }

        var eventToSend = CreateEvent(message);
        SendEvent(eventToSend);

        return Result.Ok(eventToSend);
    }

    private static Event CreateEvent(string message) => 
        new Event(message)
        {
            Prop1 = "some text 1",
            Prop2 = "some text 2",
            Prop3 = "some text 3",
        };

    private static void SendEvent(Event e) 
    { }
}
public class Event 
{
    public Event(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
    public object Prop1 { get; set; }
    public object Prop2 { get; set; }
    public object Prop3 { get; set; }
}

public class ValidationException : Exception
{
    public ValidationException(string message):base(message)
    {

    }
}

