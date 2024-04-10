
using NeighbourhoodHelp.Model.Entities;

namespace NeighbourhoodHelp.Data.IRepository
{
    public interface IPriceRepository
    {
        Task<string> NegotiatePrice(PriceNegotiation request);
    }
}