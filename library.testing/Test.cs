using System;
using Xunit;

namespace library.testing
{
  public class Test
  {
    [Fact]
    public void TestingAdd()
    {
      var start = new NonfigClient("http://beta.nonfig.com/api/v1/", "Atuv1kE7IoO1fO-7Bvr6", "ed077e9a-9329-4dd3-8789-ff4daea92f4d");
      var actual = start.Add(1, 2);
      Assert.Equal(3, actual);
    }

    [Fact]
    public void TestingSub()
    {
      var start = new NonfigClient("http://beta.nonfig.com/api/v1/", "Atuv1kE7IoO1fO-7Bvr6", "ed077e9a-9329-4dd3-8789-ff4daea92f4d");
      var actual = start.Sub(1, 2);
      Assert.Equal(-1, actual);
      var response = start.findById("b4b88629-a9f2-47f3-ba35-029c899a98b6");
      Assert.Equal(-1, actual);

    }
  }
}
