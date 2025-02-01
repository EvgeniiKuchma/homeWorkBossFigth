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

            int maxHeroHealth = 100;
            int maxHeroMana = 50;
            int heroHealth = maxHeroHealth;
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

            while (heroHealth > 0 && bossHealthLevel > 0)
            {
                Console.Clear();
                Console.WriteLine($"\nBoss health lvl = {bossHealthLevel}");
                Console.WriteLine($"Hero health lvl = {heroHealth}");
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
                        heroHealth -= bossAttack;
                        break;

                    case CommandFireballHeroAttack:
                        Console.WriteLine("You choose a fireball;");

                        if (heroMana > fireballCostMana)
                        {
                            fireballCount = 1;
                            heroMana -= fireballCostMana;
                            bossHealthLevel -= fireballHeroAttack;
                            heroHealth -= bossAttack;
                        }
                        else
                        {
                            Console.WriteLine("You mana level is low. Use healing spell now! " +
                                "And you take damage!");
                            heroHealth -= bossAttack;
                        }
                        break;

                    case CommandExplosoinHeroAttack:
                        Console.WriteLine($"You deal explosion attack.");

                        if (fireballCount > 0)
                        {
                            fireballCount = 0;
                            bossHealthLevel -= heroExplosionAttack;
                            heroHealth -= bossAttack;
                        }
                        else
                        {
                            Console.WriteLine("Use the fireball first.Dont forget!" +
                                " And you take damage!");
                            heroHealth -= bossAttack;
                        }
                        break;

                    case CommandHealingSpell:
                        Console.WriteLine("You deal healing spell.");

                        if (healingSpellUseCount > 0)
                        {
                            healingSpellUseCount--;
                            heroHealth = maxHeroHealth;
                            heroMana = maxHeroMana;
                            heroHealth -= bossAttack;
                        }
                        else
                        {
                            Console.WriteLine("you're out of healing spells! And you take damage!");
                            heroHealth -= bossAttack;
                        }
                        break;

                    default:
                        Console.WriteLine("Ufff -_- oh, you're wrong. And you take damage!");
                        heroHealth -= bossAttack;
                        break;
                }
                Console.ReadKey();
            }

            if (bossHealthLevel <= 0 && heroHealth <= 0)
            {
                Console.WriteLine("So is it DRAW -_-");
            }
            else if (bossHealthLevel <= 0)
            {
                Console.WriteLine("You WIN!!! Congratulation winner winner chicken dinner :)");
            }
            else if (heroHealth <= 0)
            {
                Console.WriteLine("You lose. Game Over :(");
            }
        }
    }
}
