using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreateDataByWCF.TestServiceReference;

namespace CreateDataByWCF.Controllers
{
    
    public class TestController : Controller
    {
        TestServiceReference.ITestService tc= new TestServiceClient();
        //
        // GET: /Test/

        public ActionResult Index(FormCollection fc)
        {
            return View();
        }

    }
}
