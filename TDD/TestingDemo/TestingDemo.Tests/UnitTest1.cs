using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestingDemo.Tests
{
    [TestClass]
    public class NonQueryTests
    {
        [TestMethod]
        public void CreateBlog_saves_a_blog_via_context()
        {
            var mockSet = new Mock<DbSet<Blog>>();
        }
    }
}
