using System.Collections.Generic;

namespace CodeChallenge
{
    /// <summary>
    /// Implement Vehicle Restful API
    /// Processing raw data and send data to IVehicleLogic, the method can describe itself
    /// </summary>
    public class VehicleService : IVehicleService
    {
        private static IVehicleLogic VehicleRepository = new VehicleLogic();

        public Vehicle AddNewVehicle(Vehicle vehicle)
        {
            return VehicleRepository.AddNewVehicle(vehicle);
        }

        public void DeleteVehicle(string id)
        {
            VehicleRepository.DeleteVehicle(int.Parse(id));
            return;
        }

        public Vehicle GetVehicleById(string id)
        {
            return VehicleRepository.GetVehicleById(int.Parse(id));
        }

        public List<Vehicle> GetVehicleList()
        {
            return VehicleRepository.GetVehicleList();
        }

        public List<Vehicle> GetVehicleListBy(string make, string model, string year)
        {
            int yearInt;
            if (year == null || year.Length == 0) {
                yearInt = 0;
            }
            else {
                yearInt = int.Parse(year);
            }
            return VehicleRepository.GetVehicleListBy(make, model, yearInt);
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            VehicleRepository.UpdateVehicle(vehicle);
            return;
        }
    }
}
