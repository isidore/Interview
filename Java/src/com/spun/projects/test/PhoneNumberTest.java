package com.spun.projects.test;

import junit.framework.TestCase;

public class PhoneNumberTest extends TestCase
{
  private UseCase useCases[] = {new UseCase("+1(858)775-2868", "+18587752868", "(858)775-2868", "+1.858.775.2868"),
      new UseCase("+1(858)775-2868x123", "+18587752868x123", "(858)775-2868x123", "+1.858.775.2868x123"),
      new UseCase("+598.123.4567x858", "+5981234567x858", null, "+598.123.456.7x858"),
      new UseCase("+27 1234 5678 ext 4", "+2712345678x4", null, "+27.123.456.78x4"),
      new UseCase("858-775-2868", "+18587752868", "(858)775-2868", "+1.858.775.2868"),
      new UseCase("(800)351-7765", "+18003517765", "(800)351-7765", "+1.800.351.7765"),
      new UseCase("858-755", "+1858755", null, null),
      new UseCase("1858.775.2868", "+18587752868", "(858)775-2868", "+1.858.775.2868"),
      new UseCase("27 1234 567 ext 4", "+1271234567x4", null, null),
      new UseCase("+5+98.123.4567Xxx8x58", "+5981234567x858", null, "+598.123.456.7x858"),};
  /***********************************************************************/
  public void test()
  {
    for (int i = 0; i < useCases.length; i++)
    {
      System.out.println("index=" + i);
      assertValid(useCases[i]);
    }
  }
  /***********************************************************************/
  public void assertValid(UseCase useCase)
  {
    PhoneNumber ph = new PhoneNumber(useCase.original);
    assertEquals("[" + useCase.strippedNumber + "]Stripped Number", useCase.strippedNumber, ph.getStrippedNumber());
    if (useCase.usa != null)
    {
      assertEquals("[" + useCase.original + "]USA format", useCase.usa, ph.getValueAsNorthAmerican());
    }
    else
    {
      assertFalse("[" + useCase.original + "]Isn't USA Number", ph.isNorthAmericanNumber());
    }
    if (useCase.international != null)
    {
      assertEquals("[" + useCase.original + " " + ph.getValueAsInternational() + "]International format",
          useCase.international, ph.getValueAsInternational());
    }
    else
    {
      assertFalse("[" + useCase.original + "] Invalid #", ph.isValid());
    }
  }
  /************************************************************************/
  public static void main(String[] args)
  {
    junit.textui.TestRunner.run(PhoneNumberTest.class);
  }
  /***********************************************************************/
}

class UseCase
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
/***********************************************************************/
/***********************************************************************/
