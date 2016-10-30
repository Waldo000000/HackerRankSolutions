using EasyAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.Tests
{
    [TestClass]
    public class LeftRotationTest
    {
        [TestMethod]
        public void LeftRotate_LessThanArrayLength_RotatesElements()
        {
            LeftRotation
                .LeftRotate(new[] { 1, 2, 3, 4, 5 }, 4)
                .ShouldMatch(5, 1, 2, 3, 4);

            LeftRotation
                .LeftRotate(new[] { 1, 2, 3, 4, 5 }, 2)
                .ShouldMatch(3, 4, 5, 1, 2);
        }

        [TestMethod]
        public void LeftRotate_ArrayLength_NoChange()
        {
            LeftRotation
                .LeftRotate(new[] { 1, 2, 3, 4, 5 }, 5)
                .ShouldMatch(1, 2, 3, 4, 5);
        }

        [TestMethod]
        public void LeftRotate_MoreThanArrayLength_RotatesElements()
        {
            LeftRotation
                .LeftRotate(new[] { 1, 2, 3, 4, 5 }, 6)
                .ShouldMatch(2, 3, 4, 5, 1);
        }
    }
}
