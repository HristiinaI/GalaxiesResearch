using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies
{
    class StarClass
    {
        private String _star_name;
        private double _mass;
        private double _size;
        private double _temperature;
        private double _brightness;
        private GalaxiesClass _galaxy;
        private List<PlanetClass> _planets;

        public StarClass(String starName, double mass, double size, double temperature, double brightness)
        {
            _star_name = starName;
            _mass = mass;
            _size = size;
            _temperature = temperature;
            _brightness = brightness;
            _planets = new List<PlanetClass>();
        }

        public string Star_name { get => _star_name; set => _star_name = value; }
        public double Mass { get => _mass; set => _mass = value; }
        public double Size { get => _size; set => _size = value; }
        public double  Temperature { get => _temperature; set => _temperature = value; }
        public double Brightness { get => _brightness; set => _brightness = value; }
        public char Class { get; set; }

        public GalaxiesClass getGalaxy()
        {
            return _galaxy;
        }

        public void setGalaxy(GalaxiesClass galaxy)
        {
            _galaxy = galaxy;
        }

        public Boolean addPlanet(PlanetClass planet)
        {
            if (_planets.Contains(planet))
                return false;
            _planets.Add(planet);
            planet.setStar(this);
            return true;
        }

        public List<PlanetClass> getPlanets()
        {
            return _planets;
        }

        public char setClas()
        {
            if((_temperature >= 30000)
                && (_brightness >= 3000)
                && (_mass >=  16)
                && (_size >= 6.6))
            {
                return 'O';
            }else
            if ((_temperature >= 10000 || _temperature < 30000)
                && (_brightness >= 25 || _brightness < 3000)
                && (_mass >= 2.1 || _mass < 16)
                && (_size >= 1.8 || _mass < 6.6))
            {
                return 'B';
            }else
                if ((_temperature >= 7500 || _temperature < 10000)
                && (_brightness >= 5 || _brightness < 25)
                && (_mass >= 1.4 || _mass < 2.1)
                && (_size >= 1.4 || _mass < 1.8))
            {
                return 'A';
            }else
                if ((_temperature >= 6000 || _temperature < 7500)
                && (_brightness >= 1.5 || _brightness < 5)
                && (_mass >= 1.04 || _mass < 1.4)
                && (_size >= 1.15 || _mass < 1.4))
            {
                return 'F';
            }else
                if ((_temperature >= 5200 || _temperature < 6000)
                && (_brightness >= 0.6 || _brightness < 1.5)
                && (_mass >= 0.8 || _mass < 1.04)
                && (_size >= 0.96 || _mass < 1.15))
            {
                return 'G';
            }else
                if ((_temperature >= 3700 || _temperature < 5200)
                && (_brightness > 0.08 || _brightness < 0.6)
                && (_mass >= 0.45 || _mass < 0.8)
                && (_size > 0.7 || _mass < 0.96))
            {
                return 'K';
            }else
                if ((_temperature >= 2400 || _temperature < 3700)
                && (_brightness <= 0.08)
                && (_mass >= 0.08 || _mass < 0.45)
                && (_size <= 0.7))
            {
                return 'M';
            }


            return 'X';
        }
    }
}
