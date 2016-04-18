using System.Collections.Generic;

namespace CodeChallenge
{
    /// <summary>
    ///  Interface for Service Layer
    /// </summary>
    public interface IVehicleLogic
    { 
        Vehicle GetVehicleById(int id);

        List<Vehicle> GetVehicleList();

        List<Vehicle> GetVehicleListBy(string make, string model, int year);

        Vehicle AddNewVehicle(Vehicle vehicle);

        void DeleteVehicle(int id);

        void UpdateVehicle(Vehicle vehicle);

    }
}