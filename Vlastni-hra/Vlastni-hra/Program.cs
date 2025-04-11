using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Activation;
using System.Text;
using System.Threading.Tasks;

namespace Vlastni_hra
{
    internal class Program
    {
        static void Fight(Player player, BasicEnemy enemy)
        {
            Console.WriteLine("Fight the " + enemy.name + ".");
            while (!player.IsDead() && !enemy.IsDead())
            {
                enemy.Hurt(player.DoDamage());

                if (!enemy.IsDead())
                {
                    player.Hurt(enemy.DoDamage());
                    Console.WriteLine("Your remaining health is " + player.GetHealth());
                    Console.WriteLine(enemy.name + "'s remaining health is " + enemy.GetHealth());
                    Console.WriteLine(" ");
                }
                else
                {
                    player.GetExperience(enemy.gainEXP);
                    player.GetCoins(enemy.gainCoins);
                    Console.WriteLine("You have gained " + enemy.gainEXP + " Experience Points and " + enemy.gainCoins + " coins!");
                    Console.WriteLine("Your remaining health is " + player.GetHealth());
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine(" ");
        }
        static void Fight2(Player player, BossEnemy enemy)
        {
            Console.WriteLine("Fight the " + enemy.name + ".");
            while (!player.IsDead() && !enemy.IsDead())
            {
                enemy.Hurt(player.DoDamage());

                if (!enemy.IsDead())
                {
                    player.Hurt(enemy.DoDamage());
                    Console.WriteLine("Your remaining health is " + player.GetHealth());
                    Console.WriteLine(enemy.name + "'s remaining health is " + enemy.GetHealth());
                    Console.WriteLine(" ");
                }
                else
                {
                    player.GetExperience(enemy.gainEXP);
                    player.GetCoins(enemy.gainCoins);
                    Console.WriteLine("You have gained " + enemy.gainEXP + " Experience Points and " + enemy.gainCoins + " coins!");
                    Console.WriteLine("Your remaining health is " + player.GetHealth());
                    Console.WriteLine(" ");
                }
            }
            Console.WriteLine(" ");
        }
        static void SwapChars(NPC character1, NPC character2, Player player) //swap char1 for char2
        {
            player.LoseDMG(character1.addedDamage);
            player.LoseHealth(character1.addedHealth);
            player.GainDMG(character2.addedDamage);
            player.GainDMG(character2.addedHealth);
        }
        static void ChangeWeapon(Weapon weapon1, Weapon weapon2, Player player) //change weapon1 to weapon2
        {
            player.LoseDMG(weapon1.damage);
            player.GainDMG(weapon2.damage);
            Console.WriteLine("Sofia: You have equipped " + weapon2.name + " instead of " + weapon1.name + ". Your damage is now " + player.damage + ".");
        }
        static void Main(string[] args)
        {
            BasicEnemy enemyEarth1 = new BasicEnemy(10, 3, 1, "carp", 5, 5);
            BasicEnemy enemyEarth2 = new BasicEnemy(10, 3, 1, "squirel", 5, 5);
            BossEnemy bossEnemyEarth = new BossEnemy(10, 3, 1, "deer", 5, 5);
            BasicEnemy enemyCastle1 = new BasicEnemy(10, 3, 2, "spider", 5, 5);
            BasicEnemy enemyCastle2 = new BasicEnemy(10, 3, 2, "ghost", 5, 5);
            BossEnemy bossEnemyCastle = new BossEnemy(10, 3, 2, "gargoyle", 5, 5);
            BasicEnemy enemyFountain1 = new BasicEnemy(10, 3, 3, "octopus", 5, 5);
            BasicEnemy enemyFountain2 = new BasicEnemy(10, 3, 3, "moray eel", 5, 5);
            BossEnemy bossEnemyFountain = new BossEnemy(10, 3, 3, "water spirit", 5, 5);
            BasicEnemy enemyMedival1 = new BasicEnemy(10, 3, 4, "adventurer", 5, 5);
            BasicEnemy enemyMedival2 = new BasicEnemy(10, 3, 4, "knight", 5, 5);
            BossEnemy bossEnemyMedival = new BossEnemy(10, 3, 4, "Izumi", 5, 5);
            BossEnemy bossEnemyFinal = new BossEnemy(10, 3, 4, "Xander", 5, 5);
            BossEnemy bossEnemyFinalFinal = new BossEnemy(11, 4, 5, "Emrys", 6, 6);

            Weapon weapon1 = new Weapon("Piercer", "crossbow", 1, 1, 20, 0, 1);
            Weapon weapon2 = new Weapon("Mightbreakers", "nunchucks", 2, 2, 40, 0, 2);
            Weapon weapon3 = new Weapon("Executioner", "whip", 2, 3, 50, 0, 3);
            Weapon weapon4 = new Weapon("Hellgate", "scythe", 2, 4, 60, 0, 4);

            NPC characterGym1 = new NPC("Mark", 1, 0, 0, 1);
            NPC characterGym2 = new NPC("Claire", 2, 1, 0, 2);
            NPC characterArmory1 = new NPC("Marcel", 4, 2, 0, 3);
            NPC characterArmory2 = new NPC("Sofia", 2, 0, 0, 4);
            NPC characterCafeteria1 = new NPC("Jacob", 2, 1, 0, 5);
            NPC characterCafeteria2 = new NPC("Chris", 1, 2, 0, 6);
            NPC characterCafeteria3 = new NPC("Myst", 2, 0, 0, 7);
            NPC characterLibrary1 = new NPC("Dante", 0, 1, 0, 8);
            NPC characterLibrary2 = new NPC("Genevieve", 0, 2, 0, 9);

            Food meal1 = new Food("butter cookie", 6, 3);
            Food meal2 = new Food("fried meat on a piece of bred", 12, 3);
            Food meal3 = new Food("chicken soup", 15, 3);
            Food meal4 = new Food("pasta with tomato sauce", 18, 2);
            Food meal5 = new Food("beef stew", 21, 2);
            Food meal6 = new Food("chocolate cake", 25, 1);

            int destination;
            int markEXP = 0;
            int weapon = 0;
            int character = 0;
            int talkedToGenevieve = 0;

            Console.WriteLine("Isadora: Whoah, hello there human. I see you've found your way here. What's your name?");
            string yourName = Console.ReadLine();
            Player player = new Player(10, 2, 1, yourName, 0, 0);
            Console.WriteLine("Isadora: It's a pleasure to meet you, " + yourName + ". Welcome to the Void. You are currently nowhere, there's just darkness around you. Soon though, I'll take you to a better place, but first some rules and guidance.\nIsadora: You're enering an amateur console game made by a student. If the game writes a word between <> or --, it is specifically asking you to write that word as your choice. If there's yes/no at the end of a question, it wants you to reply with either yes or no. Whenever the game won't be able to read something after you, it will automatically kick you out of that conversation, or you can write leave to leave. It doesn't matter is you write in all small letters or have the first big in most cases except for options a/b/c/..., those are always small.");
            Console.WriteLine("Isadora: Now, I will take you to a place called the Crossroads, where you'll be safe. You can talk to others, buy weapons at Sofia's or level up at Mark's. If you'd want to heal, foo'd avaliable in the Cafeteria. Otherwise, if you look for coordinates at the Library and decide to leave the Crossroads, you can enter one of those coordinates to fight enemies or bosses. Defeat them all to reach the end of this story and don't be afraid to take breaks between levels.");
            Console.WriteLine("Isadora: Enjoy the game and may you have a plesant experience!");
            destination = 000000;

            while (player.health > 0)
            {
                if (destination == 000000)
                {
                    while (player.health > 0)
                    {
                        Console.WriteLine("\nWelcome to the Crossroads.\nWhere would you like to go?\nList of places:\n Armory\n Gym\n Cafeteria\n Library\n Leave.");
                        string crossroadsRoom = Console.ReadLine();
                        if (crossroadsRoom == "Armory" || crossroadsRoom == "armory")
                        {
                            int leave = 1;
                            Console.WriteLine("\nYou are in the Armory. Here you can chat with -Sofia-. ");
                            if (bossEnemyFountain.health < 0) { Console.Write("Or you can talk to -Marcel-."); }

                            while (leave == 1)
                            {
                                Console.WriteLine("Something you'd like to do here?");
                                string decisionArmory = Console.ReadLine();
                                if (decisionArmory == "Sofia" || decisionArmory == "sofia")
                                {
                                    Console.WriteLine("You walk over to the blonde girl, her odd hairstyle immediatelly striking you.\nSofia: Hey, " + player.name + ". What'cha need?");
                                    Console.WriteLine(" <a> Buy a weapon\n <b> My weapons\n <c> My coins\n <d> Which weapon is the best to choose?");
                                    if (characterArmory2.partnership == 1) { Console.WriteLine(" <e> Join me in a fight."); }
                                    string decision1 = Console.ReadLine();
                                    if (decision1 == "a")
                                    {
                                        Console.WriteLine("Sofia: I have a lot of weapons you can choose from. Here, I have a list:");
                                        if (weapon1.owned == 0) { Console.WriteLine(" " + weapon1.name + " - " + weapon1.price + " coins"); }
                                        if (weapon2.owned == 0) { Console.WriteLine(" " + weapon2.name + " - " + weapon2.price + " coins"); }
                                        if (weapon3.owned == 0) { Console.WriteLine(" " + weapon3.name + " - " + weapon3.price + " coins"); }
                                        if (weapon4.owned == 0) { Console.WriteLine(" " + weapon4.name + " - " + weapon4.price + " coins"); }
                                        Console.WriteLine("Sofia:Would you like to buy a weapon? yes/no");
                                        string weaponDecision = Console.ReadLine();
                                        if (weaponDecision == "no" || weaponDecision == "No")
                                        {
                                            Console.WriteLine("Sofia: Alright. If you'll ever want to though, stop by.");
                                        }
                                        else if (weaponDecision == "yes" || weaponDecision == "Yes")
                                        {
                                            Console.WriteLine("Sofia: Which weapon caught your eye? Just tell me the name and I'll pack it up for you.");
                                            string decisionWeapon = Console.ReadLine();
                                            if (decisionWeapon == "Piercer")
                                            {
                                                Console.WriteLine("Sofia: Oh, the " + weapon1.type + ". The price of this weapon is " + weapon1.price + ", you sure you want to buy it? yes/no");
                                                string buyDecision = Console.ReadLine();
                                                if (buyDecision == "yes" || buyDecision == "Yes")
                                                {
                                                    if (player.currentCoins >= weapon1.price)
                                                    {
                                                        player.UseCoins(weapon1.price);
                                                        weapon1.owned = 1;
                                                        Console.WriteLine("Sofia: Here, you have obtained the weapon " + weapon1.name + ". Your dmg can be increased by " + weapon1.damage + " with this.");
                                                    }
                                                    else
                                                    {
                                                        int amount = weapon1.price - player.currentCoins;
                                                        Console.WriteLine("Sofia: Yeesh, you only have " + player.currentCoins + " coins, which is not enough. You still need " + amount + " coins. I'll save it for you till you have enough, okay?");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Sofia: Alright. If you'll ever want it though, stop by.");
                                                }
                                            }
                                            else if (decisionWeapon == "Mightbreakers")
                                            {
                                                Console.WriteLine("Sofia: Oh yeah, the " + weapon2.type + " are fun. The price of this weapon is " + weapon2.price + ". Are you sure you want to buy it?");
                                                string buyDecision = Console.ReadLine();
                                                if (buyDecision == "yes" || buyDecision == "Yes")
                                                {
                                                    if (player.currentCoins >= weapon2.price)
                                                    {
                                                        player.UseCoins(weapon2.price);
                                                        weapon2.owned = 1;
                                                        Console.WriteLine("Sofia: You have obtained the weapon " + weapon2.name + ". Your dmg can be increased by " + weapon2.damage + " with it. But be careful, they are devious.");
                                                    }
                                                    else
                                                    {
                                                        int amount = weapon2.price - player.currentCoins;
                                                        Console.WriteLine("Sofia: Unfortunately, you only have " + player.currentCoins + " coins, which is not enough. You still need " + amount + " coins. I'll just save them for you.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Sofia: Alright. If you'll ever want it though, stop by.");
                                                }
                                            }
                                            else if (decisionWeapon == "Executioner")
                                            {
                                                Console.WriteLine("Sofia: O-ho-ho, the " + weapon3.type + " alright. That's a rare one. The price of this weapon is " + weapon3.price + ". Are you sure you want to buy it?");
                                                string buyDecision = Console.ReadLine();
                                                if (buyDecision == "yes" || buyDecision == "Yes")
                                                {
                                                    if (player.currentCoins >= weapon3.price)
                                                    {
                                                        player.UseCoins(weapon3.price);
                                                        weapon3.owned = 1;
                                                        Console.WriteLine("Sofia: You have successfully obtained the weapon " + weapon3.name + ". Your dmg can be increased by " + weapon3.damage + " with it. Good luck.");
                                                    }
                                                    else
                                                    {
                                                        int amount = weapon3.price - player.currentCoins;
                                                        Console.WriteLine("Sofia: You only have " + player.currentCoins + " coins, which is not enough. You still need " + amount + " coins. I don't think anyone else will want to buy it, so it'll stay here for you.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Sofia: Alright. If you'll ever want it though, stop by. Not that I think you will....");
                                                }
                                            }
                                            else if (decisionWeapon == "Hellgate")
                                            {
                                                Console.WriteLine("Sofia: Ah, the " + weapon4.name + ", my favourite. The price of this weapon is " + weapon4.price + ". Are you sure you want to buy it?");
                                                string buyDecision = Console.ReadLine();
                                                if (buyDecision == "yes" || buyDecision == "Yes")
                                                {
                                                    if (player.currentCoins >= weapon4.price)
                                                    {
                                                        player.UseCoins(weapon4.price);
                                                        weapon4.owned = 1;
                                                        Console.WriteLine("Sofia: You have now obtained the weapon " + weapon4.name + ". Your dmg can be increased by " + weapon4.damage + " with it. Be careful while using it.");
                                                    }
                                                    else
                                                    {
                                                        int amount = weapon4.price - player.currentCoins;
                                                        Console.WriteLine("Sofia: What a shame, you only have " + player.currentCoins + " coins, which is not enough. You still need " + amount + " coins and you should hurry, this weapon may be sold soon.");
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Sofia: Alright. If you'll ever want it though, stop by.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Sofia: We don't have that kind of weapon here. I could ask Jacob to make it though.");
                                            }
                                        }
                                    }
                                    else if (decision1 == "b")
                                    {
                                        Console.WriteLine("Sofia: These are the weapons you've already bought:");
                                        if (weapon1.owned == 1) { Console.WriteLine(" You own " + weapon1.name + ", which is a " + weapon1.type + " and can increase your dmg by " + weapon1.damage); }
                                        if (weapon2.owned == 1) { Console.WriteLine(" You own " + weapon2.name + ", which is a " + weapon2.type + " and can increase your dmg by " + weapon2.damage); }
                                        if (weapon3.owned == 1) { Console.WriteLine(" You own " + weapon3.name + ", which is a " + weapon3.type + " and can increase your dmg by " + weapon3.damage); }
                                        if (weapon4.owned == 1) { Console.WriteLine(" You own " + weapon4.name + ", which is a " + weapon4.type + " and can increase your dmg by " + weapon4.damage); }
                                        if (weapon1.owned == 1 || weapon2.owned == 1 || weapon3.owned == 1 || weapon4.owned == 1)
                                        {
                                            Console.WriteLine("Sofia: Would you like to equip one of the weapons? yes/no");
                                            string equipDecision = Console.ReadLine();
                                            if (equipDecision == "yes" || equipDecision == "Yes")
                                            {
                                                Console.WriteLine("Sofia: Tell me the name of the weapon you'd like to equip and I'll get it fro you from your locker.");
                                                string equipWeapon = Console.ReadLine();
                                                if (equipDecision == "Piercer" && weapon1.owned == 1)
                                                {
                                                    if (weapon == 0)
                                                    {
                                                        Console.WriteLine("Sofia: You have equipped " + weapon1.name + " and your damage has increased by " + weapon1.damage + ".");
                                                        weapon = 1;
                                                        player.GainDMG(weapon1.damage);
                                                        Console.Write(" Your damage is now " + player.damage + ".");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Sofia: Oh, it looks like you already have a weapon equipped. Equip this one instead?");
                                                        string changeWeapon = Console.ReadLine();
                                                        if (changeWeapon == "yes" || changeWeapon == "Yes")
                                                        {
                                                            if (weapon == 2) { ChangeWeapon(weapon2, weapon1, player); weapon = 1; }
                                                            if (weapon == 3) { ChangeWeapon(weapon3, weapon1, player); weapon = 1; }
                                                            if (weapon == 4) { ChangeWeapon(weapon4, weapon1, player); weapon = 1; }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Sofia: Nothing has changed.");
                                                        }
                                                    }
                                                }
                                                else if (equipDecision == "Mightbreakers" && weapon2.owned == 1)
                                                {
                                                    if (weapon == 0)
                                                    {
                                                        Console.WriteLine("Sofia: You have equipped " + weapon2.name + " and your damage has increased by " + weapon2.damage + ".");
                                                        weapon = 2;
                                                        player.GainDMG(weapon2.damage);
                                                        Console.Write(" Your damage is now " + player.damage + ".");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Sofia: You already have a weapon equipped. Equip this one instead?");
                                                        string changeWeapon = Console.ReadLine();
                                                        if (changeWeapon == "yes" || changeWeapon == "Yes")
                                                        {
                                                            if (weapon == 1) { ChangeWeapon(weapon1, weapon2, player); weapon = 2; }
                                                            if (weapon == 3) { ChangeWeapon(weapon3, weapon2, player); weapon = 2; }
                                                            if (weapon == 4) { ChangeWeapon(weapon4, weapon2, player); weapon = 2; }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Sofia: Nothing has changed.");
                                                        }
                                                    }
                                                }
                                                else if (equipDecision == "Executioner" && weapon3.owned == 1)
                                                {
                                                    if (weapon == 0)
                                                    {
                                                        Console.WriteLine("Sofia: You have equipped " + weapon3.name + " and your damage has increased by " + weapon3.damage + ".");
                                                        weapon = 3;
                                                        player.GainDMG(weapon3.damage);
                                                        Console.Write(" Your damage is now " + player.damage + ".");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Sofia: You already have a weapon equipped. Equip this one instead?");
                                                        string changeWeapon = Console.ReadLine();
                                                        if (changeWeapon == "yes" || changeWeapon == "Yes")
                                                        {
                                                            if (weapon == 1) { ChangeWeapon(weapon1, weapon3, player); weapon = 3; }
                                                            if (weapon == 2) { ChangeWeapon(weapon1, weapon3, player); weapon = 3; }
                                                            if (weapon == 4) { ChangeWeapon(weapon1, weapon3, player); weapon = 3; }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Sofia: Nothing has changed.");
                                                        }
                                                    }
                                                }
                                                else if (equipDecision == "Hellgate" && weapon4.owned == 1)
                                                {
                                                    if (weapon == 0)
                                                    {
                                                        Console.WriteLine("Sofia: You have equipped " + weapon4.name + " and your damage has increased by " + weapon4.damage + ".");
                                                        weapon = 4;
                                                        player.GainDMG(weapon4.damage);
                                                        Console.Write(" Your damage is now " + player.damage + ".");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Sofia: You already have a weapon equipped. Equip this one instead? yes/no");
                                                        string changeWeapon = Console.ReadLine();
                                                        if (changeWeapon == "yes" || changeWeapon == "Yes")
                                                        {
                                                            if (weapon == 1) { ChangeWeapon(weapon1, weapon4, player); weapon = 4; }
                                                            if (weapon == 2) { ChangeWeapon(weapon2, weapon4, player); weapon = 4; }
                                                            if (weapon == 3) { ChangeWeapon(weapon3, weapon4, player); weapon = 4; }
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Sofia: Nothing has changed.");
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Sofia: You don't own this weapon. If I have it, I can sell it to you, but otherwise I'm sorry, but I can't give it to you.");
                                                }
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Sofia: You currently don't own any weapons. If you'd like to use one though, give me some coins and I'l sell you one.");
                                        }
                                    }
                                    else if (decision1 == "c") { Console.WriteLine("Sofia: Let me see your wallet. Yep, you currently have " + player.currentCoins + " coins."); }
                                    else if (decision1 == "d")
                                    {
                                        Console.WriteLine(player.name + ": Which weapon is the best to choose? \nSofia: That depends on your fighting style. For example, I love machine guns because they’re quick and effective, but Marcel uses a katana for its style and swiftness. Similarly, Myst uses daggers for their compact size and Jacob uses a small shooter hidden in his mechanical armguard.");
                                        Console.WriteLine(" <a> I though Marcel used a shotgun. \n <b> What weapons do Chris or Claire use?\n <c> Aren’t machine guns a trouble because of their size?");
                                        string decision2 = Console.ReadLine();
                                        if (decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": I thought Marcel used a shotgun.\nSofia: Oh, right. I meant to say he used a katana. I’m still not used to seeing him without it.\n" + player.name + ": Why did he stop using it? \nSofia: I can’t say for certain, but I think it’s because of his ties to Emrys. They were close friends back in the day, to the point you never saw one without the other right next to him. Emrys was the one who focused on long-range weapons and especially used guns, while Marcel swung his katana upfront. \nSofia: I have a feeling that Marcel switched to Emrys’ signature weapon because he doesn’t want to let go of their past as friends, but he won’t admit it.");
                                        }
                                        else if (decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": What weapons do Chris or Claire use? \nSofia: Those to don’t really use weapons but rather master the usage of available things. As a half-bird, Chris is rather effective at using his wings and claws in fights, so along with a few upgrades from Jacob, he has his weapons.\nSofia: And Claire is a mage, so she relies mostly on her magic. Although, I do think that she grabbed a dagger at one point to keep on her body in case she’s unable to cast a spell.");
                                        }
                                        else if (decision2 == "c")
                                        {
                                            Console.WriteLine(player.name + ": Aren’t machine guns a trouble because of their size? \nSofia: Eh, they could be, but I honestly don’t view them as such. I like it when the guns are so massive that I can’t even carry them. Canons are also a favorite of mine, but they aren’t that effective anymore.\n" + player.name + ": What if there was a Story where they’d be effective? \nSofia: If you ever come across one, then count me in on the adventure.");
                                            characterArmory2.partnership = 1;
                                            Console.WriteLine(">>You may now ask Sofia to help you during a fight.<<");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (decision1 == "e" && characterArmory2.partnership == 1)
                                    {
                                        Console.WriteLine("Sofia: What adventure avaits us?");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterArmory2.addedDamage);
                                            player.GainHealth(characterArmory2.addedHealth);
                                            character = characterArmory2.index;
                                            Console.WriteLine(">Sofia joined your team. Your damage has increased by " + characterArmory2.addedDamage + " and your health increased by " + characterArmory2.addedHealth + ".");
                                        }
                                        else if (character == characterArmory2.index)
                                        {
                                            Console.WriteLine("Sofia is already on your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already have a different character on your team. Switch them out for " + characterArmory2.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 2) { SwapChars(characterGym2, characterArmory2, player); character = characterArmory2.index; }
                                                if (character == 3) { SwapChars(characterArmory1, characterArmory2, player); character = characterArmory2.index; }
                                                if (character == 1) { SwapChars(characterGym1, characterArmory2, player); character = characterArmory2.index; }
                                                if (character == 5) { SwapChars(characterCafeteria1, characterArmory2, player); character = characterArmory2.index; }
                                                if (character == 6) { SwapChars(characterCafeteria2, characterArmory2, player); character = characterArmory2.index; }
                                                if (character == 7) { SwapChars(characterCafeteria3, characterArmory2, player); character = characterArmory2.index; }
                                                if (character == 8) { SwapChars(characterLibrary1, characterArmory2, player); character = characterArmory2.index; }
                                                if (character == 9) { SwapChars(characterLibrary2, characterArmory2, player); character = characterArmory2.index; }
                                                Console.WriteLine(">Sofia joined your team. Your damage has increased by " + characterArmory2.addedDamage + " and your health increased by " + characterArmory2.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }


                                    }
                                    else { leave = 0; }
                                }
                                else if (decisionArmory == "Marcel" || decisionArmory == "marcel" && bossEnemyFountain.health < 0)
                                {
                                    Console.WriteLine("You walk over to the man with brunette hair and a cold gaze.\nMarcel: Hm? It's you, the Storyteller that's slowly making Stories safe again. What do you need?");
                                    Console.WriteLine(" <a> Can you tell me something more about this place?\n <b> Tell me something about Sofos.\n <c> Tell me something about Lumar.\n <d> Can you tell me something about the Angels?\n <e> Who's Emrys?");
                                    if (characterArmory1.partnership == 1) { Console.Write(" <f> Join me in a fight"); }
                                    string decision1 = Console.ReadLine();
                                    if(decision1 == "a")
                                    {
                                        Console.WriteLine(player.name + ": Can you tell me something more about this place?\nMarcel: You’d like to know more about the Crossroads? I suppose I can tell you something.\nMarcel: The Crossroads were created under one purpose - to preserve stories told by beings and safekeep them. Isadora’s great relatives transformed their story using angelic powers and since then that family looked over it. Their story became the Crossroads we know now.");
                                        Console.WriteLine(" <a> How did they do it?\n <b> Why did they do it?\n <c> How do they choose who becomes a Storyteller?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": How did they do it?\nMarcel: You already know about the angels and how they reincarnate. Whenever that happens, destruction strikes and that Story is erased from existence. \nMarcel: This happened here too. Isadora’s great grandmother became an angel and destroyed their Story. A lucky coincidence happened though, where at the same time Heaven was under attack by Hell. The demons interrupted the reincarnations and the great grandmother snapped out of her destructive thoughts. \nMarcel: She decided to use her powers to flood the burned world and create a place for her family that survived. Unfortunately, she didn’t allow herself to survive. The family buried her on the new land and created this. \nMarcel: The husband was an inventor and their daughter was a mage so when their skills were combined, they created what we now know as watches. They were able to visit other Stories, especially those with different magic laws from ours. Some of those people they took with them and brought this place to perfection.");
                                            Console.WriteLine(" <a> You know a lot. Were you here for all of this?\n <b> Is the anti-aging spell also the daughter’s doing?");
                                            string decision3 = Console.ReadLine();
                                            if(decision3 == "a")
                                            {
                                                Console.WriteLine(player.name + ": You know a lot. Were you here for all of this?\nMarcel: No, but I’m here long enough already to learn all of this. I was taken in by Isadora over two hundred Earth years ago.\n" + player.name + ": Really? You look something over 30 though.\nMarcel: That’s the power of the anti-aging spell. You barely celebrate your 20th birthday, but then you realise that 100 years have passed. That’s why you should always go back home and spend time with your family while they’re still there.\n" + player.name + ": What about your family?\nMarcel: They’re long gone, even before I came here. But the Crossroads are my family now, even though I hate to admit it. So go to Earth and spend time with them. I wouldn’t want you to get into a similar situation like Gabe.\n" + player.name + ": What happened to him?\nMarcel: He was a friend of mine before, uh, before we forbade him from continuing his work as a Storyteller and sent him back home. From what I heard, he was accepted back into the family, but they were hostile towards him because of his 30-year long disappearance. Though, I’m glad that he’s with them now. \nMarcel: Look, if you ever get into trouble, you can come to me for help. There’s no use troubling yourself on your own.");
                                                characterArmory1.partnership = 1;
                                                Console.WriteLine(">>You may now ask Marcel to help you during a fight.<<");
                                            }
                                            else if(decision3 == "b")
                                            {
                                                Console.WriteLine(player.name + ": Is the anti-aging spell also the daughter’s doing?\nMarcel: No, she wasn’t that powerful. That spell was created by the first mage that joined the Crossroads. You might’ve heard of her - her name is Genevieve.");
                                                if(talkedToGenevieve == 1) { Console.WriteLine(player.name + ": Yeah, I have. She’s the woman that dresses to look like a jellyfish. \nMarcel: Yes, that’s her. It’s a part of the culture she grew up in. But yes, Genevieve is an all-powerful mage that has been here since the beginning of the Crossroads. Time stopped for her the moment she came as she never left. She makes sure the magic level is balanced out with the abilities of this Story."); }
                                                else { Console.WriteLine(player.name + ": I haven’t actually. \nMarcel: You can’t miss her. She wears a big hat and looks like a jellyfish, usually resides in the library. She is an all-powerful mage that has been here since the beginning of the Crossroads. Time stopped for her the moment she came as she never left. She makes sure the magic level is balanced out with the abilities of this Story."); }
                                            }
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": Why did they do it?\nMarcel: To stop destruction from happening in other stories too. And even if it strikes, we want to save the Stories we can’t visit anymore. Of course, fighting against the destruction is a part of our job, but we can’t stop all of them. If everyone dying is their destiny, we can’t change it.\n" + player.name + ": Why can’t we change their story? We’d just leave them to die…\nMarcel: Because it was written in a specific way and what’s written is what has to happen. Otherwise, an anomaly would form and could completely erase the Story from existence. We have to avoid that.");
                                        }
                                        else if (decision2 == "c")
                                        {
                                            Console.WriteLine(player.name + ": How do they choose who becomes a Storyteller?\nMarcel: There are three main factors to become a Storyteller. The most important one is their unimportance to their Story. Since they won’t be there for most of its plot, they can’t be a part of main plot points or twists.\nMarcel: The other points are not as important, but we look for characters that are strong both physically and mentally. Travelling through different Stories can take a toll on the weak and we’d rather avert that.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "b")
                                    {
                                        Console.WriteLine(player.name + ": Tell me something about Sofos.\nMarcel: Have you met Claire?");
                                        Console.WriteLine(" <a> Yes, I have.\n <b> No, I haven’t.");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Yes, I have.\nMarcel: Then you figured out that’s her Story.\n" + player.name + ": How did she become a Storyteller if she’s at the centre of the story?\nMarcel: Her story ended long before we arrived so we were able to take her with us. Clair actually wished to run away from there.\n" + player.name + ": Why did she want that?\nMarcel: Her story was never a happy one. I don’t know what exactly happened, but I know that she lost someone she loved dearly. She wished to escape the world she destroyed and start a new one.\n" + player.name + ": How did she destroy it?\nMarcel: The powers she have are closely linked to her mental state. When her lover died, she broke down and lost control. Nothing remained…");
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": No, I haven’t.\nMarcel: Go talk to her, she has something interesting to say about that Story.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "c")
                                    {
                                        Console.WriteLine(player.name + ": Tell me something about Lumar? \nMarcel: You’re rather curious, aren’t you? Something about the Story that was destroyed by a flood?");
                                        Console.WriteLine(" <a> Why did the world flood?\n <b> What is the water spirit?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Why did the world flood?\nMarcel: It was an unfortunate accident we didn’t manage to prevent. An angel reincarnated in the middle of a festival and flooded the whole place. There were no survivors… Their story got lost in the Void.\n" + player.name + ": What happens in the Void?\nMarcel: Once a story with no survivors gets sent there, there’s no one to tell it. It disappears, forever.");
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": What is the water spirit?\nMarcel: After the angel left to Heaven, a fraction of its power remained and mixed with the Story. Since it was all water, the power transformed into a powerful spirit that was tasked to take care of any living being.\n" + player.name + ": Is it safe to fight?\nMarcel: Nothing is safe to fight. But if we manage to get rid of it, there might be at least some hope to find one living being that could tell the story.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "d")
                                    {
                                        Console.WriteLine(player.name + ": Can you tell me something about the Angels?\nMarcel: What would you like to know?");
                                        Console.WriteLine(" <a> How do the reincarnations work?\n <b> What’s their goal?");
                                        string decision2 = Console.ReadLine();
                                        if (decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": How do the reincarnations work?\nMarcel: In Heaven, there’s a special group of angels also known as the Thirteen. These thirteen angels are mere ideas, spirits, that enter the minds of characters from all kinds of Stories. They possess this character and completely change their ideals. If this character is weak enough, the spirit takes over their body and lives like a normal angel.\nMarcel: Whenever the angel dies, the spirit survives and just possesses another character. That’s what we call them reincarnating. You can’t get rid of them.");
                                            Console.WriteLine(" <a> Are they dangerous?\n <b> Have you ever crossed paths with an angel?\n <c> I’d like to meet an angel one day.\n <d> What if we just destroyed Heaven?");
                                            string decision3 = Console.ReadLine();
                                            if(decision3 == "a")
                                            {
                                                Console.WriteLine(player.name + ": Are they dangerous?\nMarcel: Overlooking the fact their reincarnation causes mass destruction, the Thirteen are able to manipulate with different elements of nature. Each has their respective one.\n" + player.name + ": What elements are there?\nMarcel: Aside from the main four – fire, water, wind, earth – there’s also nature, electricity, ice, light and darkness.\n" + player.name + ": And the other four?\nMarcel: Those are more specific and not to be messed with. It’s death and life, time, and the most powerful of all, atom manipulation.");
                                            }
                                            else if(decision3 == "b")
                                            {
                                                Console.WriteLine(player.name + ": Have you ever crossed paths with an angel?\nMarcel: Only once, when I was still a young Storyteller on one of my first missions. This angel was skilled and I barely survived. It was a game of pure luck; I was saved by a different angel calling a meeting. If it weren’t for them, I wouldn’t be here today.");
                                            }
                                            else if(decision3 == "c")
                                            {
                                                Console.WriteLine(player.name + ": I’d like to meet an angel one day.\nMarcel: If I were you, I’d wish I’d never cross paths with one. They’re unpredictable and chaotic, uncontrollable. Meeting one could mean an early death.");
                                            }
                                            else if(decision3 == "d")
                                            {
                                                Console.WriteLine(player.name + ": What if we just destroyed Heaven?\nMarcel: An interesting idea, but we aren’t here to destroy Stories. Even if they’re something like them. Besides, destroying a story is something only an angel can do.");
                                            }
                                            else { leave = 0; }
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": What’s their goal?\nMarcel: Absolute obedience. They want to be worshipped, bowed to, to be feared. And the only way they can achieve that is by getting rid of anyone against them.\n" + player.name + ": What about the people that do worship them?\nMarcel: They aren’t their own person. One day, I’ll take you to visit a story that an angel has changed. It’s all monotone.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "e")
                                    {
                                        Console.WriteLine(player.name + ": Who's Emrys? \nMarcel: Emrys was once a dear friend of mine, the closest one I ever had. He was taken in as a Storyteller, similarly as Claire or me. But he mingled with the wrong crowd. I couldn’t stop him until it was too late.");
                                        Console.WriteLine(" <a> Is he truly our enemy?\n <b> Did you try to fight him?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Is he truly our enemy?\nMarcel: He’s a threat to the Crossroads, so that makes him an enemy.\n" + player.name + ": But he was once so close to you…\nMarcel: Your bond doesn’t matter if your life is in danger. He chose his side and I chose mine. There’s nothing I can do.");
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": Did you try to fight him?\nMarcel: If there was one person I wouldn’t aim my gun at, it’s Emrys.\n" + player.name + ": But you never hesitate to use your gun. Was he special to you somehow?\nMarcel: … I don’t know. He’s the enemy, but I still can’t stand seeing him hurt. I can’t live with myself knowing I caused him agony. Don’t ask me to fight him.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (decision1 == "f" && characterArmory1.partnership == 1)
                                    {
                                        Console.WriteLine("Marcel: What adventure avaits us?");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterArmory1.addedDamage);
                                            player.GainHealth(characterArmory1.addedHealth);
                                            character = characterArmory1.index;
                                            Console.WriteLine(">Marcel joined your team. Your damage has increased by " + characterArmory1.addedDamage + " and your health increased by " + characterArmory1.addedHealth + ".");
                                        }
                                        else if (character == characterArmory1.index)
                                        {
                                            Console.WriteLine("Marcel is already on your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already have a different character on your team. Switch them out for " + characterArmory1.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 2) { SwapChars(characterGym2, characterArmory1, player); character = characterArmory1.index; }
                                                if (character == 4) { SwapChars(characterArmory2, characterArmory1, player); character = characterArmory1.index; }
                                                if (character == 1) { SwapChars(characterGym1, characterArmory1, player); character = characterArmory1.index; }
                                                if (character == 5) { SwapChars(characterCafeteria1, characterArmory1, player); character = characterArmory1.index; }
                                                if (character == 6) { SwapChars(characterCafeteria2, characterArmory1, player); character = characterArmory1.index; }
                                                if (character == 7) { SwapChars(characterCafeteria3, characterArmory1, player); character = characterArmory1.index; }
                                                if (character == 8) { SwapChars(characterLibrary1, characterArmory1, player); character = characterArmory1.index; }
                                                if (character == 9) { SwapChars(characterLibrary2, characterArmory1, player); character = characterArmory1.index; }
                                                Console.WriteLine(">Marcel joined your team. Your damage has increased by " + characterArmory1.addedDamage + " and your health increased by " + characterArmory1.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }
                                    }
                                    else { leave = 0; }
                                }
                                else { leave = 0; }
                            }
                        }   
                        else if (crossroadsRoom == "Gym" || crossroadsRoom == "gym")
                        {
                            int leave = 1;
                            Console.WriteLine("\nYou are at the Gym.\nHere, you can chat with -Mark- or talk to -Claire-.");
                            while (leave == 1)
                            {
                                Console.WriteLine("\nWhat would you like to do here?");
                                string decisionGym = Console.ReadLine();
                                if (decisionGym == "Mark" || decisionGym == "mark")
                                {
                                    Console.WriteLine("You approach the man, a brunette with neatly styled hair and eyes staring at a tablet with some data.\nMark: Oh, " + player.name + ". What can I help you with?");
                                    Console.WriteLine(" <a> Level up\n <b> My Experience points\n <c> Mark's experience points\n <d> Can you tell me something about robots or androids in Stories?");
                                    if (characterGym1.partnership == 1) { Console.WriteLine(" <e> Join me in a fight."); }
                                    string markDecision = Console.ReadLine();
                                    if (markDecision == "a") //level up
                                    {
                                        Console.WriteLine("How much EXP would you like to give?");
                                        int givenEXP = int.Parse(Console.ReadLine());
                                        if (givenEXP <= player.currentEXP)
                                        {
                                            player.UseExperience(givenEXP);
                                            markEXP += givenEXP;
                                            Console.WriteLine("You now have " + player.currentEXP + " experience points. Mark has " + markEXP + " experience points in total.");
                                        }
                                        else { Console.WriteLine("You can't give out " + givenEXP + " because you don't have that much. You only have " + player.currentEXP + " experience points."); }
                                        if (markEXP >= 10)
                                        {
                                            player.LevelUp(1);
                                            markEXP -= 10;
                                            Console.WriteLine("You have leveled up! You are now on level " + player.level + "!");
                                        }
                                        if (markEXP >= 25 && player.level == 2)
                                        {
                                            player.LevelUp(1);
                                            markEXP -= 25;
                                            Console.WriteLine("You have leveled up! You are now on level " + player.level + "!");
                                        }
                                        if (markEXP >= 40 && player.level == 3)
                                        {
                                            player.LevelUp(1);
                                            markEXP -= 40;
                                            Console.WriteLine("You have leveled up! You are now on level " + player.level + "!");
                                        }
                                        if (markEXP >= 65 && player.level == 4)
                                        {
                                            player.LevelUp(1);
                                            markEXP -= 65;
                                            Console.WriteLine("You have leveled up! You are now on level " + player.level + "!");
                                        }
                                        if (markEXP >= 70 && player.level == 5)
                                        {
                                            player.LevelUp(1);
                                            markEXP -= 70;
                                            Console.WriteLine("You have leveled up! You are now on level " + player.level + "!");
                                        }
                                    }
                                    else if (markDecision == "b") { Console.WriteLine("You have " + player.currentEXP + " experience points."); }
                                    else if (markDecision == "c")//Mark exp
                                    {
                                        Console.WriteLine("Mark has " + markEXP + " experience points.");
                                        if (markEXP < 10 && player.level == 1)
                                        {
                                            int result = 10 - markEXP;
                                            Console.WriteLine("Experience points remaining till next level: " + result);
                                        }
                                        if (markEXP < 25 && player.level == 2)
                                        {
                                            int result = 25 - markEXP;
                                            Console.WriteLine("Experience points remaining till next level: " + result);
                                        }
                                        if (markEXP < 40 && player.level == 3)
                                        {
                                            int result = 40 - markEXP;
                                            Console.WriteLine("Experience points remaining till next level: " + result);
                                        }
                                        if (markEXP < 65 && player.level == 4)
                                        {
                                            int result = 65 - markEXP;
                                            Console.WriteLine("Experience points remaining till next level: " + result);
                                        }
                                        if (markEXP < 70 && player.level == 5)
                                        {
                                            int result = 70 - markEXP;
                                            Console.WriteLine("Experience points remaining till next level: " + result);
                                        }
                                    }
                                    else if (markDecision == "d")//conversation
                                    {
                                        Console.WriteLine(player.name + ": Could you tell me something about robots in these Stories?\nMark: It’s different for each story. In most of them, AI doesn’t exist, so their robots are manual and programmed – usually made to complete only a small task and then turn off again. In those they exist in, they’re in one of three stages: the first, where they’re just walking up and fighting against discrimination; the second, where they’re living peacefully with the primal species; or the third, outliving their species and just living.");
                                        Console.WriteLine(" <a> Which stage is the safest?\n <b> Are there robots among the Storytellers?");
                                        string decision1 = Console.ReadLine();
                                        if (decision1 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Which stage is the safest?\nMark: For humans, stages one and two, since it doesn’t really matter in stage three as they’d be dead. But for robots it would be different.\nMark: In the first stage, they’re purely objects, facing their destiny or fighting for their lives in hopes for a better future. Living in harmony after is freeing from what they have before but as in every society, some will think they’re above humans and could start a robot-human war. For some, the third stage is the best one, for others it’s a stage of depression. It all depends on their relationship with humans.");
                                        }
                                        else if (decision1 == "b")
                                        {
                                            Console.WriteLine(player.name + ": Are there robots among the Storytellers?\nMark: There aren’t many, since the same criteria apply to them, but there are a couple. For example, Dante has a robot helper at the Library. It’s way easier for them to remember everything, because they download information into their files and then just search through them.\n" + player.name + ": That makes sense. Robots are rather convenient, aren’t they?\nMark: Yes, but let’s not forget that modern robots have feelings too. They can’t be treated like things.");
                                            Console.WriteLine(" <a> You’re quite pro-robot feelings.\n <b> I don’t think robots are human.");
                                            string decision2 = Console.ReadLine();
                                            if (decision2 == "a")
                                            {
                                                Console.WriteLine(player.name + ": You’re quite pro-robot feelings.\nMark: Of course, I am. I don’t want to disrespect anyone, not even robots. Besides, I myself fought hard for my freedom, I can’t imagine what they must’ve went through.\n" + player.name + ": … Mark, the way you talk… have you been a part of some android rebel group?\nMark: I’ve been a part of a revolution actually. As a robot myself, I couldn’t just stand by. In case you need a robot to assist you, you can always come by.");
                                                Console.WriteLine(">>You may now ask Mark to help you during a fight.<<");
                                                characterGym1.partnership = 1;
                                            }
                                            else if (decision2 == "b")
                                            {
                                                Console.WriteLine(player.name + ": I don’t think robots are human.\nMark: You’re right about that. Robots were never human and never will be. They’re purely similar.\nMark: Robots can of course endure much more then a human body can, which makes us better soldiers in the case of Storytellers. But we can’t mimic human empathy, that’s something deep and a very human trait. In my opinion, it should stay like that.");
                                            }
                                            else { leave = 0; }
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (markDecision == "e" && characterGym1.partnership == 1)
                                    {
                                        Console.WriteLine("Mark: How can I be of assistance?");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterGym1.addedDamage);
                                            player.GainHealth(characterGym1.addedHealth);
                                            character = characterGym1.index;
                                            Console.WriteLine(">Mark joined your team. Your damage has increased by " + characterGym1.addedDamage + " and your health increased by " + characterGym1.addedHealth + ".");
                                        }
                                        else if (character == characterGym1.index)
                                        {
                                            Console.WriteLine("Mark is already on your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already have a different character on your team. Switch them out for " + characterGym1.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 2) { SwapChars(characterGym2, characterGym1, player); character = characterGym1.index; }
                                                if (character == 3) { SwapChars(characterArmory1, characterGym1, player); character = characterGym1.index; }
                                                if (character == 4) { SwapChars(characterArmory2, characterGym1, player); character = characterGym1.index; }
                                                if (character == 5) { SwapChars(characterCafeteria1, characterGym1, player); character = characterGym1.index; }
                                                if (character == 6) { SwapChars(characterCafeteria2, characterGym1, player); character = characterGym1.index; }
                                                if (character == 7) { SwapChars(characterCafeteria3, characterGym1, player); character = characterGym1.index; }
                                                if (character == 8) { SwapChars(characterLibrary1, characterGym1, player); character = characterGym1.index; }
                                                if (character == 9) { SwapChars(characterLibrary2, characterGym1, player); character = characterGym1.index; }
                                                Console.WriteLine(">Mark joined your team. Your damage has increased by " + characterGym1.addedDamage + " and your health increased by " + characterGym1.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }
                                    }
                                    else { leave = 0; }
                                }
                                else if (decisionGym == "Claire" || decisionGym == "claire")
                                {
                                    Console.WriteLine("You approach Claire, a tall woman with long coal hair and sharp eyes.\n" + player.name + ": Hey Claire, how's it going?\nClaire: Ah, hi " + player.name + ". I'm doing quite alright.");
                                    Console.WriteLine(" <a> Can you give me tips on how to fight more properly?\n <b> Tell me something about Dark Castle.");
                                    if (characterGym2.partnership == 1) { Console.WriteLine(" <c> Join me in a fight."); }
                                    string decision1 = Console.ReadLine();
                                    if (decision1 == "a")
                                    {
                                        Console.WriteLine(player.name + ": Can you give me tips on how to fight more properly?\nClaire: How to fight more properly? I suppose you can’t do magic, right?");
                                        Console.WriteLine(" <a> Do I look like a mage?\n <b> No, I can’t");
                                        string decision2 = Console.ReadLine();
                                        if (decision2 == "a") { Console.WriteLine(player.name + ": Do I look like a mage?\nClaire: No, you don’t."); }
                                        else if (decision2 == "b") { Console.WriteLine(player.name + ": No, I can’t.\nClaire: Right, you are from Earth."); }

                                        Console.WriteLine("Claire: Well, I’m going to try to give you some tips on close combat then, but I don’t use it that often.\nClaire: When you’re approached by an opponent, your first instinct should always be protecting your weak spots such as the face and vital organs. Your hands are durable so use those as a shield if you don’t have one.\nClaire: A good tactic is also to tire out your opponent and strike when they’re exhausted or catching their breath. It may seem unfair, but it is used because of its pros.\nClaire: If your opponent manages to hold you in an awkward position, don’t be afraid to use any means necessary to free yourself.");
                                        Console.WriteLine(" <a> Thanks, that’s rather helpful!\n <b> That didn’t help me at all.");
                                        string decision3 = Console.ReadLine();
                                        if (decision3 == "a") { Console.WriteLine(player.name + ": Thanks, that’s rather helpful!\nClaire: I’m glad I could help."); }
                                        else if (decision3 == "b") { Console.WriteLine(player.name + ": That didn’t help me at all.\nClaire: I never said I was an expert; I use my magic to defeat enemies.\n" + player.name + ": You keep mentioning magic. Are you a mage?\nClaire: I’m actually a witch. Unlike mages, Genevieve for example, I don’t draw magic from natural sources nor was I given it at birth. I was cursed by a demon with this power and I fight against it." + player.name + ": Cursed? But you seem extremely skilled with it.\nClaire: After a few dozens of years you realise you won’t get rid of your curse, so I came to terms with it and took advantage of it. I don’t view it as a curse anymore, it’s now like a blessing thanks to which I can protect my friends."); }
                                    }
                                    else if (decision1 == "b")
                                    {
                                        Console.WriteLine(player.name + ": Tell me something about Dark Castle.\nClaire: If you want to know more about that story you should go see Dante.");
                                        Console.WriteLine(" <a> I want to hear your opinion.\n <b> I’ll go see him then.");
                                        string decision2 = Console.ReadLine();
                                        if (decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": I want to hear your opinion.\nClaire: I see. It’s a dark place that isn’t recommended to all Storytellers. The opponents there are mindless.");
                                            Console.WriteLine(" <a> What can you tell me about the monsters?\n <b> What happened there?\n <c> Seems like you’ve been there before.");
                                            string decision3 = Console.ReadLine();
                                            if (decision3 == "a")
                                            {
                                                Console.WriteLine(player.name + ": What can you tell me about the monsters?\nClaire: They aren’t some beings you can easily see or touch. They were created using dark matter and wonder the earth. When the witch disappeared, so did her control over them. They’re ruthless and use magic against you. Be careful.");
                                            }
                                            else if (decision3 == "b")
                                            {
                                                Console.WriteLine(player.name + ": What happened there?\nClaire: Time ago, a witch resided in a castle at the centre of this Story. She was isolated and never let anyone near her due to her powers. Anyone who tried to approach her was taken down by monsters that were manifested by her power.\n" + player.name + ": So they were afraid of her?\nClaire: … Yes. They feared her power and what she could do. And honestly, she was glad they didn’t bother her. She never felt lonely either, she had two friends to keep her company, even though their official roles were her servants. She viewed them as family.\n" + player.name + ": Then calling her evil doesn’t really make sense.\nClaire: No, it doesn't. She was just afraid of hurting others so she pushed them all away. She placed fear into their hearts so that the others will leave her alone.\n" + player.name + ": You are the witch, aren’t you?\nClaire: …\nClaire: I am, but I’m also not. I learned from my mistakes and stopped running away from my powers. I can actually help people now. If you’re planning to go to my Story, I’d be happy to go with you and assist you.");
                                                Console.WriteLine(">>You may now ask Claire to help you during a fight.<<");
                                                characterGym2.partnership = 1;
                                            }
                                            else if (decision3 == "c")
                                            {
                                                Console.WriteLine(": Seems like you’ve been there before.\nClaire: On a few occasions I visited the Story. Since that witch’s magic is similar to mine, I go there on studies.\n" + player.name + ": Have you found any links?\nClaire: A few of them. It looks like we’ve been cursed by the same demon and have similar strengths. I’d like to spar with this witch one day....");
                                            }
                                            else { leave = 0; }
                                        }
                                        else if (decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": I’ll go see him then.\nClaire: Send him my regards.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (decision1 == "c" && characterGym2.partnership == 1)
                                    {
                                        Console.WriteLine("Claire: I'll gladly help you.");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterGym2.addedDamage);
                                            player.GainHealth(characterGym2.addedHealth);
                                            character = characterGym2.index;
                                            Console.WriteLine(">Claire joined your team. Your damage has increased by " + characterGym2.addedDamage + " and your health increased by " + characterGym2.addedHealth + ".");
                                        }
                                        else if (character == characterGym2.index)
                                        {
                                            Console.WriteLine("Claire is already in your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You have a different character on your team. Switch them out for " + characterGym2.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 1) { SwapChars(characterGym1, characterGym2, player); character = characterGym2.index; }
                                                if (character == 3) { SwapChars(characterArmory1, characterGym2, player); character = characterGym2.index; }
                                                if (character == 4) { SwapChars(characterArmory2, characterGym2, player); character = characterGym2.index; }
                                                if (character == 5) { SwapChars(characterCafeteria1, characterGym2, player); character = characterGym2.index; }
                                                if (character == 6) { SwapChars(characterCafeteria2, characterGym2, player); character = characterGym2.index; }
                                                if (character == 7) { SwapChars(characterCafeteria3, characterGym2, player); character = characterGym2.index; }
                                                if (character == 8) { SwapChars(characterLibrary1, characterGym2, player); character = characterGym2.index; }
                                                if (character == 9) { SwapChars(characterLibrary2, characterGym2, player); character = characterGym2.index; }
                                                Console.WriteLine(">Claire joined your team. Your damage has increased by " + characterGym2.addedDamage + " and your health increased by " + characterGym2.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }
                                    }
                                    else { leave = 0; }
                                }
                                else { leave = 0; }
                            }
                            }
                        else if (crossroadsRoom == "Cafeteria" || crossroadsRoom == "cafeteria")
                        {
                            int leave = 1;
                            Console.WriteLine("\nYou are at the Cafeteria. Here you can chat with -Jacob-, -Chris- or -Myst- or you can get some -food- to heal.");
                            while (leave == 1)
                            {
                                Console.WriteLine("What would you like to do here?");
                                string decision = Console.ReadLine();
                                if (decision == "food" || decision == "Food")
                                {
                                    Console.WriteLine("You approach the counter and see a couple of foods you could eat. These heal you, each for a different amount.\nYour health is now " + player.health + ".");
                                    if (meal1.amount > 0) { Console.Write(" There are " + meal1.amount + " portions of meal 1: " + meal1.name + "."); }
                                    if (meal2.amount > 0) { Console.Write(" There are " + meal2.amount + " portions of meal 2: " + meal2.name + "."); }
                                    if (meal3.amount > 0) { Console.Write(" There are " + meal3.amount + " portions of meal 3: " + meal3.name + "."); }
                                if (meal4.amount > 0) { Console.Write(" There are " + meal4.amount + " portions of meal 4: " + meal4.name + "."); }
                                if (meal5.amount > 0) { Console.Write(" There are " + meal5.amount + " portions of meal 5: " + meal5.name + "."); }
                                if (meal6.amount > 0) { Console.Write(" There are " + meal6.amount + " portion of meal 6: " + meal6.name + "."); }
                                Console.WriteLine("\nDo you wish to eat something? yes/no");
                                string eatFood = Console.ReadLine();
                                if (eatFood == "yes" || eatFood == "Yes")
                                {
                                    Console.WriteLine("Which food would you like to eat?.");
                                    string food = Console.ReadLine();
                                    if (food == "1" && meal1.amount > 0)
                                    {
                                        meal1.amount -= 1;
                                        if (player.health + meal1.addedHealth > player.maxHealth)
                                        {
                                            player.health = player.maxHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                        else
                                        {
                                            player.health += meal1.addedHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                    }
                                    if (food == "2" && meal2.amount > 0)
                                    {
                                        meal2.amount -= 1;
                                        if (player.health + meal2.addedHealth > player.maxHealth)
                                        {
                                            player.health = player.maxHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                        else
                                        {
                                            player.health += meal2.addedHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                    }
                                    if (food == "3" && meal3.amount > 0)
                                    {
                                        meal3.amount -= 1;
                                        if (player.health + meal3.addedHealth > player.maxHealth)
                                        {
                                            player.health = player.maxHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                        else
                                        {
                                            player.health += meal3.addedHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                    }
                                    if (food == "4" && meal4.amount > 0)
                                    {
                                        meal4.amount -= 1;
                                        if (player.health + meal4.addedHealth > player.maxHealth)
                                        {
                                            player.health = player.maxHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                        else
                                        {
                                            player.health += meal4.addedHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                    }
                                    if (food == "5" && meal5.amount > 0)
                                    {
                                        meal5.amount -= 1;
                                        if (player.health + meal5.addedHealth > player.maxHealth)
                                        {
                                            player.health = player.maxHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                        else
                                        {
                                            player.health += meal5.addedHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                    }
                                    if (food == "6" && meal6.amount > 0)
                                    {
                                        meal6.amount -= 1;
                                        if (player.health + meal6.addedHealth > player.maxHealth)
                                        {
                                            player.health = player.maxHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                        else
                                        {
                                            player.health += meal6.addedHealth;
                                            Console.WriteLine("Your health is now " + player.health);
                                        }
                                    }
                                }
                                else { leave = 0; }
                            }
                                else if(decision == "Jacob" || decision == "jacob")
                                {
                                    Console.WriteLine("You walk over to a table with a single person sitting there - a boy with dark brown hair, tinkering with some objects on the table. \nJacob: Hm? Oh, hey " + player.name + ".");
                                    Console.WriteLine(" <a> Are you the person producing mechanical parts for people?\n <b> Where do you work?");
                                    if(characterCafeteria1.partnership == 1) { Console.WriteLine(" <c> Join me in a fight."); }
                                    string decision1 = Console.ReadLine();
                                    if(decision1 == "a")
                                    {
                                        Console.WriteLine(player.name + ": Are you the person producing mechanical parts for people? \nJacob: At your service.. Do you require one or are you just curious about my work?");
                                        Console.WriteLine(" <a> Can I come to you if I’d need one in the future?\n <b> What do you make them from?");
                                        string decision2 = Console.ReadLine();
                                        if (decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Can I come to you if I’d need one in the future?\nJacob: Naturally, I don’t think anyone else really does these around here. Why are you asking though, are you scared you’re going to lose a body part during battle? If so, removing it surgically will be much less painful and definitely cleaner.\n" + player.name + ": No thanks, I don’t want a prosthetic. I was just wondering.\nJacob: Shame. I was really looking forward to another surgery. Haven’t done one in a while.\n" + player.name + ": A while? Who’d voluntarily get their limb replaced with a mechanical one? \nJacob: More people than you think, actually. I myself have a prosthetic.\n" + player.name + ": Really? Where? \nJacob: I have in my legs and one in my right arm. Those are made to help during exploring. The one in my arm is like a tablet and the ones in my legs are motors to make my movement faster. Then I have one near my heart to control my functions. You get scared after an accident.\n" + player.name + ": What happened? \nJacob: … Heart attack on a mission. I was lucky that the Story obtained advanced medicine and that Marcel was adroit and took me to a hospital. I wasn’t in a stable condition to return here and had to spend some time there. Since then, I don’t want to make such risks. It’s crazy how one incident makes you reevaluate your own life. \nJacob: Anyways, if you’d ever need help exploring, take me with you.");
                                            Console.WriteLine(">>You may now ask Jacob to help you during a fight.<<");
                                            characterCafeteria1.index = 1;
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": What do you make them from? \nJacob: The Crossroads have a mage that can turn water into steal and other precious metals. I usually just ask her and exchange it for some gadgets, coins or food. She’s rather easy to please, so that’s an advantage.\n" + player.name + ": Sounds convenient. Who is she? \nJacob: One of Genevieve’s pupils, but she is a Storyteller. Her name’s Delilah, but I don’t think you’ve heard of her. She isn’t one for the spotlight and usually stays hidden by the people she trusts. For example, Genevieve or Dante. ");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "b")
                                    {
                                        Console.WriteLine(player.name + ": Where do you work? \nJacob: There’s a laboratory in the bottom floors, but the entry is restricted only to working characters and higher authorities. And unless you’re really into chemistry or science, I don’t think you’d like it there.");
                                        Console.WriteLine(" <a> Who belongs among the higher authorities?\n <b> I’m fairly interested in science.");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Who belongs among the higher authorities? \nJacob: Well, Isadora and Amos naturally, as the leaders of the Crossroads. You’ve met Isadora before, she does the whole introduction thing to all new Storytellers, but Amos is more hidden. He’s like her shadow – always there but not always seen and always silently watching. He’s a great ally though, you wouldn’t want to get on his bad side.\n" + player.name + " Yeah, I think I saw Amos too. Is there anyone else among them? \nJacob: Ah, yes, how could’ve I forgotten. Marcel is among them too. He isn’t really in command, but he’s Isadora’s right-hand-man and her first pick when she needs to get a job done. Everyone here admires his work, but make sure not to get on his bad side. He can be rather scary.");
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": I’m fairly interested in science.\nJacob: You are? That’s awesome! It’s good to meet a fellow science student. I could try getting you an access card from Isadora if you’re interested. No promises though, she has to trust you first and you need a lot of experience. ");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "c" && characterCafeteria1.partnership == 1)
                                    {
                                        Console.WriteLine("Jacob: An exploration ahead?");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterCafeteria1.addedDamage);
                                            player.GainHealth(characterCafeteria1.addedHealth);
                                            character = characterCafeteria1.index;
                                            Console.WriteLine(">Jacob joined your team. Your damage has increased by " + characterCafeteria1.addedDamage + " and your health increased by " + characterCafeteria1.addedHealth + ".");
                                        }
                                        else if (character == characterCafeteria1.index)
                                        {
                                            Console.WriteLine("Jacob is already on your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already have a different character on your team. Switch them out for " + characterCafeteria1.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 2) { SwapChars(characterGym2, characterCafeteria1, player); character = characterCafeteria1.index; }
                                                if (character == 4) { SwapChars(characterArmory2, characterCafeteria1, player); character = characterCafeteria1.index; }
                                                if (character == 1) { SwapChars(characterGym1, characterCafeteria1, player); character = characterCafeteria1.index; }
                                                if (character == 3) { SwapChars(characterArmory1, characterCafeteria1, player); character = characterCafeteria1.index; }
                                                if (character == 6) { SwapChars(characterCafeteria2, characterCafeteria1, player); character = characterCafeteria1.index; }
                                                if (character == 7) { SwapChars(characterCafeteria3, characterCafeteria1, player); character = characterCafeteria1.index; }
                                                if (character == 8) { SwapChars(characterLibrary1, characterCafeteria1, player); character = characterCafeteria1.index; }
                                                if (character == 9) { SwapChars(characterLibrary2, characterCafeteria1, player); character = characterCafeteria1.index; }
                                                Console.WriteLine(">Jacob joined your team. Your damage has increased by " + characterCafeteria1.addedDamage + " and your health increased by " + characterCafeteria1.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }
                                    }
                                    else { leave = 0; }

                                }
                                else if(decision == "Chris" || decision == "chris")
                                {
                                    Console.WriteLine("You carefully approach the man-bird or something of that sort. The person had a male human body, but feathers grew out of their skin on the arms, legs and face; and there were two wings growing out of his back. Based on the colouring, he looked like a falcon, but who knows what Story he was from. \nChris: Oh hey," + player.name + "! It’s good to see you!");
                                    Console.WriteLine(" <a> Who are you?\n <b> How close are you to a regular bird?");
                                    if(characterCafeteria2.partnership == 1) { Console.WriteLine(" <c> Join me in a fight."); }
                                    string decision1 = Console.ReadLine();
                                    if(decision1 == "a")
                                    {
                                        Console.WriteLine(player.name + ": Who are you? \nChris: Me? Well, I say that I’m a mutant, but human or bird works too. Everyone has their own opinion about this and everyone has a different view of what’s human. To a normal person, like you, I am more bird, but to someone else, for example an actual bird, I am more human. I belong in my own group.");
                                        Console.WriteLine(" <a> Are there others like you?\n <b> What type of bird are you?\n <c> Can you swim?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Are there others like you? \nChris: Where I come from, yeah. My Story doesn’t have humans, but only mutants of humans and various animals. Trust me, it was a shock when I first met Isadora and discovered your species. But, I soon found out that there were others like me.");
                                            Console.WriteLine(" <a> Can I travel there?\n <b> Were you violent?");
                                            string decision3 = Console.ReadLine();
                                            if(decision3 == "a")
                                            {
                                                Console.WriteLine(player.name + ": Can I travel there? \nChris: No, it’s not recommended. Meeting a species that isn’t natural in the Story could shift the plot in a completely different direction. Same goes for the other way around. If I cannot use the Stories’ law to explain my existence without creating nonsense, I can’t enter it and must leave it to someone else.\n" + player.name + ": That’s rather limiting. \nChris: It is, but I get to travel to Stories no one else can, like my own Story. And that just makes me special.");
                                            }
                                            else if(decision3 == "b")
                                            {
                                                Console.WriteLine(player.name + ": Were you violent? \nChris: I don’t think I was, no. Isadora took a good approach, explaining everything in my terms first. And taking Genevieve with her was the best idea she could’ve had. Since she dresses to look like a jellyfish, I saw some familiarity in her.\n" + player.name + ": Does Isadora pick up new Storytellers alone? \nChris: I don’t think she ever has. When she is picking up new Storytellers, she usually takes Marcel or Amos with her to serve as an ally. She hates violence and honestly is too kind for her own good, so they make sure she returns safely. \nChris: When it comes to specific Stories though, she takes someone from the higher circle to help her navigate through it. A good example is my own case or the case of Emrys.\n" + player.name + ": What kind of Story is he from? \nChris: I don’t know the exact name or situation, but when he was brought in there was a world-wide apocalypse and war going on. Everyone says that Emrys was scarred mentally growing up in this environment, but I haven’t met him so I can’t tell you my opinion. ");
                                            }
                                            else { leave = 0; }
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": What type of bird are you? \nChris: I always forget it, but I think it’s specifically an amur falcon… Yeah, Jacob said something like that. I think it’s pretty cool actually.\n" + player.name + ": Are you close with Jacob? \nChris: Hm? I suppose we are. He was one of the first friends I made here and still is my closest one. He also does my medical check-ups and was the one who made a sort of armour for my claws so that I wouldn’t break them while fighting. He’s really awesome… ");
                                        }
                                        else if(decision2 == "c")
                                        {
                                            Console.WriteLine(player.name + ": Can you swim? \nChris: Oh, no. I avoid water like the flare. I never learned how to swim and I don’t plan on learning now. Just flying is easier anyways and we have people who prefer swimming for those kinds of missions. Or I’ll just make you do it. In fact, let’s go right now.");
                                            Console.WriteLine(">>You may now ask Chris to help you during a fight.<<");
                                            characterCafeteria2.partnership = 1;
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "b")
                                    {
                                        Console.WriteLine(player.name + ": How close are you to a regular bird? \nChris: Well, I am a mix of human and bird, so quite close I’d say. ");
                                        Console.WriteLine(" <a> What do you eat?\n <b> Do you have hollow bones?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": What do you eat? \nChris: Over the years I learned to eat normal human food, but I can still digest raw meat too. Not that I eat it often, but, when necessary, I can.\n" + player.name + ": What’s your favourite meal? \nChris: I’d say any type of shellfish, especially shrimp and lobsters. There’s just something about their taste that’s so delicious, but also hard to explain. Whenever I put it in my mouth it just feels like heaven. \nChris: On the contrary, I hate vegetables. They’re weirdly green and completely disgusting. I feel like they’re going to poison me or drill a hole through my stomach. Ugh, just thinking about it is making me sick. \n" + player.name + ": Do you ever crave raw meat? \nChris: Hm, not that often anymore, no. I remember not being used to this place and needing to go back to my own Story just to eat. It was Jacob who came up with the solution to start raise live animals here for hunting species like me to eat fresh raw meat if the cravings ever came. \n" + player.name + ": Jacob really does do a lot, huh? \nChris: Yeah. I think it’s just because he’s a scientist and he views most of us as experiments, but his ideas are beneficial for all of us. And, deep down, I believe he cares about us. Even if he doesn’t admit it.");
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": Do you have hollow bones? \nChris: Obviously, yeah. It’s shocking I didn’t break anything yet, but Jacob has special plates prepared in case that happens. I always feel like a pet whenever he makes the simplest of check-ups, but I’m grateful for him. For some reason he does these things without actually being a veterinarian. ");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "c" && characterCafeteria2.partnership == 1)
                                    {
                                        Console.WriteLine("Chris: A joined mission?");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterCafeteria2.addedDamage);
                                            player.GainHealth(characterCafeteria2.addedHealth);
                                            character = characterCafeteria2.index;
                                            Console.WriteLine(">Chris joined your team. Your damage has increased by " + characterCafeteria2.addedDamage + " and your health increased by " + characterCafeteria2.addedHealth + ".");
                                        }
                                        else if (character == characterCafeteria2.index)
                                        {
                                            Console.WriteLine("Chris is already on your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already have a different character on your team. Switch them out for " + characterCafeteria2.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 2) { SwapChars(characterGym2, characterCafeteria2, player); character = characterCafeteria2.index; }
                                                if (character == 4) { SwapChars(characterArmory2, characterCafeteria2, player); character = characterCafeteria2.index; }
                                                if (character == 1) { SwapChars(characterGym1, characterCafeteria2, player); character = characterCafeteria2.index; }
                                                if (character == 3) { SwapChars(characterArmory1, characterCafeteria2, player); character = characterCafeteria2.index; }
                                                if (character == 5) { SwapChars(characterCafeteria1, characterCafeteria2, player); character = characterCafeteria2.index; }
                                                if (character == 7) { SwapChars(characterCafeteria3, characterCafeteria2, player); character = characterCafeteria2.index; }
                                                if (character == 8) { SwapChars(characterLibrary1, characterCafeteria2, player); character = characterCafeteria2.index; }
                                                if (character == 9) { SwapChars(characterLibrary2, characterCafeteria2, player); character = characterCafeteria2.index; }
                                                Console.WriteLine(">Chris joined your team. Your damage has increased by " + characterCafeteria2.addedDamage + " and your health increased by " + characterCafeteria2.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }
                                    }
                                    else { leave = 0; }
                                }
                                else if(decision == "Myst" || decision == "myst")
                                {
                                    Console.WriteLine("Your eyes land on a petite girl with beautiful dragonfly wings. She turns back at you with a smile. \nMyst: Hey" + player.name + ", what are you up to?");
                                    Console.WriteLine(" <a> Are you an actual dragonfly?\n <b> How do you even fight?");
                                    if(characterCafeteria3.partnership == 1) { Console.WriteLine(" <c> Join me in a fight."); }
                                    string decision1 = Console.ReadLine();
                                    if(decision1 == "a")
                                    {
                                        Console.WriteLine(player.name + ": Are you an actual dragonfly? \nMyst: Well, yeah. Do I look like an octopus to you? I’m a mutant of a dragonfly and a human if you want it precisely, something similar to what Chris is. Except my animal’s features aren’t as visible. That’s a main difference between our Stories.");
                                        Console.WriteLine(" <a> Are humans afraid of you because you are a bug?\n <b> Do you eat flies? ");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Are humans afraid of you because you are a bug? \nMyst: Not really, since a lot of people aren’t afraid of dragonflies as much. But other bugs from my Story could be feared around here. I don’t even know why someone would be afraid of bugs, it’s so stupid.");
                                            Console.WriteLine(" <a> I’m actually afraid of bugs.\n <a> I’m actually afraid of bugs.");
                                            string decision3 = Console.ReadLine();
                                            if(decision3 == "a")
                                            {
                                                Console.WriteLine(player.name + ": I’m actually afraid of bugs. \nMyst: Oh? Do I scare you then? Ah, don’t worry. I’ll promise not to scare you too much. Unless I’ll want your expression for blackmail.");
                                            }
                                            else if(decision3 == "b")
                                            {
                                                Console.WriteLine(player.name + ": I find it stupid too. \nMyst: Right? I mean, we don’t even do anything. We just exist and humans scream upon seeing us. Most of my species are more afraid of humans than they are of us. Which is why it’s so stupid. Do you even know how much spiders you swallow in your sleep? … You don’t want to know.");
                                            }
                                            else { leave = 0; }
                                        }
                                        else if (decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": Do you eat flies? \nMyst: What? Ew. No. They’re disgusting to even digest, ugh. Makes my skin crawl even thinking about it. I don’t understand how Chris can eat raw meat like his animal self. I could never.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if(decision1 == "b")
                                    {
                                        Console.WriteLine(player.name + ": How do you even fight? \nMyst: Well, I use flight to my advantage and I’m rather agile. Since coming here, I also learned some gymnastics from Gwen and use that in my fighting style. It’s quite effective.");
                                        Console.WriteLine(" <a> Is it really that effective?\n <b> What weapon do you use?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Is it really that effective? \nMyst: When fighting against species with little brain capacity, yeah. Their mindless movements aren’t prepared to be hit with a swift swung of the leg or a punch. But when it comes to more intelligent species, they could catch my attack mid-air, so I have to dodge too. It’s still swift though, so no complaints from me.\n" + player.name + ": Can you teach me some of it? \nMyst: If you can handle it, sure. Just tell me when and we can find some enemies to practice on.");
                                            Console.WriteLine(">>You may now ask Myst to help you during a fight.<<");
                                            characterCafeteria3.partnership = 1;
                                        }
                                        else if (decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": What weapon do you use? \nMyst: I don’t usually use a weapon, but when I do want to include the element of surprise, I do keep a small dagger on my body. It werves as a swift and easily hidden weapon, one you wouldn’t really expect, but it does significant damage if you know how to. It’s perfect.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (decision1 == "c" && characterCafeteria3.partnership == 1)
                                    {
                                        Console.WriteLine("Myst: Finally found some practice targets?");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterCafeteria3.addedDamage);
                                            player.GainHealth(characterCafeteria3.addedHealth);
                                            character = characterCafeteria3.index;
                                            Console.WriteLine(">Myst joined your team. Your damage has increased by " + characterCafeteria3.addedDamage + " and your health increased by " + characterCafeteria3.addedHealth + ".");
                                        }
                                        else if (character == characterCafeteria3.index)
                                        {
                                            Console.WriteLine("Myst is already on your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already have a different character on your team. Switch them out for " + characterCafeteria3.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 2) { SwapChars(characterGym2, characterCafeteria3, player); character = characterCafeteria3.index; }
                                                if (character == 4) { SwapChars(characterArmory2, characterCafeteria3, player); character = characterCafeteria3.index; }
                                                if (character == 1) { SwapChars(characterGym1, characterCafeteria3, player); character = characterCafeteria3.index; }
                                                if (character == 3) { SwapChars(characterArmory1, characterCafeteria3, player); character = characterCafeteria3.index; }
                                                if (character == 6) { SwapChars(characterCafeteria2, characterCafeteria3, player); character = characterCafeteria3.index; }
                                                if (character == 5) { SwapChars(characterCafeteria1, characterCafeteria3, player); character = characterCafeteria3.index; }
                                                if (character == 8) { SwapChars(characterLibrary1, characterCafeteria3, player); character = characterCafeteria3.index; }
                                                if (character == 9) { SwapChars(characterLibrary2, characterCafeteria3, player); character = characterCafeteria3.index; }
                                                Console.WriteLine(">Myst joined your team. Your damage has increased by " + characterCafeteria3.addedDamage + " and your health increased by " + characterCafeteria3.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }
                                    }
                                    else { leave = 0; }
                                }
                                else { leave = 0; }
                            }
                        }
                        else if (crossroadsRoom == "Library" || crossroadsRoom == "library")
                        {

                            int leave = 1;
                            Console.WriteLine("\nYou are at the Library. You can write -Coordinates- for a list coordinates, talk to -Dante- or talk to -Genevieve-.");
                            while (leave == 1)
                            {
                                Console.WriteLine("What would you like to do here?");
                                string decision = Console.ReadLine();
                                if (decision == "coordinates" || decision == "Coordinates")
                                {
                                    Console.WriteLine("You approach a small slip of paper with all the coordinates written down.\nCoordinates:\n Crossroads - 000000\n Earth - 071032\n Sofos - 000202\n Lumar - 142117\n Throsos - 201650\n Black Lotus - 053144");
                                }
                                else if(decision == "Dante" || decision == "dante")
                                {
                                    Console.WriteLine("A shorter man stood in a corner, reading through a book when he noticed you approach him, his blue beret almost falling off his head. \nDante: " + player.name + ", it’s a pleasure to see you.");
                                    Console.WriteLine(" <a> What is this place?\n <b> Which story are you from?");
                                    if(characterLibrary1.partnership == 1) { Console.WriteLine(" <c> Join me in a fight."); }
                                    string decision1 = Console.ReadLine();
                                    if(decision1 == "a")
                                    {
                                        Console.WriteLine(player.name + ": What is this place? \nDante: This? Oh, this is the library, you see? We keep all Stories here in book format and make sure nothing happens to them. There’s nothing more precious than books.");
                                        Console.WriteLine(" <a> What are the books for?\n <b> How are the books created?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": What are the books for? \nDante: They tell us how the plot’s supposed to go, what the characters are supposed to experience and all other information. They’re the purest format of these Stories, something almost sacred.\n" + player.name + ": Are all Stories here? \nDante: All the ones we’ve come across and written down. But anyone, anywhere, can write a Story. As soon as its characters are on paper along some plot, that Story exists in the wide Void, waiting to be seen. Once we find it, we bring it here and treasure it. Every character is worth loving. \n" + player.name + ": Can I also write a Story? \nDante: Of course, anyone can. You’re free to make your characters and give them a plot. Then, if we do find it in the Void and manage to assign coordinates to it, you might just meet your creations.");
                                        }
                                        else if (decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": How are books created? \nDante: When we discover a new Story, we write down the time we discovered it at. This time turns into coordinates that you can find for any existing Story. As soon as we have these coordinates, we can watch the Story and explore it. The more we do the more is written in these books. They manifest upon discovery.\n" + player.name + ": How do they know where to manifest? \nDante: It’s a combination of magic and an inside program. There has to be a place where these new books manifest and thanks to our mages, we managed to move it here, to the Crossroads. That’s how our Library can function the way it does. ");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (decision1 == "b")
                                    {
                                        Console.WriteLine(player.name + ": Which story are you from? \nDante: This might be a bit shocking, but I’m from Earth. The original Earth, actually. One with the dinosaurs, two world wars and covid. Well, I haven’t actually lived through those times though.");
                                        Console.WriteLine(" <a> How did you end up here?\n <b> Which time are you from then?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": How did you end up here? \nDante: That’s a funny story actually. Before I even knew about the Crossroads, I’ve been visited multiple times by an angel. He was beautiful and I felt drawn to him. I’ve written multiple novels just about his eyes, I couldn’t get enough of him. \nDante: And then, he took me here, where I learned about the Void, Stories and everything else surrounding it. I found out the angel wasn’t really a Storyteller, but more of an ally of the Crossroads in Heaven. I was never allowed to be a Storyteller though as we already had one from Earth.");
                                            Console.WriteLine(" <a> Who is this angel?\n <b> Do you want to be a Storyteller?");
                                            string decision3 = Console.ReadLine();
                                            if(decision3 == "a")
                                            {
                                                Console.WriteLine(player.name + ": Who is this angel? \nDante: His name is Amborse and he’s from a Story focused on an angel and a demon, that ended up together and produced a mixed child. That kid is Amborse, supposed to be a bridge between Heaven and Hell. But he’s on his own side, doing what he wants and helping us fight off the angels secretly.");
                                            }
                                            else if (decision3 == "b")
                                            {
                                                Console.WriteLine(player.name + ": Do you want to be a Storyteller? \nDante: No, not really. I’m not used to being in the spotlight or going out to complete a mission. I prefer it here, in the presence of books and a warm mug of tea. It’s relaxing and exactly something that after 800 years still doesn’t bore me. But, I’d like to look back home if I’d get a chance. Could you take me there if you ever go?");
                                                characterLibrary1.partnership = 1;
                                                Console.WriteLine(">>You may now ask Dante to help you during a fight.<<");
                                            }
                                            else { leave = 0; }
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": Which time are you from then? \nDante: I was born in 1265 in a small city called Florence, in Italy. Unfortunately, I was born at the same time as another boy with the same name. Unlike me, his writing was recognised and he became known worldwide. I focused more on the moment of things and wrote about that, but no one seemed interested.\n" + player.name + ": Are you talking about Dante Alighieri? \nDante: I should’ve known you knew him. Yeah, it was Alighieri. I must admit though, I like his writing too. He deserves his fame and I’m honoured to share my first name with him.");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (decision1 == "c" && characterLibrary1.partnership == 1)
                                    {
                                        Console.WriteLine("Dante: Would you take me on a trip?");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterLibrary1.addedDamage);
                                            player.GainHealth(characterLibrary1.addedHealth);
                                            character = characterLibrary1.index;
                                            Console.WriteLine(">Dante joined your team. Your damage has increased by " + characterLibrary1.addedDamage + " and your health increased by " + characterLibrary1.addedHealth + ".");
                                        }
                                        else if (character == characterLibrary1.index)
                                        {
                                            Console.WriteLine("Dante is already on your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already have a different character on your team. Switch them out for " + characterLibrary1.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 2) { SwapChars(characterGym2, characterLibrary1, player); character = characterLibrary1.index; }
                                                if (character == 4) { SwapChars(characterArmory2, characterLibrary1, player); character = characterLibrary1.index; }
                                                if (character == 1) { SwapChars(characterGym1, characterLibrary1, player); character = characterLibrary1.index; }
                                                if (character == 3) { SwapChars(characterArmory1, characterLibrary1, player); character = characterLibrary1.index; }
                                                if (character == 6) { SwapChars(characterCafeteria2, characterLibrary1, player); character = characterLibrary1.index; }
                                                if (character == 5) { SwapChars(characterCafeteria1, characterLibrary1, player); character = characterLibrary1.index; }
                                                if (character == 7) { SwapChars(characterCafeteria3, characterLibrary1, player); character = characterLibrary1.index; }
                                                if (character == 9) { SwapChars(characterLibrary2, characterLibrary1, player); character = characterLibrary1.index; }
                                                Console.WriteLine(">Dante joined your team. Your damage has increased by " + characterLibrary1.addedDamage + " and your health increased by " + characterLibrary1.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }
                                    }
                                    else { leave = 0; }
                                }
                                else if(decision == "Genevieve" || decision == "genevieve")
                                {
                                    talkedToGenevieve = 1;
                                    Console.WriteLine("The woman is immediately striking you as strange, a big hat on top of her head with strings of fabric sown to it and hanging down in a way it covered her face and made her look like a jellyfish. \nGenevieve: I knew you’d come here, " + player.name + ".");
                                    Console.WriteLine(" <a> What do you do here? \n <b> Can you see me?");
                                    if (characterLibrary2.partnership == 1) { Console.WriteLine(" <c> Join me in a fight."); }
                                    string decision1 = Console.ReadLine();
                                    if (decision1 == "a")
                                    {
                                        Console.WriteLine(player.name + ": What do you do here? \nGenevieve: I’m the head mage. That work consists of training other mages or witches and keeping the magic at the Crossroads stable. Of course, the anti-aging spell is also my doing so I need to make sure that doesn’t just disappear.");
                                        Console.WriteLine(" <a> How did you make the anti-aging speel work?\n <b> How powerful are you?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": How did you make the anti-aging speel work? \nGenevieve: It took a lot of preparation and experience, but I just created a shield of sorts, almost like a bubble I placed the Crossroads in. Then it was easy to make the speel work in this bubble.\n" + player.name + ": That means there are places in this Story I age at? \nGenevieve: Yeah, but I don’t recommend searching for them. Aging will be the least of your concerns once you find that place.");
                                        }
                                        else if (decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": How powerful are you? \nGenevieve: Do you ask every person you meet how powerful they are or did you get that from Marcel? It doesn’t matter, I’ll answer either way. \nGenevieve: You could say that I’m the most powerful mage in the Void. But I guess Marcel already said something like that, didn’t he?");
                                            Console.WriteLine(" <a> Do you have beef with Marcel?\n <b> If you’re the most powerful, why are you still here?");
                                            string decision3 = Console.ReadLine();
                                            if(decision3 == "a")
                                            {
                                                Console.WriteLine(player.name + ": Do you have beef with Marcel? \nGenevieve: I wouldn’t call it beef, we just have different opinions about certain people. We used to be close a long time ago, even had the same friends; Gabriel, Rene and Emrys. We were inseparable until the accident.\n" + player.name + ": What happened? \nGenevieve: It started with Emrys falling from grace and joining the bad guys, making himself our enemy. We tried to convince Marcel that there’s nothing he can do, but Marcel still believes otherwise. We lost Gabriel soon after, but he returned to his Story to live the rest of his life with his family. Unlike Rene, who went to a different Story to live her life. \nGenevieve: Just me and Marcel remained here, but we talk only barely and only when it’s truly important. Otherwise, we just send someone else to deliver the information for us. Sometimes, I try to figure out what went wrong, but I can’t seem to find it.");
                                            }
                                            else if (decision3 == "b")
                                            {
                                                Console.WriteLine(player.name + ": If you’re the most powerful, why are you still here? \nGenevieve: Because I want to. All my life I’ve been studying magic and perfecting it and now I have a place where they need me, where I belong. I’m using what I learned to help others, and that’s a feeling unlike any other. Even though I hate socializing, I don’t mind helping from the shadows. If you need my help, just say so.");
                                                characterLibrary2.partnership = 1;
                                                Console.WriteLine(">>You may now ask Genevieve to help you during a fight.<<");
                                            }
                                            else { leave = 0; }
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (decision1 == "b")
                                    {
                                        Console.WriteLine(player.name + ": Can you see me? \nGenevieve: Yes, I can see you. You aren’t really hiding, if you were curious about that. And yes, I can count how many fingers you’re holding up; it’s three.");
                                        Console.WriteLine(" <a> Wow, you really can see.\n <b> What is the fabric for if you can see?");
                                        string decision2 = Console.ReadLine();
                                        if(decision2 == "a")
                                        {
                                            Console.WriteLine(player.name + ": Wow, you really can see. \nGenevieve: Last I checked I wasn’t blind, so yes, of course I can see. I don’t understand the youngster’s curiosity about my rumoured blindness. I see more than you think so no funny business. I’m keeping an eye on you.");
                                        }
                                        else if(decision2 == "b")
                                        {
                                            Console.WriteLine(player.name + ": What is the fabric for if you can see? \nGenevieve: It was never to limit my own sight but to limit the sight of others. I don’t like presenting myself or being in the spotlight, so I use it to cover up my space and hide from others. \n" + player.name + ": Doesn’t that make you lonely? \nGenevieve: No, why would it? I’m just introverted and I like jellyfish. ");
                                        }
                                        else { leave = 0; }
                                    }
                                    else if (decision1 == "c" && characterLibrary2.partnership == 1)
                                    {
                                        Console.WriteLine("Genevieve: Need help from your shadow?");
                                        if (character == 0)
                                        {
                                            player.GainDMG(characterLibrary2.addedDamage);
                                            player.GainHealth(characterLibrary2.addedHealth);
                                            character = characterLibrary2.index;
                                            Console.WriteLine(">Genevieve joined your team. Your damage has increased by " + characterLibrary2.addedDamage + " and your health increased by " + characterLibrary2.addedHealth + ".");
                                        }
                                        else if (character == characterLibrary2.index)
                                        {
                                            Console.WriteLine("Genevieve is already on your team.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("You already have a different character on your team. Switch them out for " + characterLibrary2.name + "? yes/no");
                                            string swap = Console.ReadLine();
                                            if (swap == "yes" || swap == "Yes")
                                            {
                                                if (character == 2) { SwapChars(characterGym2, characterLibrary2, player); character = characterLibrary2.index; }
                                                if (character == 4) { SwapChars(characterArmory2, characterLibrary2, player); character = characterLibrary2.index; }
                                                if (character == 1) { SwapChars(characterGym1, characterLibrary2, player); character = characterLibrary2.index; }
                                                if (character == 3) { SwapChars(characterArmory1, characterLibrary2, player); character = characterLibrary2.index; }
                                                if (character == 6) { SwapChars(characterCafeteria2, characterLibrary2, player); character = characterLibrary2.index; }
                                                if (character == 5) { SwapChars(characterCafeteria1, characterLibrary2, player); character = characterLibrary2.index; }
                                                if (character == 8) { SwapChars(characterLibrary1, characterLibrary2, player); character = characterLibrary2.index; }
                                                if (character == 7) { SwapChars(characterCafeteria3, characterLibrary2, player); character = characterLibrary2.index; }
                                                Console.WriteLine(">Genevieve joined your team. Your damage has increased by " + characterLibrary2.addedDamage + " and your health increased by " + characterLibrary2.addedHealth + ".");
                                            }
                                            else { Console.WriteLine("Your team stays the same."); }
                                        }
                                    }
                                    else { leave = 0; }
                                }
                                else { leave = 0; }
                            }
                        }
                        else { break; }
                    }
                }
            Console.WriteLine("\nEnter coordinates.");
            while (player.health > 0)
            {
                string destinationString = Console.ReadLine();

                if (double.TryParse(destinationString, out _))
                {
                    destination = Convert.ToInt32(destinationString);
                    break;
                }
                else { Console.WriteLine("Destination not entered or entered incorrectly."); }
            }

            if (destination == 071032)
            {
                Console.WriteLine("\nWelcome to Earth.");
                if (enemyEarth1.health > 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter battle? yes/no");
                        string earthB1D1 = Console.ReadLine();
                        if (earthB1D1 == "yes")
                        {
                            Console.WriteLine("You walk through the forest, walking alongside many lakes. As you walk towards one of them, a sudden splash interrupts your thinking." +
                                " Is that a carp? Unfortunately, he's attacking you.\nFight the carp. yes/no");
                            string earthB1D2 = Console.ReadLine();
                            if (earthB1D2 == "yes") { Fight(player, enemyEarth1); }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (enemyEarth2.health > 0 && enemyEarth1.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the next battle? yes/no");
                        string earthB2D1 = Console.ReadLine();
                        if (earthB2D1 == "yes")
                        {
                            Console.WriteLine("You continue on your path through the deep forests, wondering why were these animals attacking you. Before you could piece your thoughts together, a " +
                                "russtling from above interrupted you. When you looked up, you could see a squirel falling onto your face.\nFight the squirel. yes/no");
                            string earthB2D2 = Console.ReadLine();
                            if (earthB2D2 == "yes") { Fight(player, enemyEarth2); }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (bossEnemyEarth.health > 0 && enemyEarth2.health < 0 && enemyEarth1.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the boss battle? yes/no");
                        string earthB2D1 = Console.ReadLine();
                        if (earthB2D1 == "yes")
                        {
                            Console.WriteLine("Your jusrney continues and you venture deeper into the forest until you meet an odd looking deer. Unfortunately," +
                                " it attacks you.\nFight the deer. yes/no");
                            string earthB2D2 = Console.ReadLine();
                            if (earthB2D2 == "yes")
                            {
                                Fight2(player, bossEnemyEarth);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if(bossEnemyEarth.health < 0) { Console.WriteLine("You have defeated all enemies in this Story, good job!"); }
            }

            if (destination == 000202)
            {
                Console.WriteLine("\nWelcome to Sofos.");
                if (enemyCastle1.health > 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter battle? yes/no");
                        string castleB1D1 = Console.ReadLine();
                        if (castleB1D1 == "yes")
                        {
                            Console.WriteLine("You enter an old palace, feeling a shiver run down your spine from the cold. You hold your weapon tighter and look around for any enemies. You didn't expect a spider to jump at you from a dark corner. \nFight the spider? yes/no");
                            string castleB1D2 = Console.ReadLine();
                            if (castleB1D2 == "yes")
                            {
                                Fight(player, enemyCastle1);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (enemyCastle2.health > 0 && enemyCastle1.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the next battle? yes/no");
                        string castleB2D1 = Console.ReadLine();
                        if (castleB2D1 == "yes")
                        {
                            Console.WriteLine("Your exploration of the castle continues, but this time you're more careful of your surroundings. Anything can attack from anywhere and you don't like risks. Just as you think about safety, another enemy pops up, this time a ghost made of black gas. \nFight the ghost? yes/no");
                            string castleB2D2 = Console.ReadLine();
                            if (castleB2D2 == "yes")
                            {
                                Fight(player, enemyCastle2);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (bossEnemyCastle.health > 0 && enemyCastle2.health < 0 && enemyCastle1.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the boss battle? yes/no");
                        string castleB2D1 = Console.ReadLine();
                        if (castleB2D1 == "yes")
                        {
                            Console.WriteLine("As you think this is the end of your journey, one of the stone statues decorating the roof moves and flies down towards you. \nFight the Gargoyle? yes/no");
                            string castleB2D2 = Console.ReadLine();
                            if (castleB2D2 == "yes")
                            {
                                Fight2(player, bossEnemyCastle);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                    if (bossEnemyCastle.health < 0) { Console.WriteLine("You have defeated all enemies in this Story, good job!"); }
                }

            if (destination == 142117)
            {
                Console.WriteLine("\nWelcome to Lumar.");
                if (enemyFountain1.health > 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter battle? yes/no");
                        string fountainB1D1 = Console.ReadLine();
                        if (fountainB1D1 == "yes")
                        {
                            Console.WriteLine("Upon entering this Story, you descend underwater. This Story has been flooded and you can see ancient sculptures and old buildings at the bottom of the deep sea. That's when you remember you can't breathe underwater, but wait, you can? As you wonder, you realise it could've been the mages doing, but then an octopus attacks.\nFight the octopus? yes/no");
                            string fountainB1D2 = Console.ReadLine();
                            if (fountainB1D2 == "yes")
                            {
                                Fight(player, enemyFountain1);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (enemyFountain2.health > 0 && enemyFountain1.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the next battle? yes/no");
                        string fountainB2D1 = Console.ReadLine();
                        if (fountainB2D1 == "yes")
                        {
                            Console.WriteLine("After your battle underwater, you feel exhausted, but the animals don't leave you be.\nFight the moray eel? yes/no");
                            string fountainB2D2 = Console.ReadLine();
                            if (fountainB2D2 == "yes")
                            {
                                Fight(player, enemyFountain2);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (bossEnemyFountain.health > 0 && enemyFountain2.health < 0 && enemyFountain1.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the boss battle? yes/no");
                        string fountainB2D1 = Console.ReadLine();
                        if (fountainB2D1 == "yes")
                        {
                            Console.WriteLine("Why are all the animals attacking you? Before you can even find an answer, you see something magestic and unreal in front of you. It looked like a see-through siren, maybe some sort of spirit. Whatever it was, it wanted you dead.\nFight the Water spirit? yes/no");
                            string fountainB2D2 = Console.ReadLine();
                            if (fountainB2D2 == "yes")
                            {
                                Fight2(player, bossEnemyFountain);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                    if (bossEnemyFountain.health < 0) { Console.WriteLine("You have defeated all enemies in this Story, good job!"); }
                }

            if (destination == 201650)
            {
                Console.WriteLine("\nWelcome to Throsos.");
                if (enemyMedival1.health > 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter battle? yes/no");
                        string medivalB1D1 = Console.ReadLine();
                        if (medivalB1D1 == "yes")
                        {
                            Console.WriteLine("This Story seems normal for now, except for its odd post-apocalyptic look. You have no idea what happened here, but you should be beware of everything that moves. This piece of advice is what everyone followed, as suddenly a man jumped you.\nFight the adventurer? yes/no");
                            string medivalB1D2 = Console.ReadLine();
                            if (medivalB1D2 == "yes")
                            {
                                Fight(player, enemyMedival1);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (enemyMedival2.health > 0 && enemyMedival1.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the next battle? yes/no");
                        string medivalB2D1 = Console.ReadLine();
                        if (medivalB2D1 == "yes")
                        {
                            Console.WriteLine("If you thought the adventurer was tough, you aren't ready for the adventurer's friend that's mad at you for hurting him.\nFight the knight? yes/no");
                            string medivalB2D2 = Console.ReadLine();
                            if (medivalB2D2 == "yes")
                            {
                                Fight(player, enemyMedival2);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (bossEnemyMedival.health > 0 && enemyMedival2.health < 0 && enemyMedival1.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the boss battle? yes/no");
                        string medivalB2D1 = Console.ReadLine();
                        if (medivalB2D1 == "yes")
                        {
                            Console.WriteLine("You manage to piece a few things together, such as the post-apocalyptic vibe being the result of a worldwide destructive power. You aren't even able to try and figure out what it was as the culplit steps forward. It looks like a woman, but her aura id screaming power, similarly to the demonic wings growing out of her back.\nFight Izumi? yes/no");
                            string medivalB2D2 = Console.ReadLine();
                            if (medivalB2D2 == "yes")
                            {
                                Fight2(player, bossEnemyMedival);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                    if (bossEnemyMedival.health < 0) { Console.WriteLine("You have defeated all enemies in this Story, good job!"); }
                }

            if (destination == 053144 && bossEnemyMedival.health > 0) { Console.WriteLine("You cannot enter this story yet. Defeat all previous enemies to enter."); }

            if (destination == 053144 && bossEnemyMedival.health < 0)
            {
                Console.WriteLine("\nWelcome to The Final Boss.");
                if (bossEnemyFinal.health > 0)
                {
                    while (true)
                    {
                        Console.WriteLine("\nWould you like to enter the boss battle? yes/no");
                        string finalB1D1 = Console.ReadLine();
                        if (finalB1D1 == "yes")
                        {
                            Console.WriteLine("As you stare down the final boss, you think to yourself, why are you even fighting this man? His wishes are valid, but dangerous. The Black Lotus don't care about the original authors or plots of Stories, freely changing them. That's why you need to stop them.\nFight Xander? yes/no");
                            string finalB1D2 = Console.ReadLine();
                            if (finalB1D2 == "yes")
                            {
                                Fight2(player, bossEnemyFinal);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                if (bossEnemyFinalFinal.health > 0 && bossEnemyFinal.health < 0)
                {
                    while (true)
                    {
                        Console.WriteLine("You thought this was the end?");
                        Console.WriteLine("\nWould you like to enter the boss battle? yes/no");
                        string finalB1D1 = Console.ReadLine();
                        if (finalB1D1 == "yes")
                        {
                            Console.WriteLine("Before you stood another man, one with a katana in hand and surrounded by odd fiery power. You don't know what to expect or how powerful this person was but you can deduce one thing from the undeniable stare he gave you. This was the Emrys.\nFight Emrys? yes/no");
                            string finalB1D2 = Console.ReadLine();
                            if (finalB1D2 == "yes")
                            {
                                Fight2(player, bossEnemyFinalFinal);
                            }
                        }
                        else
                        {
                            break;
                        }
                        break;
                    }
                }
                    if (bossEnemyEarth.health < 0) { Console.WriteLine("You have defeated the Final Boss and the greatest enemy of the Crossroads. Your adventure ends here, but your Story doesn't have to. Feel free to return to the Crossroads and catch up with people you haven't talked to yet. Now you're all safe, no need to stress over your safety."); }
                }
            }
            
            Console.WriteLine("You have died. Your story ends here and their will continue without you.");

            Console.ReadKey();
        }
    }
}

