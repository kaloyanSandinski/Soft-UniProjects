using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<BaseHero> raidGroup = new List<BaseHero>();
            while (raidGroup.Count<n)
            {
                var heroName = Console.ReadLine();
                var heroType = Console.ReadLine();
                BaseHero currHero = HeroCreator(heroName, heroType);
                if (currHero==null)
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    raidGroup.Add(HeroCreator(heroName, heroType));
                }
            }

            int bossPower = int.Parse(Console.ReadLine());
            int heroesPower = 0;
            foreach (var currHero in raidGroup)
            {
                Console.WriteLine(currHero.CastAbility());
                heroesPower += currHero.Power;
            }

            if (bossPower-heroesPower<=0)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");   
            }
        }

        private static BaseHero HeroCreator(string heroName, string heroType)
            {
                BaseHero hero = null;
                if (heroType == "Warrior")
                {
                    hero = new Warrior(heroName);
                }
                else if (heroType == "Rogue")
                {
                    hero = new Rogue(heroName);
                }
                else if (heroType == "Paladin")
                {
                    hero = new Paladin(heroName);
                }
                else if (heroType=="Druid")
                {
                    hero = new Druid(heroName);
                }

                return hero;
            }
        }
    }
