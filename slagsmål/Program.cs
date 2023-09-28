Player player1 = new Player();
Player player2 = new Player();
var random = new Random();



object [][] weapon = {
new object[] {"hand", 10, 30, 100},
new object[] {"knä", 5,40,80},
new object[]{"näsa", 1,3,5}
};
selectWepon(player1);
selectWepon(player2);




System.Console.WriteLine("vad heter du");
player1.name = Console.ReadLine();
System.Console.WriteLine($"välkomen {player1.name}");

string[] fiende = { "fefe", "fofo", "fifi", "fallafle","förre", "fack" };
player2.name = fiende[random.Next(0, fiende.Count())];
System.Console.WriteLine($"your enemy is {player2.name}");

Console.ReadLine();

// slagsmål
while (player1.hp > 0 && player2.hp > 0)
{
Console.Clear();

skada(player1,player2);

skada(player2,player1);

berätta();

Console.ReadLine();
}


//Slut på strid

Console.ForegroundColor = ConsoleColor.Magenta;

if (player1.hp <= 0 || player2.hp <= 0)
{
    Console.Clear();
    System.Console.WriteLine($"striden är över");
}

Console.ReadLine();


void berätta(){
        System.Console.Write($"your remaining hp is ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(player1.hp);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"{player2.name}s hp is ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(player2.hp);
    Console.ForegroundColor = ConsoleColor.White;
}

void skada(Player player, Player träff){
  int damage = random.Next(Convert.ToInt32(weapon[player.wepon][1]),Convert.ToInt32(weapon[player.wepon][2]));
    if(random.Next(100) < Convert.ToInt32(weapon[player.wepon][3])){
    träff.hp-= damage;
    System.Console.WriteLine($"{player.name} gör {damage} skada {weapon[player.wepon][0]}");
    }
    else{
        System.Console.WriteLine("miss");
    }
}

void selectWepon(Player player){

for(int i=0;i<weapon.Count() ;i++ ){
    System.Console.WriteLine($"{i+1}: {weapon[i][0]}  {weapon[i][1]}-{weapon[i][2]} damage  {weapon[i][3]}% chanse to hit");
}
string b = Console.ReadLine();
player.wepon = Convert.ToInt32(b)-1;

}

public class Player
{
    public string name;

    public int hp = 100;

    public int wepon;
}