using System;
using Xunit;

namespace Progstr.Tests
{
	public class MyClass
	{
		public MyClass()
		{
		}
		
		[Fact]
		public void DoSomething()
		{
			3.ShouldBe(3);
		}
	}
}

