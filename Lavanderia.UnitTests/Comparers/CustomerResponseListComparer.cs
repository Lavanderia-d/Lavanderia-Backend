using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Responses;

namespace Lavanderia.UnitTests.Comparers
{
    public class CustomerResponseListComparer : ResponseComparer
    {
        public override bool Equals(Response a, Response b)
        {
            var aData = a.Data as CustomerResponse[];
            var bData = b.Data as CustomerResponse[];

            if (aData.Length != bData.Length)
                return false;

            for (var i = 0; i < aData.Length; i++)
            {
                if (aData[i].Id != bData[i].Id)                                       return false;
                if (aData[i].Name != bData[i].Name)                                   return false;

                if (aData[i].Phone.DDD != bData[i].Phone.DDD)                         return false;
                if (aData[i].Phone.Number != bData[i].Phone.Number)                   return false;
                
                if (aData[i].Address.Street != bData[i].Address.Street)               return false;
                if (aData[i].Address.Number != bData[i].Address.Number)               return false;
                if (aData[i].Address.Complement != bData[i].Address.Complement)       return false;
                if (aData[i].Address.Municipality != bData[i].Address.Municipality)   return false;
                if (aData[i].Address.State != bData[i].Address.State)                 return false;
                if (aData[i].Address.PostalCode != bData[i].Address.PostalCode)       return false;
            }
            
            return base.Equals(a, b);
        }
    }
}