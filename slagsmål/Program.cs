Player player1 = new Player();
Player player2 = new Player();
var random = new Random();

object [][] weapon = {
new object[] {"hand", 10, 30, 100},
new object[] {"knä", 5,40,80}
};

for(int i=0;i<weapon.Count() ;i++ ){
    System.Console.WriteLine($"{i+1}: {weapon[i][0]}  {weapon[i][1]}-{weapon[i][2]} damahe  {weapon[i][3]}% chanse to hit");
}

System.Console.WriteLine("vad heter du");
player1.name = Console.ReadLine();
System.Console.WriteLine($"välkomen {player1.name}");

string[] fiende = { "fefe", "fofo", "fifi" };
player2.name = fiende[random.Next(0, fiende.Count())];
System.Console.WriteLine($"your enemy is {player2.name}");

Console.ReadLine();

// slagsmål
while (player1.hp > 0 && player2.hp > 0)
{


    //player1 slår

    int damage = random.Next(20);
    player1.hp -= damage;
    System.Console.WriteLine($"{player1.name} gör {damage} skada");

    //player2 slår

    damage = random.Next(20);
    player2.hp -= damage;
    System.Console.WriteLine($"{player2.name} gör {damage} skada");
    Console.ReadLine();


    System.Console.Write($"your remaining hp is ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write(player1.hp);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"\n{player2.name}s hp is ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(player2.hp);
    Console.ForegroundColor = ConsoleColor.White;

}
//Slut på strid

Console.ForegroundColor = ConsoleColor.Red;

if (player1.hp <= 0 || player2.hp <= 0)
{
    System.Console.WriteLine($"striden är över");
}

Console.ReadLine();
public class Player
{
    public string name;

    public int hp = 100;


}