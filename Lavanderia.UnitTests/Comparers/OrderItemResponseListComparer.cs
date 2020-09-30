using Lavanderia.Domain.Dto.Responses;
using Lavanderia.Domain.Responses;

namespace Lavanderia.UnitTests.Comparers
{
    public class OrderItemResponseListComparer : ResponseComparer
    {
        public override bool Equals(Response a, Response b)
        {
            var aData = a.Data as OrderItemResponse[];
            var bData = b.Data as OrderItemResponse[];

            if (aData.Length != bData.Length)
                return false;

            for (var i = 0; i < aData.Length; i++)
            {
                if (aData[i].Id != bData[i].Id) return false;
                if (aData[i].Type != bData[i].Type) return false;
                if (aData[i].Color != bData[i].Color) return false;
                if (aData[i].Value != bData[i].Value) return false;
            }
            
            return base.Equals(a, b);
        }
    }
}