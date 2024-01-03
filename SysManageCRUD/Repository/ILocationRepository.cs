using Microsoft.AspNetCore.Mvc.Rendering;
using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface ILocationRepository
    {

       LocationHpt GetLocation(int idLocation); // Get one element.
       List<LocationHpt> GetLocations(); //get multiples elements. 
       LocationHpt CreateLocation(LocationHpt location); //Create a new location
       LocationHpt UpdateLocation(LocationHpt location); //Update a location
       void DeleteLocation(int idLocation); //Delete a location.

        IEnumerable<SelectListItem> GetSelectListLocation();

    }
}
