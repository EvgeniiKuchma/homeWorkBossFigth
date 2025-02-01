using System;

namespace homeWorkBossFigth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandMeleeHeroAttack = "1";
            const string CommandFireballHeroAttack = "2";
            const string CommandExplosoinHeroAttack = "3";
            const string CommandHealingSpell = "4";

            int minValue = 10;
            int maxValue = 26;

            Random rand = new Random();

            int death = 0;
            int maxHeroHealthLevel = 100;
            int maxHeroManaLevel = 50;
            int heroHealthLevel = maxHeroHealthLevel;
            int heroManaLevel = maxHeroManaLevel;
            int meleeHeroAttack = rand.Next(minValue, maxValue);
            int fireballHeroAttack = 40;
            int fireballCostMana = 24;
            int fireballCount = 0;
            int heroExplosionAttack = 80;
            int heroHealingSpell = 50;
            int healingSpellUseCount = 2;
            int bossHealthLevel = 200;
            int bossAttack = rand.Next(minValue, maxValue); ;
            string userCommand = string.Empty;

            Console.WriteLine("Welcome hero are you redy to figth?");
            Console.WriteLine("Let's battle began!");
            Console.ReadKey();

            while (heroHealthLevel > death && bossHealthLevel > death)
            {
                Console.Clear();
                Console.WriteLine($"\nBoss health lvl = {bossHealthLevel}");
                Console.WriteLine($"Hero health lvl = {heroHealthLevel}");
                Console.WriteLine($"Hero mana lvl = {heroManaLevel}");
                Console.WriteLine("\nMake your choice attack hero:");
                Console.WriteLine($"{CommandMeleeHeroAttack} - take melee attack.");
                Console.WriteLine($"{CommandFireballHeroAttack} - take a fireball.");
                Console.WriteLine($"{CommandExplosoinHeroAttack} - take explosion.");
                Console.WriteLine($"{CommandHealingSpell} - take healing.");

                switch (userCommand = Console.ReadLine())
                {
                    case CommandMeleeHeroAttack:
                        Console.WriteLine("You choose melle attack;");
                        bossHealthLevel -= meleeHeroAttack;
                        heroHealthLevel -= bossAttack;
                        Console.ReadKey();
                        break;

                    case CommandFireballHeroAttack:
                        Console.WriteLine("You choose a fireball;");

                        if (heroManaLevel > fireballCostMana)
                        {
                            fireballCount = 1;
                            heroManaLevel -= fireballCostMana;
                            bossHealthLevel -= fireballHeroAttack;
                            heroHealthLevel -= bossAttack;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("You mana level is low. Use healing spell now! " +
                                "And you take damage!");
                            heroHealthLevel -= bossAttack;
                            Console.ReadKey();
                        }
                        break;

                    case CommandExplosoinHeroAttack:
                        Console.WriteLine($"You deal explosion attack.");

                        if (fireballCount > 0)
                        {
                            fireballCount = 0;
                            bossHealthLevel -= heroExplosionAttack;
                            heroHealthLevel -= bossAttack;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Use the fireball first.Dont forget!" +
                                " And you take damage!");
                            heroHealthLevel -= bossAttack;
                            Console.ReadKey();
                        }
                        break;

                    case CommandHealingSpell:
                        Console.WriteLine("You deal healing spell.");

                        if (healingSpellUseCount > 0)
                        {
                            healingSpellUseCount--;
                            heroHealthLevel = maxHeroHealthLevel;
                            heroManaLevel = maxHeroManaLevel;
                            heroHealthLevel -= bossAttack;
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("you're out of healing spells! And you take damage!");
                            heroHealthLevel -= bossAttack;
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.WriteLine("Ufff -_- oh, you're wrong. And you take damage!");
                        heroHealthLevel -= bossAttack;
                        Console.ReadKey();
                        break;
                }

                if (heroHealthLevel <= death && bossHealthLevel <= death)
                {
                    Console.WriteLine("You lose. Game Over :(");
                }
                else if (bossHealthLevel <= death)
                {
                    Console.WriteLine("You WIN!!! Congratulation winner winner chicken dinner :)");
                }
                else if (heroHealthLevel <= death)
                {
                    Console.WriteLine("So is it DRAW -_-");
                }
            }
        }
    }
}
