﻿using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
	static void Main(string[] args)
	{
		var n = 100;
		var coupon = new CouponCollectorSimulator(n);
		coupon.Solve();
	}

}