using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Responses;

namespace Lavanderia.UnitTests.Comparers
{
    public class OrderItemResponseComparer : ResponseComparer
    {
        public override bool Equals(Response a, Response b)
        {
            var aData = a.Data as OrderItemResponse;
            var bData = b.Data as OrderItemResponse;

            if (aData.Id != bData.Id) return false;
            if (aData.Type != bData.Type) return false;
            if (aData.Color != bData.Color) return false;
            if (aData.Value != bData.Value) return false;
            return base.Equals(a, b);
        }
    }
}