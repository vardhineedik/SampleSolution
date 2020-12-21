using Sample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Domain.Abstract
{
    public interface IHelloWorldMessageRepository
    {
        Task<HelloWorldMessage> GetHelloWorldMessage();
    }
}
