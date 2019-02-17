﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SSTest2.DBContext;
using SSTest2.Model;

namespace SSTest2.Controllers
{
    [Route("/api/countries")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationContext context;

        public CountriesController(ApplicationContext context)
        {
            this.context = context;
        }

        [HttpGet("{countryId}")]
        public async Task<IActionResult> GetCountryById(int countryId)
        {
            var country = await context.Countries.FirstOrDefaultAsync(x => x.Id == countryId);
            if (country == null)
                return NotFound();

            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry(Country country)
        {
            var existingCountry = await context.Countries.FirstOrDefaultAsync(x =>
                x.OrganizationId == country.OrganizationId &&
                x.Name.Equals(country.Name, StringComparison.InvariantCultureIgnoreCase));
            
            if (existingCountry != null)
                return Conflict();

            context.Countries.Add(country);
            await context.SaveChangesAsync();

            return Accepted(country);
        }
    }
}