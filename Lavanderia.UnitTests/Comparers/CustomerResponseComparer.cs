using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Responses;

namespace Lavanderia.UnitTests.Comparers
{
    public class CustomerResponseComparer : ResponseComparer
    {
        public override bool Equals(Response a, Response b)
        {
            var aData = a.Data as CustomerResponse;
            var bData = b.Data as CustomerResponse;

            if (aData.Id != bData.Id)                                       return false;
            if (aData.Name != bData.Name)                                   return false;

            if (aData.Phone.DDD != bData.Phone.DDD)                         return false;
            if (aData.Phone.Number != bData.Phone.Number)                   return false;
            
            if (aData.Address.Street != bData.Address.Street)               return false;
            if (aData.Address.Number != bData.Address.Number)               return false;
            if (aData.Address.Complement != bData.Address.Complement)       return false;
            if (aData.Address.Municipality != bData.Address.Municipality)   return false;
            if (aData.Address.State != bData.Address.State)                 return false;
            if (aData.Address.PostalCode != bData.Address.PostalCode)       return false;
            
            return base.Equals(a, b);
        }
    }
}