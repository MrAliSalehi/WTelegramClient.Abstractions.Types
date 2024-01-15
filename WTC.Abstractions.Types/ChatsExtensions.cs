using TL;

namespace WTC.Abstractions.Types;

public static class ChatsExtensions
{
    public static IEnumerable<Channel> Channels(this Messages_Chats mc, Func<Channel, bool>? predicate = null)
    {
        var ofType = mc.chats.Values.OfType<Channel>();
        return predicate is null ? ofType : ofType.Where(predicate);
    }

    public static IEnumerable<Chat> Chats(this Messages_Chats mc, Func<Chat, bool>? predicate = null)
    {
        var ofType = mc.chats.Values.OfType<Chat>();
        return predicate is null ? ofType : ofType.Where(predicate);
    }

    public static InputPeerChannel ToInputPeerChannel(this Channel ch) => new(ch.ID == 0 ? ch.id : -1, ch.access_hash);

    public static InputPeerChat ToInputPeerChat(this Chat ch) => new(ch.ID == 0 ? ch.id : -1);

    public static bool IsForbidden(this ChatBase b) => b switch
    {
        ChannelForbidden => true,
        ChatForbidden    => true,
        _                => false,
    };
}