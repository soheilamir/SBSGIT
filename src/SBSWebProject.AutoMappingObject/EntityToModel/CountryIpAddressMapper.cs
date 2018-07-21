using CountryIpAddresses = SBSWebProject.Web.Api.Models.CountryIpAddresses;

namespace SBSWebProject.AutoMappingObject.EntityToModel
{
    public class CountryIpAddressMapper : IMappingObject<Data.Entities.CountryIpAddresses, CountryIpAddresses>
    {
        public CountryIpAddresses Map(Data.Entities.CountryIpAddresses objectToMap)
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
