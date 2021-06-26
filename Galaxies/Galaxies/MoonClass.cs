using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies
{
    class MoonClass
    {
        private String _moonName;
        private PlanetClass _planet;

        public MoonClass(string moonName)
        {
            _moonName = moonName;
        }

        public string MoonName { get => _moonName; set => _moonName = value; }

        public PlanetClass getPlanet()
        {
            return _planet;
        }
        public void setPlanet(PlanetClass planet)
        {
            _planet = planet;
        }
    }
}
