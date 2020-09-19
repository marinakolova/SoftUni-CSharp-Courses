namespace PetStore.Services
{
    using Models.Food;
    using System;

    public interface IFoodService
    {
        void BuyFromDistributor(string name, double weight, decimal price, double profit, DateTime expirationDate, int brandId, int categoryId);

        void BuyFromDistributor(AddingFoodServiceModel model);

        void SellFoodToUser(int foodId, int userId);

        bool Exists(int foodId);
    }
}
