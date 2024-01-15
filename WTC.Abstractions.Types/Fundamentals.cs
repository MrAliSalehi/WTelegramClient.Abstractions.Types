using TL;

namespace WTC.Abstractions.Types;

public static class Fundamentals
{
    public static void ForEach(this UpdatesBase updatesBase, Action<Update> func)
    {
        foreach (var update in updatesBase.UpdateList)
        {
            if (update is null)
                continue;
            func(update);
        }
    }

    public static async Task ForEachAsync(this UpdatesBase updatesBase, Func<Update, Task> func)
    {
        foreach (var update in updatesBase.UpdateList)
        {
            if (update is null)
                continue;
            await func(update);
        }
    }
}