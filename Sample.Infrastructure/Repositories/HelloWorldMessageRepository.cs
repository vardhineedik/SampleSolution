using Sample.Domain.Abstract;
using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Infrastructure.Repositories
{
    public class HelloWorldMessageRepository : IHelloWorldMessageRepository
    {
        public async Task<HelloWorldMessage> GetHelloWorldMessage()
        {
            HelloWorldMessage message = new HelloWorldMessage { 
             Message= "hello world"
            };
            return message;
        }
    }
}
