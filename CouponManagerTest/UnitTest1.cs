using CouponManagerProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CouponManagerTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public  void TestCase1_CheckTrue()
        {
            // Setup
            MyLogger log = new MyLogger();
            MyCouponProvider cp = new MyCouponProvider();
            Guid couponId = new Guid("00000000-0000-0000-0000-00000000BA12");
            Guid userId = new Guid("00000000-0000-0000-0000-00000000AC44");
            
            List<Func<Coupon, Guid, bool>> theList = new List<Func<Coupon, Guid, bool>>();
            for(int i = 0; i < 10; i++)
            {
                CouponGuid temp = new CouponGuid();
                theList.Add(temp.Evaluate);
            }
            CouponManager cm = new CouponManager(log, cp);

            // Apply
            try
            {
                Task<bool> task = cm.CanRedeemCoupon(couponId, userId, theList);
                task.Wait();
                bool result = task.Result;

                // Check
                Assert.AreEqual(result, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }




        }
        [TestMethod]
        public void TestCase2_CheckFalse()
        {
            // Setup
            MyLogger log = new MyLogger();
            MyCouponProvider cp = new MyCouponProvider();
            Guid couponId = new Guid("00000000-0000-0000-0000-00000000BA12");
            Guid userId = new Guid("00000000-0000-0000-0000-000000001111");

            List<Func<Coupon, Guid, bool>> theList = new List<Func<Coupon, Guid, bool>>();
            for (int i = 0; i < 10; i++)
            {
                CouponGuid temp = new CouponGuid();
                theList.Add(temp.Evaluate);
            }
            CouponManager cm = new CouponManager(log, cp);

            // Apply
            try
            {
                Task<bool> task = cm.CanRedeemCoupon(couponId, userId, theList);
                task.Wait();
                bool result = task.Result;

                // Check
                Assert.AreEqual(result, false);
            }
            catch(Exception e)
            {
                Assert.Fail(e.Message);
            }

        }
        [TestMethod]
        public void TestCase3_CheckEvaluatorIsNull()
        {
            // Setup
            MyLogger log = new MyLogger();
            MyCouponProvider cp = new MyCouponProvider();
            Guid couponId = new Guid("00000000-0000-0000-0000-00000000BA12");
            Guid userId = new Guid("00000000-0000-0000-0000-000000001111");

            List<Func<Coupon, Guid, bool>> theList = null;
            
            CouponManager cm = new CouponManager(log, cp);

            try
            {
                // Apply
                Task<bool> task = cm.CanRedeemCoupon(couponId, userId, theList);
                task.Wait();
                bool result = task.Result;

                // Check
                Assert.Fail("Exception must be thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("evaluators"));
            }

        }

        [TestMethod]
        public void TestCase4_CheckCouponIsNull()
        {
            // Setup
            MyLogger log = new MyLogger();
            MyCouponProvider cp = new MyCouponProvider();
            Guid couponId = new Guid("00000000-0000-0000-0000-000000002222");
            Guid userId = new Guid("00000000-0000-0000-0000-000000001111");

            List<Func<Coupon, Guid, bool>> theList = new List<Func<Coupon, Guid, bool>>();
            for (int i = 0; i < 10; i++)
            {
                CouponGuid temp = new CouponGuid();
                theList.Add(temp.Evaluate);
            }
            CouponManager cm = new CouponManager(log, cp);

            try
            {
                // Apply
                Task<bool> task = cm.CanRedeemCoupon(couponId, userId, theList);
                task.Wait();
                bool result = task.Result;

                // Check
                Assert.Fail("Exception must be thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("The given key was not present in the dictionary"));
            }

        }

        [TestMethod]
        public void TestCase5_CheckEvaluatorEmpty()
        {
            // Setup
            MyLogger log = new MyLogger();
            MyCouponProvider cp = new MyCouponProvider();
            Guid couponId = new Guid("00000000-0000-0000-0000-00000000BBBB");
            Guid userId = new Guid("00000000-0000-0000-0000-00000000ABAB");

            List<Func<Coupon, Guid, bool>> theList = new List<Func<Coupon, Guid, bool>>();
            
            CouponManager cm = new CouponManager(log, cp);

            try
            {
                // Apply
                Task<bool> task = cm.CanRedeemCoupon(couponId, userId, theList);
                task.Wait();
                bool result = task.Result;

                // Check
                Assert.AreEqual(result, true);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }

        }

        [TestMethod]
        public void TestCase6_CheckLoggerIsNull()
        {
            // Setup
            MyLogger log = null;
            MyCouponProvider cp = new MyCouponProvider();
            Guid couponId = new Guid("00000000-0000-0000-0000-00000000BBBB");
            Guid userId = new Guid("00000000-0000-0000-0000-00000000ABAB");

            List<Func<Coupon, Guid, bool>> theList = new List<Func<Coupon, Guid, bool>>();
            try
            {
                CouponManager cm = new CouponManager(log, cp);

            
                // Apply
                Task<bool> task = cm.CanRedeemCoupon(couponId, userId, theList);
                task.Wait();
                bool result = task.Result;

                // Check
                Assert.Fail("Exception must be thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("logger"));
            }

        }

        [TestMethod]
        public void TestCase7_CheckCouponProviderIsNull()
        {
            // Setup
            MyLogger log = new MyLogger();
            MyCouponProvider cp = null;
            Guid couponId = new Guid("00000000-0000-0000-0000-00000000BBBB");
            Guid userId = new Guid("00000000-0000-0000-0000-00000000ABAB");

            List<Func<Coupon, Guid, bool>> theList = new List<Func<Coupon, Guid, bool>>();
            try
            {
                CouponManager cm = new CouponManager(log, cp);


                // Apply
                Task<bool> task = cm.CanRedeemCoupon(couponId, userId, theList);
                task.Wait();
                bool result = task.Result;

                // Check
                Assert.Fail("Exception must be thrown");
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Contains("couponProvider"));
            }

        }
    }

    class MyLogger : ILogger
    {

    }
    class MyCouponProvider : ICouponProvider
    {
        public Task<Coupon> Retrieve(Guid couponId)
        {
            if (couponId.CompareTo(new Guid("00000000-0000-0000-0000-00000000AAAA")) >= 0)
            {
                return Task.Run(() => new Coupon());
            }

            return Task.Run(() => { Coupon c = null; return c; });
        }
    }
    class CouponGuid
    {
        public bool Evaluate(Coupon coupon, Guid userId)
        {

            if (userId.CompareTo(new Guid("00000000-0000-0000-0000-00000000AAAA")) >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
