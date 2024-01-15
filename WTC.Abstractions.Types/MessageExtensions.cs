using TL;

namespace WTC.Abstractions.Types;

public static class MessageExtensions
{
    public static MessageBase? MessageBase(this Update update) => update switch
    {
        UpdateNewChannelMessage cm => cm.message,
        UpdateEditMessage em       => em.message,
        UpdateNewMessage nm        => nm.message,
        UpdateNewScheduledMessage sm => sm.message,
        _                          => null
    };


    public static Peer? Sender(this MessageBase mb) => mb switch
    {
        { From.ID: not 0 } => mb.From,
        Message msg        => msg.From.ID != 0 ? msg.From : msg.from_id.ID != 0 ? msg.from_id : null,
        MessageService ms  => ms.From.ID != 0 ? ms.From : ms.from_id.ID != 0 ? ms.from_id : null,
        MessageEmpty me    => me.From.ID != 0 ? me.From : null,
        _                  => null,
    };

    public static string? Text(this MessageBase mb) => mb switch
    {
        Message msg => msg.message,
        _           => null
    };

    public static bool IsSelf(this MessageBase mb) => mb switch
    {
        Message msg       => (msg.flags & Message.Flags.out_) != 0,
        MessageService ms => (ms.flags & MessageService.Flags.out_) != 0,
        _                 => false
    };
}