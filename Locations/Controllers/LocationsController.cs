using Locations.Data;
using Locations.Data.Interfaces;
using Locations.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using X.PagedList;

namespace Locations.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ILocationService locationService;
        private readonly IPostCodeService postCodeService;

        public LocationsController(ILocationService locationService, IPostCodeService postCodeService)
        {
            this.locationService = locationService;
            this.postCodeService = postCodeService;
        }

        public IActionResult Index(int id, string searchString, int? page)
        {
            var locationModels = locationService.GetAll((LocationType)id).Select(l => new LocationsDetailsViewModel
            {
                Id = l.Id,
                Name = l.Name,
                Address = l.Address,
                City = l.City,
                PostCode = l.PostCode,
                LocationType = LocationTypeEx.LocationTypes.First(lte => lte.LocationType == (int)l.Type)
            });

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                page = 1;
                locationModels = locationModels
                    .Where(l => l.Name.ToLower().Contains(searchString.ToLower())
                             || l.Address.ToLower().Contains(searchString.ToLower())
                             || l.City.ToLower().Contains(searchString.ToLower()));
            }

            int pageNumber = (page ?? 1);

            var model = new LocationsIndexViewModel
            {
                Locations = locationModels.ToPagedList(pageNumber, 9)
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var location = locationService.GetById(id);
            var model = new LocationsDetailsViewModel
            {
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                City = location.City,
                PostCode = location.PostCode,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Phone = location.Phone,
                LocationType = LocationTypeEx.LocationTypes.First(lte => lte.LocationType == (int)location.Type),
                LocationTypeId = (int)location.Type,
                OpeningTimes = location.OpeningHours.OrderBy(ot => ot.DayOfWeek).Select(oh => new OpeningTimeViewModel
                {
                    LocationId = location.Id,
                    DayOfWeek = oh.DayOfWeek,
                    Opening = oh.Opening,
                    Closing = oh.Closing
                }).ToList()
            };

            return View(model);
        }

        public IActionResult Create()
        {
            var locationTypes = LocationTypeEx.LocationTypes;
            var model = new LocationsDetailsViewModel
            {
                LocationTypes = new SelectList(locationTypes, nameof(LocationTypeEx.LocationType), nameof(LocationTypeEx.Description))
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Address,City,County,PostCode,Phone,LocationTypeId")] LocationsDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                double? longitude;
                double? latitude;
                postCodeService.GetLatitudeLongitude(model.PostCode, out latitude, out longitude);

                if (!latitude.HasValue || !longitude.HasValue)
                {
                    return View(model);
                }

                var location = new Location
                {
                    Name = model.Name,
                    Address = model.Address,
                    City = model.City,
                    County = model.County,
                    PostCode = model.PostCode,
                    Phone = model.Phone,
                    Type = (LocationType)model.LocationTypeId,
                    Latitude = latitude.Value,
                    Longitude = longitude.Value
                };
                locationService.Add(location);
                return RedirectToAction(nameof(Index), new { id = model.LocationTypeId });
            }

            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var locationTypes = LocationTypeEx.LocationTypes;
            var location = locationService.GetById(id);
            var openings = new List<SelectListItem>();
            var closings = new List<SelectListItem>();


            for (int i = 1; i < 24; i++)
            {
                if (i < 13)
                {
                    openings.Add(new SelectListItem(i.ToString(), i.ToString()));
                }
                else
                {
                    closings.Add(new SelectListItem(i.ToString(), i.ToString()));
                }
            }

            var model = new LocationsDetailsViewModel
            {
                LocationTypes = new SelectList(locationTypes, nameof(LocationTypeEx.LocationType), nameof(LocationTypeEx.Description)),
                Id = location.Id,
                Name = location.Name,
                Address = location.Address,
                City = location.City,
                County = location.County,
                PostCode = location.PostCode,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Phone = location.Phone,
                LocationTypeId = (int)location.Type,
                LocationType = LocationTypeEx.LocationTypes.First(lte => lte.LocationType == (int)location.Type),
                OpeningTimes = location.OpeningHours.OrderBy(oh => oh.DayOfWeek).Select(oh => new OpeningTimeViewModel
                {
                    LocationId = location.Id,
                    DayOfWeek = oh.DayOfWeek,
                    Opening = oh.Opening,
                    Closing = oh.Closing
                }).ToList(),
                Opening = openings,
                Closing = closings
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Address,City,County,PostCode,Phone,LocationTypeId,OpeningTimes,Latitude,Longitude")] LocationsDetailsViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var existingLocation = locationService.GetById(id);

                if (existingLocation.PostCode != model.PostCode)
                {
                    double? longitude;
                    double? latitude;
                    postCodeService.GetLatitudeLongitude(model.PostCode, out latitude, out longitude);

                    if (!latitude.HasValue || !longitude.HasValue)
                    {
                        return View(model);
                    }
                    else
                    {
                        existingLocation.Latitude = latitude.Value;
                        existingLocation.Longitude = longitude.Value;
                    }
                }

                existingLocation.Name = model.Name;
                existingLocation.Address = model.Address;
                existingLocation.City = model.City;
                existingLocation.County = model.County;
                existingLocation.PostCode = model.PostCode;
                existingLocation.Phone = model.Phone;
                existingLocation.Type = (LocationType)model.LocationTypeId;

                locationService.Update(existingLocation);
                return RedirectToAction(nameof(Index), new { id = model.LocationTypeId });
            }

            return View(model);
        }
    }
}