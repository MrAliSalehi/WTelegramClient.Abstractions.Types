using TL;

namespace WTC.Abstractions.Types;

public static class ChatsExtensions
{
    public static IEnumerable<Channel> Channels(this Messages_Chats mc, Func<Channel, bool>? predicate = null)
    {
        var ofType = mc.chats.Values.OfType<Channel>().Where(c => c.IsBroadcastChannel());
        return predicate is null ? ofType : ofType.Where(predicate);
    }

    public static IEnumerable<Channel> SuperGroups(this Messages_Chats mc, Func<Channel, bool>? predicate = null)
    {
        var ofType = mc.chats.Values.OfType<Channel>().Where(c => !c.IsBroadcastChannel());
        return predicate is null ? ofType : ofType.Where(predicate);
    }

    public static IEnumerable<Chat> Chats(this Messages_Chats mc, Func<Chat, bool>? predicate = null)
    {
        var ofType = mc.chats.Values.OfType<Chat>();
        return predicate is null ? ofType : ofType.Where(predicate);
    }

    public static Chat? GetChat(this Dictionary<long, ChatBase> chatBases, long id) => chatBases.TryGetValue(id, out var cb) ? cb as Chat : null;

    public static Channel? GetChannel(this Dictionary<long, ChatBase> chatBases, long id)
    {
        if (!chatBases.TryGetValue(id, out var cb)) return null;
        if (cb is Channel ch && ch.IsBroadcastChannel()) return ch;

        return null;
    }

    public static Channel? GetSuperGroup(this Dictionary<long, ChatBase> chatBases, long id)
    {
        if (!chatBases.TryGetValue(id, out var cb)) return null;
        if (cb is Channel ch && !ch.IsBroadcastChannel()) return ch;

        return null;
    }

    public static InputPeerChannel ToInputPeerChannel(this Channel ch) => new(ch.ID == 0 ? ch.id : -1, ch.access_hash);

    public static bool IsBroadcastChannel(this Channel ch) => (ch.flags & Channel.Flags.broadcast) != 0;

    public static InputPeerChat ToInputPeerChat(this Chat ch) => new(ch.ID == 0 ? ch.id : -1);

    public static bool IsForbidden(this ChatBase b) => b switch
    {
        ChannelForbidden => true,
        ChatForbidden    => true,
        _                => false,
    };
}