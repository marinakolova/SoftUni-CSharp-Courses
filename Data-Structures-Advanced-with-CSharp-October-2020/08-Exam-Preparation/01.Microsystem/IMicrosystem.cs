namespace _01.Microsystem
{
    using System.Collections.Generic;

    public interface IMicrosystem
    {
        void CreateComputer(Computer computer);

        bool Contains(int number);

        int Count();

        Computer GetComputer(int number);

        void Remove(int number);

        void RemoveWithBrand(Brand brand);

        void UpgradeRam(int ram, int number);

        IEnumerable<Computer> GetAllFromBrand(Brand brand);

        IEnumerable<Computer> GetAllWithScreenSize(double screenSize);

        IEnumerable<Computer> GetAllWithColor(string color);

        IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice);

    }
}
