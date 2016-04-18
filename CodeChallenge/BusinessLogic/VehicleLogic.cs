using System;
using System.Collections.Generic;

namespace CodeChallenge
{
    /// <summary>
    /// Implement of IVehicleLogic Interface, process business logic here.
    /// 
    /// This class can accept vehicle objects and store them. CRUD operation is supported, also support get vehicle(s) by it's field.
    /// </summary>
    public class VehicleLogic : IVehicleLogic
    {
        private IWithIdRepository<Vehicle> Repository = new WithIdRepository<Vehicle>();

        /// <summary>
        /// check if vehicle is valid and(if valid) add to repository, will return the added vehicle with assigned Id.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns>added vehicle with assigned Id</returns>
        public Vehicle AddNewVehicle(Vehicle vehicle)
        {
            ErrorMessage msg = new ErrorMessage();
            if (ValidVehicle(ref msg, vehicle))
            {
                Repository.Add(ref vehicle);
                return vehicle;
            }
            else {
                return null;
            }
        }

        public void DeleteVehicle(int id)
        {
            Repository.Delete(id);
        }

        public Vehicle GetVehicleById(int id)
        {
            return Repository.GetById(id);
        }

        public List<Vehicle> GetVehicleList()
        {
            return new List<Vehicle>(Repository.GetAll());
        }

        /// <summary>
        /// This method will generate funcs list as predicates to filter returned vehicle(s)
        /// </summary>
        /// <param name="make">Use "like" to filter, which means all vehicle(s) contains make will remain. If don't want to filter this field, set to null or empty</param>
        /// <param name="model">Use "like" to filter, which means all vehicle(s) contains model will reamin. If don't want to filter this field, set to null or empty</param>
        /// <param name="year">Use "Equal" to filter, which means only vehilce(s) have exactly same year will remain. If don't want to filter this field, set to 0</param>
        /// <returns></returns>
        public List<Vehicle> GetVehicleListBy(string make, string model, int year)
        {
            List<Func<Vehicle, bool>> predicates = new List<Func<Vehicle, bool>>();
            //check if contains string 'make', case insensitive
            if (make != null && make.Length != 0) {
                predicates.Add(new Func<Vehicle, bool>(x => x.Make.IndexOf(make, StringComparison.OrdinalIgnoreCase) >= 0));
            }
            if (model != null && model.Length != 0) {
                predicates.Add(new Func<Vehicle, bool>(x => x.Model.IndexOf(model, StringComparison.OrdinalIgnoreCase) >= 0));
            }
            if (year != 0) {
                predicates.Add(new Func<Vehicle, bool>(x => x.Year == year));
            }
            
            return new List<Vehicle>(Repository.GetBy(predicates));
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            ErrorMessage msg = new ErrorMessage();
            if (ValidVehicle(ref msg, vehicle))
            {
                Repository.Update(vehicle);
            }
            return;
        }

        /// <summary>
        /// vehicle validating condition
        /// All fields cannot be null or empty
        /// Year must between 1950 to 2050 (inclusive)
        /// Make & Model can not longer than 100 characters
        /// </summary>
        /// <param name="msg">used for send Error Message to client, currently is not in use</param>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        private bool ValidVehicle(ref ErrorMessage msg, Vehicle vehicle)
        {
            bool valid = true;
            if (vehicle == null)
            {
                msg.Message += "Vehicle can not be new ";
                valid = false;
                return valid;
            }
            if (vehicle.Year < 1950 || vehicle.Year > 2050)
            {
                msg.Message += "Year must between 1950 to 2050 ";
                valid = false;
            }
            if (vehicle.Make == null || vehicle.Make.Length == 0 || vehicle.Make.Length > 100)
            {
                msg.Message += "Make can not be empty or more than 100 characters";
                valid = false;
            }
            if (vehicle.Model == null || vehicle.Model.Length == 0 || vehicle.Model.Length > 100)
            {
                msg.Message += "Model can not be empty or more than 100 characters";
                valid = false;
            }
            return valid;
        }
    }
}