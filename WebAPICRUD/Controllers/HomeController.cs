using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPICRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
/*
        URI                     Method              처리
 /api/products                  GET                모든 제품의 목록을 조회
 /api/products/id               GET                id를 기준으로 조회해서 해당 제품(1건)을 조회
 /api/products?category=        GET                카테고리를 기준으로 해당하는 제품(들)을 조회
 /api/products                  POST               새로운 제품을 생성.(New(DB에서는 Insert))
 /api/products/id               PUT                id에 해당하는 제품을 갱신(수정)(update where id)
 /api/products/id               DELETE             제품을 삭제(delete where id)
 */
