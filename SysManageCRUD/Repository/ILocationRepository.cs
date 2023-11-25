using SysManageCRUD.Models;

namespace SysManageCRUD.Repository
{
    public interface ILocationRepository
    {

       Location GetLocation(int idLocation); // Get one element.
       List<Location> GetLocations(); //get multiples elements. 
       Location CreateLocation(Location location); //Create a new location
       Location UpdateLocation(Location location); //Update a location
       void DeleteLocation(int idLocation); //Delete a location.

    }
}
