using Merino.Controller;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using yuta_SampleWeb01.Models;
using yuta_SampleWeb01.Services;
using yuta_SampleWeb01.ViewModels;

namespace yuta_SampleWeb01.Controllers
{
    public class DataAListController : MerinoController
    {
        private readonly IDataAService _service;

        public DataAListController(IDataAService service)
        {
            _service = service;
        }

        // GET: DataAListController
        public async Task<ActionResult> Index(DataListViewModel model)
        {
            DataListViewModel viewModel = new DataListViewModel();
            List<TDataA> dataAList = null;

            if (model.SearchCondition == null)
            {
                //セッション取得
                // TODO オブジェクトのセッション管理 Jsonになる？
                // TODO 検索条件等ではセッションを使わず、クライアント側のsessionStorageを使うのがいい？
                // TODO 画面単位でセッションを管理する？？

                //データ取得
                dataAList = _service.getDataList();
            }
            else
            {
                //データ取得
                dataAList = _service.searchDataList(model.SearchCondition.CompanyNameCond);

                //セッション保存
                //base.AddSettion("key", userIdCond);
            }          

            //ViewModelにセット
            viewModel.DataA = dataAList;

            return View(viewModel);
        }

        // GET: DataAListController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DataAListController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DataAListController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DataAListController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DataAListController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DataAListController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DataAListController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
