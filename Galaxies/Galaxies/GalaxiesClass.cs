using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxies
{
    class GalaxiesClass
    {
        private String _name;
        private String _type;
        private double _age;
        private List<StarClass> _stars;

        public GalaxiesClass(String name, String type, double age)
        {
            Name = name;
            Type = type;
            Age = age;
           _stars = new List<StarClass>();
        }

        public string Name { get => _name; set => _name = value; }
        public string Type { get => _type; set => _type = value; }
        public double Age { get => _age; set => _age = value; }

        public Boolean addStar(StarClass star)
        {
            if (_stars.Contains(star))
                return false;
            _stars.Add(star);
            star.setGalaxy(this);
            return true;

        }

        public List<StarClass> getStars()
        {
            return _stars;
        }
    }
}
