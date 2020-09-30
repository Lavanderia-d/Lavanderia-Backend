using System.Collections.Generic;
using Lavanderia.Domain.Dto.Responses;

namespace Lavanderia.UnitTests.Comparers
{
    public class ResponseComparer : IEqualityComparer<Response>
    {
        public virtual bool Equals(Response a, Response b)
        {
            return a.Code == b.Code && a.Message == b.Message;
        }
        
        public virtual int GetHashCode(Response response)
        {
            if (response.Data != null)
                return response.Data.GetHashCode();
            else if (response.Message != null)
                return response.Message.GetHashCode();
            else
                return response.Code.GetHashCode();
        }
    }
}