using asmpro131_Shared.ViewModels;

namespace asmpro131.IServices
{
    public interface IFavoriteProductsService
    {
        public Task<bool> Like(Guid accountId, Guid productId);
        public Task<List<FavoriteProductsView>> GetFavoriteProductsByAccount(Guid accountId);
        public Task<List<FavoriteProductsView>> GetFavoriteProduct(Guid accountId, Guid productId);
    }
}
