using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeObserver.Extensions;

namespace TimeObserver.Tests {
    public class ExtensionsTests {
        [Fact]
        private void SeparateByUppercaseValid() {
            string input = "HelloWorldThere";
            string expected = "Hello World There";
            string result = input.SeparateByUppercase();
            Assert.Equal(expected, result);
        }
    }
}
