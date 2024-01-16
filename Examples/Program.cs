using TL;
using WTC.Abstractions.Types;
using WTelegram;


var cl = new Client();
cl.OnUpdate += arg =>
{
    arg.ForEach(up =>
    {
        var mb = up.MessageBase();
        if (mb is null) return;

        if (mb.IsSelf()) return;

        Console.WriteLine(mb.Text());

        Console.WriteLine(mb.TimeDelta());

        var sender = mb.Sender();
        if (sender is null)
            return;

        Console.Write(sender);

        var media = mb.Media();
        if (media is not null)
        {
            var photo = media.Photo();
            if (photo is not null)
            {
                var first = photo.sizes.First();
                Console.WriteLine(first.Size());
                Console.WriteLine(photo.PhotoSizes());

                Console.WriteLine(first.Dimensions());
                Console.WriteLine(photo.PhotosDimensions());


                Console.WriteLine(photo.PhotoTypes());
                Console.WriteLine(first.Type());

                Console.WriteLine(photo.PhotoBytes());
                Console.WriteLine(first.Bytes());
            }


            var doc = media.Document();
            if (doc is null) return;
            Console.WriteLine($"doc id :{doc.ID}");
        }

        if (mb.IsGroupedMedia())
            Console.WriteLine("grouped media");
    });
    return Task.CompletedTask;
};

var getAllChats = await cl.Messages_GetAllChats();
var someChat = getAllChats.chats.GetChat(12);
var someChannel = getAllChats.chats.GetChannel(12);
var someSuperG = getAllChats.chats.GetSuperGroup(12);
var channels = getAllChats.Channels();
var chats = getAllChats.Chats();
var superG = getAllChats.SuperGroups();

var channel1 = channels.First();
var p = channel1.ToInputPeerChannel();
var c = chats.First().ToInputPeerChat();

var f = channel1.IsForbidden();

