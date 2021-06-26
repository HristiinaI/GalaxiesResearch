using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies
{
    class PlanetClass
    {
        private String _planetName;
        private String _type;
        private Boolean isSupportLife;
        private StarClass _star;
        private List<MoonClass> _moons;

        public PlanetClass(string planetName, string type, bool isSupportLife)
        {
            _planetName = planetName;
            _type = type;
            this.isSupportLife = isSupportLife;
            _moons = new List<MoonClass>();
        }

        public string PlanetName { get => _planetName; set => _planetName = value; }
        public string Type { get => _type; set => _type = value; }
        public bool IsSupportLife { get => isSupportLife; set => isSupportLife = value; }

        public StarClass getStar()
        {
            return _star;
        }

        public void setStar(StarClass star)
        {
            _star = star;
        }

        public Boolean addMoon(MoonClass moon)
        {
            if (_moons.Contains(moon))
                return false;
            _moons.Add(moon);
            moon.setPlanet(this);
            return true;
        }

        public List<MoonClass> getMoons()
        {
            return _moons;
        }
    }
}
