using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Responses;

namespace Lavanderia.UnitTests.Comparers
{
    public class OrderResponseListComparer : ResponseComparer
    {
        public override bool Equals(Response a, Response b)
        {
            var aData = a.Data as OrderResponse[];
            var bData = b.Data as OrderResponse[];

            if (aData.Length != bData.Length)
                return false;

            for (var i = 0; i < aData.Length; i++)
            {
                if (aData[i].Id != bData[i].Id) return false;
                if (aData[i].Status != bData[i].Status) return false;
            }
            
            return base.Equals(a, b);
        }
    }
}