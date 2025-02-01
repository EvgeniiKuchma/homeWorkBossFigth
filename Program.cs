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

            Random random = new Random();

            int maxHeroHealthLevel = 100;
            int maxHeroMana = 50;
            int heroHealthLevel = maxHeroHealthLevel;
            int heroMana = maxHeroMana;
            int meleeHeroAttack = random.Next(minValue, maxValue);
            int fireballHeroAttack = 40;
            int fireballCostMana = 24;
            int fireballCount = 0;
            int heroExplosionAttack = 80;
            int healingSpellUseCount = 2;
            int bossHealthLevel = 200;
            int bossAttack = random.Next(minValue, maxValue);            

            Console.WriteLine("Welcome hero are you redy to figth?");
            Console.WriteLine("Let's battle began!");
            Console.ReadKey();

            while (heroHealthLevel > 0 && bossHealthLevel > 0)
            {
                Console.Clear();
                Console.WriteLine($"\nBoss health lvl = {bossHealthLevel}");
                Console.WriteLine($"Hero health lvl = {heroHealthLevel}");
                Console.WriteLine($"Hero mana lvl = {heroMana}");
                Console.WriteLine("\nMake your choice attack hero:");
                Console.WriteLine($"{CommandMeleeHeroAttack} - take melee attack.");
                Console.WriteLine($"{CommandFireballHeroAttack} - take a fireball.");
                Console.WriteLine($"{CommandExplosoinHeroAttack} - take explosion.");
                Console.WriteLine($"{CommandHealingSpell} - take healing.");

                switch (Console.ReadLine())
                {
                    case CommandMeleeHeroAttack:
                        Console.WriteLine("You choose melle attack;");
                        bossHealthLevel -= meleeHeroAttack;
                        heroHealthLevel -= bossAttack;
                        break;

                    case CommandFireballHeroAttack:
                        Console.WriteLine("You choose a fireball;");

                        if (heroMana > fireballCostMana)
                        {
                            fireballCount = 1;
                            heroMana -= fireballCostMana;
                            bossHealthLevel -= fireballHeroAttack;
                            heroHealthLevel -= bossAttack;
                        }
                        else
                        {
                            Console.WriteLine("You mana level is low. Use healing spell now! " +
                                "And you take damage!");
                            heroHealthLevel -= bossAttack;
                        }
                        break;

                    case CommandExplosoinHeroAttack:
                        Console.WriteLine($"You deal explosion attack.");

                        if (fireballCount > 0)
                        {
                            fireballCount = 0;
                            bossHealthLevel -= heroExplosionAttack;
                            heroHealthLevel -= bossAttack;
                        }
                        else
                        {
                            Console.WriteLine("Use the fireball first.Dont forget!" +
                                " And you take damage!");
                            heroHealthLevel -= bossAttack;
                        }
                        break;

                    case CommandHealingSpell:
                        Console.WriteLine("You deal healing spell.");

                        if (healingSpellUseCount > 0)
                        {
                            healingSpellUseCount--;
                            heroHealthLevel = maxHeroHealthLevel;
                            heroMana = maxHeroMana;
                            heroHealthLevel -= bossAttack;
                        }
                        else
                        {
                            Console.WriteLine("you're out of healing spells! And you take damage!");
                            heroHealthLevel -= bossAttack;
                        }
                        break;

                    default:
                        Console.WriteLine("Ufff -_- oh, you're wrong. And you take damage!");
                        heroHealthLevel -= bossAttack;
                        break;
                }
                Console.ReadKey();
            }

            if (bossHealthLevel <= 0 && heroHealthLevel <= 0)
            {
                Console.WriteLine("So is it DRAW -_-");
            }
            else if (bossHealthLevel <= 0)
            {
                Console.WriteLine("You WIN!!! Congratulation winner winner chicken dinner :)");
            }
            else if (heroHealthLevel <= 0)
            {
                Console.WriteLine("You lose. Game Over :(");
            }
        }
    }
}
