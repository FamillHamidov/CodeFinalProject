using Travel.Services.Basket.Dtos;
using Travel.Shared.Dtos;

namespace Travel.Services.Basket.Services
{
    public interface IBasketService
    {
        Task<Response<BasketDto>> GetBasket(string userId);
        Task<Response<bool>> SaveOrUpdate(BasketDto basket);
        Task<Response<bool>> Delete(string userId);
    }

}
