﻿using NUnit.Framework;
using Ninject;
using OpenQA.Selenium;

namespace Instagram
{

    public class Inj
    {
        public static StandardKernel kernel { get; set; }
        public static IWebDriver Driver { get; set; }
    }


  public class SetUp
  {    
      [OneTimeSetUp]
      public virtual void OneTimeSetUp()
      {
          Inj.kernel = new StandardKernel();
          Inj.kernel.Bind<IBrowsers>().To<Browsers>().InThreadScope();
      }

      [OneTimeTearDown]
      public virtual void OneTimeTearDown()
      {
          Inj.kernel.Get<IBrowsers>().DisposeCurrentBrowser();
          Inj.kernel.Dispose();
      }
  }
}
