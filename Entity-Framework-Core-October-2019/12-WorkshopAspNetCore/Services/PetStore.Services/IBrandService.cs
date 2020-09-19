namespace PetStore.Services
{
    using Models.Brand;
    using System.Collections.Generic;

    public interface IBrandService
    {
        int Create(string name);

        IEnumerable<BrandListingServiceModel> SearchByName(string name);

        BrandWithToysServiceModel FindByIdWithToys(int id);
    }
}
