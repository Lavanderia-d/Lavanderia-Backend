using System;
using System.Collections.Generic;
using AutoMapper;
using Lavanderia.Api.Mappers;

namespace Lavanderia.UnitTests.Helpers
{
    public class Fakes
    {        
        public static Exception TestException = new Exception("Test Exception");
        public static int NewEntityId = 9999;

        public Fakes()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerProfile>();
                cfg.AddProfile<OrderProfile>();
                cfg.AddProfile<OrderItemProfile>();
            });

            this.Mapper = config.CreateMapper();
        }
        
        public List<T> Get<T>()
        {
            return DataFiles.Get<T>();
        }
        
        public IMapper Mapper { get; }
    }
}