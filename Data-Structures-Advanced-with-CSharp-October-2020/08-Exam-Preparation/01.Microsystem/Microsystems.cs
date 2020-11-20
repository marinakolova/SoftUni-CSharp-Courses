namespace _01.Microsystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Microsystems : IMicrosystem
    {
        Dictionary<int, Computer> byNumber = new Dictionary<int, Computer>();
        Dictionary<Brand, HashSet<Computer>> byBrand = new Dictionary<Brand, HashSet<Computer>>();
        Dictionary<double, HashSet<Computer>> byScreenSize = new Dictionary<double, HashSet<Computer>>();
        Dictionary<string, HashSet<Computer>> byColor = new Dictionary<string, HashSet<Computer>>();
        
        public void CreateComputer(Computer computer)
        {
            if (byNumber.ContainsKey(computer.Number))
            {
                throw new ArgumentException();
            }

            byNumber[computer.Number] = computer;
            
            if (!byBrand.ContainsKey(computer.Brand))
            {
                byBrand[computer.Brand] = new HashSet<Computer>();
            }
            byBrand[computer.Brand].Add(computer);

            if (!byScreenSize.ContainsKey(computer.ScreenSize))
            {
                byScreenSize[computer.ScreenSize] = new HashSet<Computer>();
            }
            byScreenSize[computer.ScreenSize].Add(computer);

            if (!byColor.ContainsKey(computer.Color))
            {
                byColor[computer.Color] = new HashSet<Computer>();
            }
            byColor[computer.Color].Add(computer);
        }

        public bool Contains(int number)
        {
            return byNumber.ContainsKey(number);
        }

        public int Count()
        {
            return byNumber.Count;
        }

        public Computer GetComputer(int number)
        {
            if (!byNumber.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            return byNumber[number];
        }

        public void Remove(int number)
        {
            if (!byNumber.ContainsKey(number))
            {
                throw new ArgumentException();
            }

            var computerToRemove = byNumber[number];

            byNumber.Remove(number);
            
            byBrand[computerToRemove.Brand].Remove(computerToRemove);
            if (byBrand.Count == 0)
            {
                byBrand.Remove(computerToRemove.Brand);
            }

            byScreenSize[computerToRemove.ScreenSize].Remove(computerToRemove);
            if (byScreenSize.Count == 0)
            {
                byScreenSize.Remove(computerToRemove.ScreenSize);
            }

            byColor[computerToRemove.Color].Remove(computerToRemove);
            if (byColor.Count == 0)
            {
                byColor.Remove(computerToRemove.Color);
            }            
        }

        public void RemoveWithBrand(Brand brand)
        {
            if (!byBrand.ContainsKey(brand))
            {
                throw new ArgumentException();
            }

            var computersToRemove = byBrand[brand].Select(x => x.Number).ToList();
            foreach (var number in computersToRemove)
            {
                this.Remove(number);
            }
        }

        public void UpgradeRam(int ram, int number)
        {
            var computerToUpgrade = GetComputer(number);

            if (computerToUpgrade.RAM < ram)
            {
                computerToUpgrade.RAM = ram;
            }
        }

        public IEnumerable<Computer> GetAllFromBrand(Brand brand)
        {
            if (!byBrand.ContainsKey(brand))
            {
                return Enumerable.Empty<Computer>();
            }

            return byBrand[brand].OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
        {
            if (!byScreenSize.ContainsKey(screenSize))
            {
                return Enumerable.Empty<Computer>();
            }

            return byScreenSize[screenSize].OrderByDescending(x => x.Number);
        }

        public IEnumerable<Computer> GetAllWithColor(string color)
        {
            if (!byColor.ContainsKey(color))
            {
                return Enumerable.Empty<Computer>();
            }

            return byColor[color].OrderByDescending(x => x.Price);
        }

        public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
        {
            var inRange = byNumber.Values
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice)
                .OrderByDescending(x => x.Price)
                .ToList();

            if (inRange.Count == 0)
            {
                return Enumerable.Empty<Computer>();
            }

            return inRange;
        }
    }
}
