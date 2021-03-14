using API.Dtos;
using AutoMapper;

using Core.EntitiesDb;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ItemUrlResolver : IValueResolver<Item, ItemToReturnDto, string>
    {
        private readonly IConfiguration _configuration;
        public ItemUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;

        }
        public string Resolve(Item source, ItemToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _configuration["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}