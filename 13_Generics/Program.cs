using _13_Generics;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> playerNames = new List<string> { "Player 1", "Player 2" };
        Game game = new Game(playerNames);
        game.Play();
    }
}