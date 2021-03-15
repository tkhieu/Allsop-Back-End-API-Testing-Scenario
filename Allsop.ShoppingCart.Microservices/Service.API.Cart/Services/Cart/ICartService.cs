using System;
using App.Support.Common.Models;

namespace Service.API.Cart.Services.Cart
{
    public interface ICartService
    {
        App.Support.Common.Models.Cart GenerateAnEmptyCart(Guid accountId);
    }
}