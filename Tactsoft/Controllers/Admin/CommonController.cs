using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Microsoft.AspNetCore.Mvc;

namespace Tactsoft.Controllers.Admin
{
    public class CommonController : Controller
    {
        private readonly AppDbContext _context;

        public CommonController(AppDbContext context)
        {
            this._context = context;
        }

        public JsonResult GetStatesByCountryId(int countryId)
        {
            List<State> statesList = new List<State>();
            statesList = (from state in _context.States
                          where state.CountryID == countryId
                          select state).ToList();


            return Json(statesList);

        }

        public JsonResult GetCitiesByStateId(int stateId)
        {
            List<City> citiesList = new List<City>();

            citiesList = (from city in _context.Cities
                          where city.StateId == stateId
                          select city).ToList();

            return Json(citiesList);
        }


    }
}
