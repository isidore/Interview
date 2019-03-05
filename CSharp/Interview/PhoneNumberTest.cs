using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interview

{
    [TestClass]
    public partial class PhoneNumberTests
    {
        [TestMethod]
        public void Test1()
        {
            PhoneNumber ph = new PhoneNumber("+1(858)775-2868");

            ph.GetOriginalText().Should().Be("+1(858)775-2868");
            ph.GetStrippedNumber().Should().Be("+18587752868");
            ph.GetValueAsNorthAmerican().Should().Be("(858)775-2868");
            ph.GetValueAsInternational().Should().Be("+1.858.775.2868");
        }

        [TestMethod]
        public void Test2()
        {
            PhoneNumber ph = new PhoneNumber("+1(858)775-2868x123");

            ph.GetOriginalText().Should().Be("+1(858)775-2868x123");
            ph.GetStrippedNumber().Should().Be("+18587752868x123");
            ph.GetValueAsNorthAmerican().Should().Be("(858)775-2868x123");
            ph.GetValueAsInternational().Should().Be("+1(858)775-2868x123");
        }

        [TestMethod]
        public void Test3()
        {
            PhoneNumber ph = new PhoneNumber("+598.123.4567x858");

            ph.GetOriginalText().Should().Be("+598.123.4567x858");
            ph.GetStrippedNumber().Should().Be("+5981234567x858");
            ph.GetValueAsNorthAmerican().Should().Be(null);
            ph.GetValueAsInternational().Should().Be("+598.123.456.7x858");
        }

        [TestMethod]
        public void Test4()
        {
            PhoneNumber ph = new PhoneNumber("+27 1234 5678 ext 4");

            ph.GetOriginalText().Should().Be("+27 1234 5678 ext 4");
            ph.GetStrippedNumber().Should().Be("+2712345678x4");
            ph.GetValueAsNorthAmerican().Should().Be(null);
            ph.GetValueAsInternational().Should().Be("+27 1234 5678 ext 4");
        }

        [TestMethod]
        public void Test5()
        {
            PhoneNumber ph = new PhoneNumber("858-775-2868");

            ph.GetOriginalText().Should().Be("858-775-2868");
            ph.GetStrippedNumber().Should().Be("+18587752868");
            ph.GetValueAsNorthAmerican().Should().Be("(858)775-2868");
            ph.GetValueAsInternational().Should().Be("+1.858.775.2868");
        }
    }
}
