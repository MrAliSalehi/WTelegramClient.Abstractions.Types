using TL;
using PhotoCachedSize = TL.Layer23.PhotoCachedSize;
using PhotoSize = TL.Layer23.PhotoSize;

namespace WTC.Abstractions.Types;

public static class MediaExtensions
{
    public static Photo? Photo(this MessageMedia media) => media switch
    {
        MessageMediaPhoto { photo: Photo photo } => photo,
        _                                        => null
    };
    public static MessageMedia? Media(this MessageBase mb) => mb switch
    {
        Message msg => msg.media,
        _           => null
    };

    public static bool IsGroupedMedia(this MessageBase mb) => mb switch
    {
        Message msg when (msg.flags & Message.Flags.has_grouped_id) != 0 => true,
        _                                                                => false,
    };

    public static Document? Document(this MessageMedia media) => media switch
    {
        MessageMediaDocument { document: Document d } => d,
        _                                             => null
    };

    public static int Size(this PhotoSizeBase psb) => psb switch
    {
        PhotoCachedSize photoCachedSize           => photoCachedSize.FileSize,
        PhotoSize photoSize                       => photoSize.FileSize,
        TL.PhotoCachedSize photoCachedSize1       => photoCachedSize1.FileSize,
        PhotoPathSize photoPathSize               => photoPathSize.FileSize,
        TL.PhotoSize photoSize1                   => photoSize1.FileSize,
        PhotoSizeEmpty photoSizeEmpty             => photoSizeEmpty.FileSize,
        PhotoSizeProgressive photoSizeProgressive => photoSizeProgressive.FileSize,
        PhotoStrippedSize photoStrippedSize       => photoStrippedSize.FileSize,
        _                                         => -1
    };
    public static (int width, int height) Dimensions(this PhotoSizeBase psb) => psb switch
    {
        PhotoCachedSize photoCachedSize           => (photoCachedSize.Width, photoCachedSize.Height),
        PhotoSize photoSize                       => (photoSize.Width, photoSize.Height),
        TL.PhotoCachedSize photoCachedSize1       => (photoCachedSize1.Width, photoCachedSize1.Height),
        PhotoPathSize photoPathSize               => (photoPathSize.Width, photoPathSize.Height),
        TL.PhotoSize photoSize1                   => (photoSize1.Width, photoSize1.Height),
        PhotoSizeEmpty photoSizeEmpty             => (photoSizeEmpty.Width, photoSizeEmpty.Height),
        PhotoSizeProgressive photoSizeProgressive => (photoSizeProgressive.Width, photoSizeProgressive.Height),
        PhotoStrippedSize photoStrippedSize       => (photoStrippedSize.Width, photoStrippedSize.Height),
        _                                         => (-1, -1)
    };
    public static string? Type(this PhotoSizeBase psb) => psb switch
    {
        PhotoCachedSize photoCachedSize           => photoCachedSize.Type,
        PhotoSize photoSize                       => photoSize.Type,
        TL.PhotoCachedSize photoCachedSize1       => photoCachedSize1.Type,
        PhotoPathSize photoPathSize               => photoPathSize.Type,
        TL.PhotoSize photoSize1                   => photoSize1.Type,
        PhotoSizeEmpty photoSizeEmpty             => photoSizeEmpty.Type,
        PhotoSizeProgressive photoSizeProgressive => photoSizeProgressive.Type,
        PhotoStrippedSize photoStrippedSize       => photoStrippedSize.Type,
        _                                         => null
    };
    public static byte[] Bytes(this PhotoSizeBase psb) => psb switch
    {
        PhotoCachedSize photoCachedSize     => photoCachedSize.bytes,
        TL.PhotoCachedSize photoCachedSize1 => photoCachedSize1.bytes,
        PhotoPathSize photoPathSize         => photoPathSize.bytes,
        PhotoStrippedSize photoStrippedSize => photoStrippedSize.bytes,
        _                                   => Array.Empty<byte>()
    };
    public static IEnumerable<byte[]> PhotoBytes(this Photo photo) => photo.sizes.Select(p => p.Bytes()).Where(Enumerable.Any);
    public static IEnumerable<string> PhotoTypes(this Photo photo) => photo.sizes.Select(photoSizeBase => photoSizeBase.Type()).OfType<string>().ToList();
    public static IEnumerable<(int width, int height)> PhotosDimensions(this Photo photo) => photo.sizes.Select(p => p.Dimensions());
    public static IEnumerable<int> PhotoSizes(this Photo photo) => photo.sizes.Select(p => p.Size());
}