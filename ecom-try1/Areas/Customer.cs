using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ecom_try1.Data;
using ecom_try1.Models;

namespace ecom_try1.Areas
{
    [Area("Customer.cs")]
    public class Customer : Controller
    {
        private readonly ApplicationDbContext _context;

        public Customer(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer.cs/Customer
        public async Task<IActionResult> Index()
        {
              return _context.ApplicationUser != null ? 
                          View(await _context.ApplicationUser.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ApplicationUser'  is null.");
        }

        // GET: Customer.cs/Customer/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // GET: Customer.cs/Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer.cs/Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(applicationUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: Customer.cs/Customer/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser.FindAsync(id);
            if (applicationUser == null)
            {
                return NotFound();
            }
            return View(applicationUser);
        }

        // POST: Customer.cs/Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] ApplicationUser applicationUser)
        {
            if (id != applicationUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(applicationUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplicationUserExists(applicationUser.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(applicationUser);
        }

        // GET: Customer.cs/Customer/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var applicationUser = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            return View(applicationUser);
        }

        // POST: Customer.cs/Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.ApplicationUser == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ApplicationUser'  is null.");
            }
            var applicationUser = await _context.ApplicationUser.FindAsync(id);
            if (applicationUser != null)
            {
                _context.ApplicationUser.Remove(applicationUser);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplicationUserExists(string id)
        {
          return (_context.ApplicationUser?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
