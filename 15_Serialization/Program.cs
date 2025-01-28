using _15_Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        // Task 1
        SerializationArray program = new SerializationArray();
        program.Program();


        // Task 2 && 3

        Album album = new Album("The Dark Side of the Moon", "Pink Floyd", 1973, 42, "Abbey Road Studios", new List<Song> { new Song("Track1", 3.00, "Rock") });

        Console.WriteLine(album + "\n");


        album.AddSong(new Song("Track 2", 4.15, "Jazz"));

        album.Serialization("../../../album.json");


        var album2 = Album.Deserialization("../../../album.json");

        Console.WriteLine(album2);


        // Task 4
        Console.WriteLine("\n");

        AlbumList albumList = new AlbumList();
        albumList.AddAlbum(album);
        albumList.AddAlbum(album2);

        albumList.Print();

        albumList.SerializeToFile("../../../albums.json");


        Console.WriteLine("After serialize to file");


        AlbumList albumList1 = new AlbumList("../../../albums.json");

        albumList1.Print();
    }
}