using System;
using System.Collections.Generic;
using System.Linq;

namespace Galaxies
{
    class Program
    {

        static void Main(string[] args)
        {

            List<GalaxiesClass> galaxies = new List<GalaxiesClass>();
            List<StarClass> stars = new List<StarClass>();
            List<PlanetClass> planets = new List<PlanetClass>();
            List<MoonClass> moons = new List<MoonClass>();
            char unitOfYears = ' ';
            while (true)
            {
                string line = Console.ReadLine();
                if (line.Equals("exit"))
                    break;
                String[] commands = line.Split(" ");

                if (commands[0].Equals("add"))
                {
                    if (commands[1].Equals("galaxy"))
                    {
                        string name = line.Split('[', ']')[1];
                        string[] commandsAfterBrackets = line.Substring(line.IndexOf("]") + 1).Split(" ");
                        string type = commandsAfterBrackets[1];
                        unitOfYears = commandsAfterBrackets[2].Last();
                        string age = commandsAfterBrackets[2]
                            .Substring(0, commandsAfterBrackets[2]
                                            .IndexOf(unitOfYears));
                        GalaxiesClass galaxy = new GalaxiesClass(name, type, Convert.ToDouble(age));
                        galaxies.Add(galaxy);

                    }else if (commands[1].Equals("star"))
                    {
                        string GalaxyName = line.Split('[', ']')[1];
                        string StarName = line.Split('[', ']')[3];
                        string[] commandsAfterBrackets = line.Substring(line.IndexOf("]") + 1).Split(" ");
                        double mass = Convert.ToDouble(commandsAfterBrackets[2]);
                        double size = Convert.ToDouble(commandsAfterBrackets[3]);
                        double temperature = Convert.ToDouble(commandsAfterBrackets[4]);
                        double brightness = Convert.ToDouble(commandsAfterBrackets[5]);
                        StarClass star = new StarClass(StarName, mass, (size / 2), temperature, brightness);
                        foreach (var galaxy in galaxies)
                        {
                            if (galaxy.Name == GalaxyName)
                            {
                                
                                galaxy.addStar(star);
                                stars.Add(star);
                            }
                        }

                    }else if (commands[1].Equals("planet"))
                    {
                        string StarName = line.Split('[', ']')[1];
                        string PlanetName = line.Split('[', ']')[3];
                        string[] commandsAfterBrackets = line.Substring(line.IndexOf("]") + 1).Split(" ");
                        string type = commandsAfterBrackets[2];
                        Boolean yesOrNo = commandsAfterBrackets[3] == "yes" ? true : false;
                        PlanetClass planet = new PlanetClass(PlanetName, type, yesOrNo);
                        foreach (var star in stars)
                        {
                            Console.WriteLine(star.Star_name);
                            if (star.Star_name == StarName)
                            {
                                star.addPlanet(planet);
                                planets.Add(planet);
                            }
                        }
                    }
                    else if (commands[1].Equals("moon"))
                    {
                        string PlanetName = line.Split('[', ']')[1];
                        string MoonName = line.Split('[', ']')[3];
                        MoonClass moon = new MoonClass(MoonName);
                        foreach (var planet in planets)
                        {
                            if (planet.PlanetName == PlanetName)
                            {
                                planet.addMoon(moon);
                                moons.Add(moon);
                            }
                        }
                    }
                }else if (commands[0].Equals("list"))
                {
                    if (commands[1].Equals("galaxies"))
                    {
                        Console.WriteLine("--- List of all researched galaxies ---");
                        foreach (var galaxy in galaxies)
                        {
                            Console.Write(galaxy.Name + ",");
                        }
                        Console.WriteLine("--- End of galaxies list ---");
                    }
                    if (commands[1].Equals("stars"))
                    {
                        Console.WriteLine("--- List of all researched stars ---");

                        foreach (var star in stars)
                        {
                            Console.Write(star.Star_name + ",");
                        }
                        Console.WriteLine("--- End of stars list ---");

                    }
                    if (commands[1].Equals("planets"))
                    {
                        Console.WriteLine("--- List of all researched planets ---");

                        foreach (var planet in planets)
                        {
                            Console.Write(planet.PlanetName + ",");
                        }
                        Console.WriteLine("--- End of planets list ---");

                    }

                    if (commands[1].Equals("moons"))
                    {
                        Console.WriteLine("--- List of all researched moons ---");

                        foreach (var moon in moons)
                        {
                            Console.Write(moon.MoonName + ",");
                        }

                        Console.WriteLine("--- End of planets moons ---");

                    }
                }
                else if (commands[0].Equals("print"))
                {
                    string GalaxyName = line.Split('[', ']')[1];
                    foreach(var galaxy in galaxies)
                    {
                        if (galaxy.Name.Equals(GalaxyName))
                        {
                            Console.WriteLine("---Data for " + GalaxyName + " galaxy-- -");
                            Console.WriteLine("Type: " + galaxy.Type);
                            Console.WriteLine("Age: " + galaxy.Age + unitOfYears);
                            Console.WriteLine("Stars");
                            foreach (var star in galaxy.getStars()) {
                                Console.WriteLine("Name: " + star.Star_name);
                                Console.WriteLine("Class: " + star.setClas() + "(" +
                                    star.Mass + "," + star.Size + "," + star.Temperature + "," + star.Brightness + ")");
                                Console.WriteLine("Planets");
                                foreach (var planet in star.getPlanets())
                                {
                                    Console.WriteLine("Name:" + planet.PlanetName);
                                    Console.WriteLine("Type:" + planet.Type);
                                    Console.WriteLine("Support life:" + planet.IsSupportLife);
                                    Console.WriteLine("Moons");
                                    foreach(var moon in planet.getMoons())
                                    {
                                        Console.WriteLine("Moons:");
                                        Console.WriteLine("Name:" + moon.MoonName);
                                    }
                                }


                            }
                        }
                    }
                }


            }
        }
    }
}
