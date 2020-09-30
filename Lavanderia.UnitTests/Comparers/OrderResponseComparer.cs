using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Responses;

namespace Lavanderia.UnitTests.Comparers
{
    public class OrderResponseComparer : ResponseComparer
    {
        public override bool Equals(Response a, Response b)
        {
            var aData = a.Data as OrderResponse;
            var bData = b.Data as OrderResponse;

            if (aData.Id != bData.Id) return false;
            if (aData.Status != bData.Status) return false;
            return base.Equals(a, b);
        }
    }
}