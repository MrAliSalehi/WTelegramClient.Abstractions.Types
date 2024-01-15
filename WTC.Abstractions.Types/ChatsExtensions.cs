using TL;

namespace WTC.Abstractions.Types;

public static class ChatsExtensions
{
    public static IEnumerable<Channel> Channels(this Messages_Chats mc, Func<Channel, bool>? predicate = null)
    {
        var ofType = mc.chats.Values.OfType<Channel>();
        return predicate is null ? ofType.ToList() : ofType.Where(predicate).ToList();
    }
}