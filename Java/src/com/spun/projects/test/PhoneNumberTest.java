package com.spun.projects.test;

import junit.framework.TestCase;

public class PhoneNumberTest extends TestCase {
	public void test1() {
		PhoneNumber ph = new PhoneNumber("+1 858 775 2869");
		assertEquals(ph.getStrippedNumber(), "+18587752869");
		assertEquals(ph.getValueAsNorthAmerican(), "(858)775-2869");
		assertEquals(ph.isNorthAmericanNumber(), true);
		assertEquals(ph.getValueAsInternational(), "+1.858.775.2869");
	}

	public void test2() {
		PhoneNumber ph = new PhoneNumber("1 858 775 3456");
		assertEquals(ph.getStrippedNumber(), "+18587753456");
		assertEquals(ph.getValueAsNorthAmerican(), "(858)775-3456");
		assertEquals(ph.isNorthAmericanNumber(), true);
		assertEquals(ph.getValueAsInternational(), "+1.858.775.3456");
	}

	public void test3() {
		PhoneNumber ph = new PhoneNumber("+1(858)775-2868");
		assertEquals(ph.getStrippedNumber(), "+18587752868");
		assertEquals(ph.getValueAsNorthAmerican(), "(858)775-2868");
		assertEquals(ph.isNorthAmericanNumber(), true);
		assertEquals(ph.getValueAsInternational(), "+1.858.775.2868");
	}

	public void test4() {
		PhoneNumber ph = new PhoneNumber("+1(858)775-2868x123");
		assertEquals(ph.getStrippedNumber(), "+18587752868x123");
		assertEquals(ph.getValueAsNorthAmerican(), "(858)775-2868x123");
		assertEquals(ph.isNorthAmericanNumber(), true);
		assertEquals(ph.getValueAsInternational(), "+1.858.775.2868x123");
	}

	public void test5() {
		PhoneNumber ph = new PhoneNumber("+598.123.4567x858\"");
		assertEquals(ph.getStrippedNumber(), "+18587752868");
		assertEquals(ph.getValueAsNorthAmerican(), "+5981234567x858");
		assertEquals(ph.isNorthAmericanNumber(), false);
		assertEquals(ph.getValueAsInternational(), "+598.123.456.7x858");
	}
}
