using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentReadyDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressInfoController : ControllerBase
    {
        /// <summary>
        /// mock up data since we don't have a database or other store - would likely be a database or another call
        /// </summary>
        /// <returns></returns>
        private List<AddressDetail> getSourceData()
        {
            var addresses = new List<AddressDetail>();

            addresses.Add(new AddressDetail
            {
                Id=1,
                Address1 = "100 North Mail St.",
                Address2 = string.Empty,
                City = "Charlotte",
                State = "NC",
                PostalCode = "27310-1234",
                Country = "USA",
                GeoCode = "5234",
                MSA = "Charlotte",
                Lattitude = 104.124,
                Longitude = -83.3432
            });

            addresses.Add(new AddressDetail
            {
                Id = 2,
                Address1 = "302 Grandview Circle",
                Address2 = "Suite 55",
                City = "Clarkesville",
                State = "GA",
                PostalCode = "30531-1234",
                Country = "USA",
                GeoCode = "5234",
                MSA = "Gainesville",
                Lattitude = 100.124,
                Longitude = -82.3432
            });

            addresses.Add(new AddressDetail
            {
                Id = 3,
                Address1 = "200 Same Address Rd.",
                Address2 = "",
                City = "Raleigh",
                State = "NC",
                PostalCode = "04321",
                Country = "USA",
                GeoCode = "22",
                MSA = "Raleigh",
                Lattitude = 100.124,
                Longitude = -85.3432
            });

            addresses.Add(new AddressDetail
            {
                Id = 4,
                Address1 = "1600 Pennsylvania Avenue NW",
                Address2 = "",
                City = "Washington",
                State = "DC",
                PostalCode = "20500",
                Country = "USA",
                GeoCode = "5234",
                MSA = "WashingtonDC",
                Lattitude = 100.124,
                Longitude = -82.3432
            });

            addresses.Add(new AddressDetail
            {
                Id = 5,
                Address1 = "7995 Fogleman Way",
                Address2 = "",
                City = "Oak Ridge",
                State = "NC",
                PostalCode = "27310",
                Country = "USA",
                GeoCode = "5234",
                MSA = "Greensboro",
                Lattitude = 100.124,
                Longitude = -82.3432
            });

            addresses.Add(new AddressDetail
            {
                Id = 6,
                Address1 = "1315 Westbrook Plaza Dr",
                Address2 = "Suite 100",
                City = "Winston-Salem",
                State = "NC",
                PostalCode = "27104",
                Country = "USA",
                GeoCode = "5234",
                MSA = "Wiston-Salem",
                Lattitude = 100.1241,
                Longitude = -82.312
            });

            addresses.Add(new AddressDetail
            {
                Id = 7,
                Address1 = "P.O. Box 609",
                Address2 = "",
                City = "Mount Olive",
                State = "NC",
                PostalCode = "28365",
                Country = "USA",
                GeoCode = "8675",
                MSA = "Fayetteville",
                Lattitude = 100.1241,
                Longitude = -82.312
            });


            addresses.Add(new AddressDetail
            {
                Id = 8,
                Address1 = "4222 Clinton Way",
                Address2 = "",
                City = "Los Angeles",
                State = "CA",
                PostalCode = "07362",
                Country = "USA",
                GeoCode = "8675",
                MSA = "LosAngeles",
                Lattitude = 100.1241,
                Longitude = -82.312
            });

            addresses.Add(new AddressDetail
            {
                Id = 9,
                Address1 = "112 1/2 Beacon St",
                Address2 = "",
                City = "Boston",
                State = "MA",
                PostalCode = "86371",
                Country = "USA",
                GeoCode = "8675",
                MSA = "Boston",
                Lattitude = 99.1241,
                Longitude = -82.312
            });

            addresses.Add(new AddressDetail
            {
                Id = 10,
                Address1 = "112 1/2 Beacon St",
                Address2 = "",
                City = "Boston",
                State = "MA",
                PostalCode = "86371",
                Country = "USA",
                GeoCode = "8675",
                MSA = "Boston",
                Lattitude = 99.1241,
                Longitude = -82.312
            });

            addresses.Add(new AddressDetail
            {
                Id = 11,
                Address1 = "518 Crestview Dr",
                Address2 = "",
                City = "Beverly Hills",
                State = "CA",
                PostalCode = "08311",
                Country = "USA",
                GeoCode = "8675",
                MSA = "LosAngeles",
                Lattitude = 99.1241,
                Longitude = 75.11
            });

            return addresses;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, AddressDetail address)
        {
            if (id != address.Id)
            {
                return BadRequest();
            }

            //todo: normally if valid you would do an update to your data store, in this case well'll just drop and add - once again it doesn't matter

            var addressInDb = getSourceData().Where(a => a.Id == id).FirstOrDefault();
            if(addressInDb == null)
            {
                return NotFound();
            }

            var addr = getSourceData().Find(a=>a.Id == id);  //simulation, would be normally be a datastore like above
            if (addr != null)
                getSourceData().Remove(addr);

            var addresses = getSourceData();
            addresses.Add(address);

            return NoContent();
            //or you could return  CreatedAtAction(nameof(GetAddress), new { id = addressDetail.Id }, addressDetail); but NoContent is more RESTy

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<AddressDetail>> Delete(long id)
        {
            var address = getSourceData().Where(a => a.Id == id).FirstOrDefault();

            if (address == null)
            {
                return NotFound();
            }

            var addresses = getSourceData().Remove(address); // delete from the collection, as mentioned below, would typically be a real db

            return address;
        }

        // GET: api/GetAddresses
        [HttpGet]
        public List<AddressDetail> Get()
        {
            List<AddressDetail> addresses = getSourceData().Take<AddressDetail>(10).ToList();  //I  have 11 in the mock up for simulating the limit
            return addresses;
        }

        /// <summary>
        /// Get single item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDetail>> Get(long id)
        {
            var address = getSourceData().Where(a => a.Id == id).FirstOrDefault();

            if (address == null)
            {
                return NotFound();
            }

            return address;
        }


        /// <summary>
        /// Create a new address item - see notes in body
        /// </summary>
        /// <param name="addressDetail"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<AddressDetail>> Post(AddressDetail addressDetail)
        {

            //todo: I would validate the entity being passed, if failed log and error and return a 500 to requesting client
            //If validate do something with the object, likely a database insert being a post
            //I could add this the collection but being stateless it wouldn't matter.  The CreatedAtAction would normally
            //pull back the objective I just created, in this case it points to an item that doesn't exist.

            return CreatedAtAction(nameof(Get), new { id = addressDetail.Id }, addressDetail);
        }
    }
}