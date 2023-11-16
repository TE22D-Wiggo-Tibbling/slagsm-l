using System.Globalization;

Player player1 = new Player();
Player player2 = new Player();
var random = new Random();



object[][] weapon = {
 /*hand*/new object[] {"hand", 10, 20, 100,"fegis"},
/*knä*/new object[] {"knä", 5,40,75, "kan skada men kan vara svår att träffa"},
/*näsa*/new object[]{"näsa", 1,3,15,"en dålig idee"},
/*för tung pinne*/new object[]{"för tung pinne" ,100,1000,1, "tung klubba men om träff, di win"},
/*pip<*/new object[]{"pipa" ,0,0,100,"gör inget men du är cool"}, 
/*glock*/new object[]{"glock" ,40,60,2,"du har usel sikte"},
};

object[][][] wiapon = {
    new object[][]{
        new object[]{"ja","nej"}
    }
};

/**/
object[][] item ={
    new object[]{"potion",20}
};

System.Console.WriteLine(wiapon[0][0][1]);
while (!player1.fof)
{
    System.Console.WriteLine("VÄLJ DITT VAPEN");
    selectWepon(player1);
}
while (!player2.fof)
{
    System.Console.WriteLine("VÄLJ DIN MOTSTONDARES VAPEN");
    selectWepon(player2);
}



while (player1.name.Length <= 0)
{
    System.Console.WriteLine("vad heter du");
    player1.name = Console.ReadLine();

}

System.Console.WriteLine($"välkomen {player1.name}");

string[] fiende = { "fefe", "fofo", "fifi", "fallafle", "förre", "fack (en ficka)" };
player2.name = fiende[random.Next(0, fiende.Count())];
System.Console.WriteLine($"your enemy is {player2.name}");

Console.ReadLine();

// slagsmål
while (player1.hp > 0 && player2.hp > 0)
{
    Console.Clear();

    skada(player1, player2);

    skada(player2, player1);

    berätta();

    Console.ReadLine();
}


//Slut på strid
if (player1.hp <= 0 || player2.hp <= 0)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.Clear();
    System.Console.WriteLine($"striden är över");
}

Console.ReadLine();


void berätta()
{
    System.Console.Write($"your remaining hp is ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(player1.hp);
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write($"{player2.name}s hp is ");
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(player2.hp);
    Console.ForegroundColor = ConsoleColor.White;
}

void skada(Player player, Player träff)
{
    int u=random.Next(100);
    int damage = random.Next(Convert.ToInt32(weapon[player.wepon][1]), Convert.ToInt32(weapon[player.wepon][2]));
    if (u < Convert.ToInt32(weapon[player.wepon][3])&&u>=2)
    {
        träff.hp -= damage;
        System.Console.WriteLine($"{player.name} gör {damage} skada {weapon[player.wepon][0]}");
    }
    else if(u==1){
        damage=Convert.ToInt32(weapon[player.wepon][2])*2;
        träff.hp-=damage;
        System.Console.WriteLine($"crit!!{damage}");
    }
    else
    {
        System.Console.WriteLine("miss");
    }
}

void selectWepon(Player player)
{

    for (int i = 0; i < weapon.Count(); i++)
    {

        System.Console.Write($"{i + 1}: {weapon[i][0]}  {weapon[i][1]}-{weapon[i][2]} damage  {weapon[i][3]}% chanse to hit");
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine($" {weapon[i][4]}");
        Console.ForegroundColor = ConsoleColor.White;
    }

    int bNum = -1;
    while (bNum < 1 || bNum > weapon.Count())
    {
        string b = Console.ReadLine();
        player.success = int.TryParse(b, out bNum);

        if (!player.success || bNum < 1 || bNum > weapon.Count())
        {
            Console.WriteLine("A NUMBER, idiot!");
        }
        else
        {
            player.fof = true;
        }

    }
    player.wepon = bNum - 1;

}

public class Player
{
    public string name = "";

    public int hp = 100;

    public int wepon;

    public bool success = false;

    public bool fof = false;

    public int item;
}