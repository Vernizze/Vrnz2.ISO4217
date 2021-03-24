using System;
using System.Threading;
using Vrnz2.ISO4217.UseCases.ReadingIso4217Source;
using Xunit;

namespace Vrnz2.ISO4217.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var handler = UpdateIso4217DataSource.Handler.Instance;

            handler.Handle(20 * 1000);

            Thread.Sleep(Timeout.Infinite);
        }
    }
}
