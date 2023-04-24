using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCCallWebAPI_ANGGUN.Models.DB;
using Newtonsoft.Json;

namespace MVCCallWebAPI_ANGGUN.Controllers
{
    public class tr_bpkbMVCCallWebAPIController : Controller
    {
        private readonly DB_Demo_APIContext _context;
        HttpClient client = new HttpClient();
        string url = "https://localhost:7034/api/tr_bpkbMVCWebAPI/";

        public tr_bpkbMVCCallWebAPIController(DB_Demo_APIContext context)
        {
            _context = context;
        }

        // GET: tr_bpkbMVCCallWebAPI
        public async Task<IActionResult> Index()
        {
            // Original code:
            //return View(await _context.tr_bpkb.ToListAsync());

            // Consume API
            return View(JsonConvert.DeserializeObject<List<tr_bpkb>>(await client.GetStringAsync(url)).ToList());
        }

        // GET: tr_bpkbMVCCallWebAPI/Details/5

        // GET: tr_bpkbMVCCallWebAPI/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tr_bpkbMVCCallWebAPI/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("agreement_number,bpkb_no,branch_id,bpkb_date,faktur_no,faktur_date,location_id,police_no,bpkb_date_in")] tr_bpkb trbpkb)
        {
            if (ModelState.IsValid)
            {
                // Consume API
                await client.PostAsJsonAsync<tr_bpkb>(url, trbpkb);
                return RedirectToAction(nameof(Index));
            }
            return View(trbpkb);
        }





        private bool trbpkbExists(string agreement_number)
        {
            return (_context.tr_bpkb?.Any(e => e.agreement_number == agreement_number)).GetValueOrDefault();
        }
    }
}
