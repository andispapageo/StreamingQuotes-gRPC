using Application.Contracts.DTOs;
using Domain.Core.Entities;

namespace Application.Mappings
{
    public static class CryptoAssetMappings
    {
        public static CryptoAssetDto ToDto(this CryptoAsset entity)
        {
            return new CryptoAssetDto
            {
                Id = entity.Id.Value,
                Symbol = entity.Ticker.Value,
                Name = entity.Name,
                CurrentPrice = entity.CurrentPrice.Amount ?? 0,
                MarketCap = entity.MarketCap.Amount ?? 0,
                Volume24H = entity.Volume24H.Amount ?? 0,
                PriceChange24H = entity.PriceChange24H.Value ?? 0,
                High24H = entity.Range24H.High.Amount ?? 0,
                Low24H = entity.Range24H.Low.Amount ?? 0,
                MarketCapRank = entity.MarketCapRankValue,
                ImageUrl = entity.ImageUrl,
                Trend = entity.GetTrend().ToString(),
                LastUpdatedAt = entity.LastUpdatedAt
            };
        }

        public static IEnumerable<CryptoAssetDto> ToDtos(this IEnumerable<CryptoAsset> entities)
            => entities.Select(ToDto);

        public static PriceUpdateDto ToPriceUpdateDto(this CryptoAsset entity)
        {
            return new PriceUpdateDto
            {
                SymbolId = entity.Id.Value,
                Ticker = entity.Ticker.Value.ToUpperInvariant(),
                Price = entity.CurrentPrice.Amount,
                PriceChange24H = entity.PriceChange24H.Value,
                High24H = entity.Range24H.High.Amount,
                Low24H = entity.Range24H.Low.Amount,
                Timestamp = entity.LastUpdatedAt
            };
        }
    }
}