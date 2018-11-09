using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SqlExample.Models;
using SqlExample.Services;
using SqlExample.Services.Factory;
using SqlExample.Services.SqlHelper;

namespace SqlExample.Controllers
{
    public class SampleController : Controller
    {
        private readonly OrderService _orderService = OrderFactory.GetService();

        public ActionResult Index()
        {
            var model = new List<NorthWindOrder>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchCondition sc)
        {
            var orderHelper = OrderFactory.GetSqlHelper(sc.HelperType);

            var model = _orderService.QueryByCondition(orderHelper, sc);
            ViewBag.SqlCmd = _orderService.SqlCmd;

            // 表單搜尋 keep 條件
            ViewBag.HelperName = orderHelper.GetName();
            ViewBag.Condition = sc;
            ViewBag.RecordCount = model.Count();
            return View(model);
        }
    }
}