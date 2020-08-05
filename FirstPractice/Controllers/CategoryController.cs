using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FirstPractice.Models;
using System.Data.Entity;

namespace FirstPractice.Controllers
{
    public class CategoryController : Controller
    {
        //private ICategoryRepository categoryRepository = null;
        //public CategoryController()
        //{
        //    this.categoryRepository = new CategoryRepository();
        //}

        //private NorthwindEntities db = new NorthwindEntities();

        Repository<Categories> categoryRepository = new Repository<Categories>(new NorthwindEntities());
        // GET: Category
        public ActionResult Index()
        {
            //ADO.NET
            //跟Modle要資料
            //List<Category> categories = CategoryDataContext.LoadCategories();

            //將資料傳給View
            //return View(categories);

            //EF
            //return View(db.Categories.ToList());

            //Repository
            return View(categoryRepository.GetAll());
        }

        //新增分類資料的介面
        public ActionResult Add()
        {
            return View();
        }

        //接收表單傳過來的資料
        [HttpPost]
        public ActionResult Insert()
        {
            //接收表單傳過來的資料
           // Category _category = new Category();           
            //_category.CategoryName = Request.Form["CategoryName"];
            //_category.Description = Request.Form["Description"];

            //ADO.NET
            //將資料傳給Model
            //CategoryDataContext.InsertCategory(_category);
            //轉到Index的Action

          
            Categories _category = new Categories();
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];
            //EF
            //db.Categories.Add(_category);
            //db.SaveChanges();

            //Repository
            categoryRepository.Create(_category);

            return RedirectToAction("Index");

        }

        //根據id刪除分類資料
        //ActionResult的參數名稱要配合RouteConfig.cs中網址設定的名稱
        public ActionResult Delete(int id=0)
        {
            //ADO.NET
            //CategoryDataContext.DeleteCategory(id);

            //EF
            //Categories _category = db.Categories.Find(id);
            //db.Categories.Remove(_category);
            //db.SaveChanges();

            //Repository
            Categories _category = categoryRepository.GetById(id);
            categoryRepository.Delete(_category);



            return RedirectToAction("Index");
        }

        //根據id讀取分類資料
        //ActionResult的參數名稱要配合RouteConfig.cs中網址設定的名稱
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            //接收Client端傳過來的資料，透過id的參數來接收
            //將id的資料傳給Model，跟Model要分類資料
            //ADO.NET
           // Category _category = CategoryDataContext.LoadCategoryByID(id);
         
            //EF
            //Categories _category = db.Categories.Find(id);

            //Repository
            Categories _category = categoryRepository.GetById(id);
            
            //再將Model傳回來的資料傳給View
            return View(_category);
        }

        //修改分類資料
        [HttpPost]
        public ActionResult Edit()
        {
            //接收表單傳過來的資料
            //Category _category = new Category();
            //_category.CategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            //_category.CategoryName = Request.Form["CategoryName"];
            //_category.Description = Request.Form["Description"];

            //將資料傳給Model
            //ADO.NET
            //CategoryDataContext.EditCategory(_category);


            Categories _category = new Categories();
            _category.CategoryID = Convert.ToInt32(Request.Form["CategoryID"]);
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];

            //EF

            //db.Entry(_category).State = EntityState.Modified;
            //db.SaveChanges();

            //Repository
            categoryRepository.Update(_category);

            //轉到Index的Action
            return RedirectToAction("Index");
        }

    }
}