using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Interview
{
	[TestClass]
	public class PhoneNumberTest
	{
	 private UseCase[] useCases = new[]{new UseCase("+1(858)775-2868", "+18587752868", "(858)775-2868", "+1.858.775.2868"),
      new UseCase("+1(858)775-2868x123", "+18587752868x123", "(858)775-2868x123", "+1.858.775.2868x123"),
      new UseCase("+598.123.4567x858", "+5981234567x858", null, "+598.123.456.7x858"),
      new UseCase("+27 1234 5678 ext 4", "+2712345678x4", null, "+27.123.456.78x4"),
      new UseCase("858-775-2868", "+18587752868", "(858)775-2868", "+1.858.775.2868"),
      new UseCase("(800)351-7765", "+18003517765", "(800)351-7765", "+1.800.351.7765"),
      new UseCase("858-755", "+1858755", null, null),
      new UseCase("1858.775.2868", "+18587752868", "(858)775-2868", "+1.858.775.2868"),
      new UseCase("27 1234 567 ext 4", "+1271234567x4", null, null),
      new UseCase("+5+98.123.4567Xxx8x58", "+5981234567x858", null, "+598.123.456.7x858"),};
  [TestMethod]
		public void test()
  {
    for (int i = 0; i < useCases.Length; i++)
    {
    	Console.WriteLine("index=" + i);
      assertValid(useCases[i]);
    }
  }
  public void assertValid(UseCase useCase)
  {
    PhoneNumber ph = new PhoneNumber(useCase.original);
		Assert.AreEqual(useCase.strippedNumber, ph.GetStrippedNumber(), "[" + useCase.strippedNumber + "]Stripped Number");
    if (useCase.usa != null)
    {
			Assert.AreEqual(useCase.usa, ph.GetValueAsNorthAmerican(), "[" + useCase.original + "]USA format");
    }
    else
    {
			Assert.AreEqual(ph.IsNorthAmericanNumber(), "[" + useCase.original + "]Isn't USA Number");
    }
    if (useCase.international != null)
    {
			Assert.AreEqual(useCase.international, ph.GetValueAsInternational(), "[" + useCase.original + " " + ph.GetValueAsInternational() + "]International format");
    }
    else
    {
			Assert.AreEqual(ph.IsValid(), "[" + useCase.original + "] Invalid #");
    }
  }
}

	public class UseCase
{
  public String original       = null;
  public String usa            = null;
  public String strippedNumber = null;
  public String international  = null;
  public UseCase(String original, String strippedNumber, String usa, String international)
  {
    this.original = original;
    this.strippedNumber = strippedNumber;
    this.usa = usa;
    this.international = international;
  }
}
}