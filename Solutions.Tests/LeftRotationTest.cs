using NUnit.Framework;

namespace Solutions.Tests
{
    [TestFixture]
    public class LeftRotationTest
    {
        [Test]
        public void LeftRotate_LessThanArrayLength_RotatesElements()
        {
            Assert.That(
                LeftRotation.LeftRotate(new[] {1, 2, 3, 4, 5}, 4),
                Is.EqualTo(new[] {5, 1, 2, 3, 4}));

            Assert.That(
                LeftRotation.LeftRotate(new[] {1, 2, 3, 4, 5}, 2),
                Is.EqualTo(new[] {3, 4, 5, 1, 2})
            );
        }

        [Test]
        public void LeftRotate_ArrayLength_NoChange()
        {
            Assert.That(
                LeftRotation.LeftRotate(new[] {1, 2, 3, 4, 5}, 5),
                Is.EqualTo(new[] {1, 2, 3, 4, 5})
            );
        }

        [Test]
        public void LeftRotate_MoreThanArrayLength_RotatesElements()
        {
            Assert.That(LeftRotation.LeftRotate(new[] {1, 2, 3, 4, 5}, 6),
                Is.EqualTo(new[] {2, 3, 4, 5, 1})
            );
        }
    }
}