using DBFirstGumbi.Data;
using DBFirstGumbi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DBFirstGumbi.Controllers
{
    public class ClientController : Controller
    {
        private readonly TransDBContext _context;

        public ClientController(TransDBContext context)
        {
            _context = context;
        }

        public IActionResult Index(int pg =1, string sortExpression="")
        {
            ViewData["SortParamName"] = "name";
            ViewData["SortParamSurname"] = "surname_desc";

            ViewData["SortIconName"]= "";
            ViewData["SortIconSurname"] = "";

            SortOrder sortOrder;
            string sortProperty;
            switch (sortExpression.ToLower())
            {
                case "name_desc": 
                    sortOrder = SortOrder.Descending;
                    sortProperty = "name";
                    ViewData["SortParamName"] = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-up";
                    break;

                case "surname":
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "surname";
                    ViewData["SortParamSurname"] = "surname_desc";
                    ViewData["SortIconSurname"] = "fa fa-arrow-down";
                    break;

                case "surname_desc":
                    sortOrder = SortOrder.Descending;
                    sortProperty = "surname";
                    ViewData["SortParamSurname"] = "surname";
                    ViewData["SortIconSurname"] = "fa fa-arrow-up";
                    break;
                default:
                    sortOrder = SortOrder.Ascending;
                    sortProperty = "name";
                    ViewData["SortIconName"] = "fa fa-arrow-down";
                    ViewData["SortParamName"] = "name_desc";
                    break;
            }

            const int pageSize = 10;
            if (pg < 1)
                pg = 1;

            int rescCount = _context.Clients.Count();

            var pager = new Pager(rescCount, pg, pageSize);
            
            int rescSkip = (pg - 1) * pageSize;
          //List<Client> clients = _context.GetClients(sortProperty, sortOrder);
            List<Client> clients = _context.Clients.Skip(rescSkip).Take(pager.PageSize).ToList();


            this.ViewBag.Pager = pager;
            return View(clients);
        }

        public IActionResult Details(int Id)
        {
            Client client = _context.Clients.Where(p => p.ClientId == Id).FirstOrDefault();
            return View(client);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Client client = new Client();
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            //var clientId = _context.Clients.Max(p => p.ClientId);
            //if (clientId > 0)
            //{
            //    clientId += 1;

            //}

            //client.ClientId = clientId;
            _context.Attach(client);
            _context.Entry(client).State = EntityState.Added;
            _context.SaveChanges();
            return RedirectToAction("index");
        }


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Client client = _context.Clients.Where(p => p.ClientId == Id).FirstOrDefault();
            return View(client);
        }

        [HttpPost]
        public IActionResult Edit(Client client)
        {
            _context.Attach(client);
            _context.Entry(client).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Client client = _context.Clients.Where(p => p.ClientId == Id).FirstOrDefault();
            return View(client);
        }

        [HttpPost]
        public IActionResult Delete(Client client)
        {
            _context.Attach(client);
            _context.Entry(client).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
