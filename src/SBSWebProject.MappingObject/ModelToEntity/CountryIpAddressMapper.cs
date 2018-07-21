using CountryIpAddresses = SBSWebProject.Data.Entities.CountryIpAddresses;

namespace SBSWebProject.MappingObject.ModelToEntity
{
    public class CountryIpAddressMapper : IMappingObject<Web.Api.Models.CountryIpAddresses, CountryIpAddresses>
    {
        public CountryIpAddresses Map(Web.Api.Models.CountryIpAddresses objectToMap)
        {
            if (objectToMap == null) return null;
            var countryMapper = new CountryMapper();
            var outputModel = new CountryIpAddresses
            {
                Id = objectToMap.Id,
                CountryItem = countryMapper.Map(objectToMap.CountryItem),
                FromIp = objectToMap.FromIp,
                Owner = objectToMap.Owner,
                ToIp = objectToMap.ToIp
            };
            return outputModel;
        }
    }
}
