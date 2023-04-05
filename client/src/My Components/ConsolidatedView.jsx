import React, { useState } from "react";

const ConsolidatedView = ({ vehicles }) => {
  const [selectedVehicleType, setSelectedVehicleType] = useState("car");

  const handleChange = (event) => {
    setSelectedVehicleType(event.target.value);
  };

  const filteredVehicles = vehicles.filter(
    (vehicle) => vehicle.type === selectedVehicleType
  );

  return (
    <div>
      <h2>Consolidated View</h2>
      <label>
        Vehicle Type:
        <select value={selectedVehicleType} onChange={handleChange}>
          <option value="car">Car</option>
          <option value="2-wheeler">2-Wheeler</option>
        </select>
      </label>
      <table>
        <thead>
          <tr>
            <th>Vehicle Number</th>
            <th>Odometer Reading</th>
            <th>Fuel Remaining</th>
            <th>Average Km/Liter</th>
            <th>Fuel Expenses</th>
            <th>Maintenance Expenses</th>
          </tr>
        </thead>
        <tbody>
          {filteredVehicles.map((vehicle) => (
            <tr key={vehicle.number}>
              <td>{vehicle.number}</td>
              <td>{vehicle.odometer}</td>
              <td>{vehicle.fuel}</td>
              <td>{vehicle.avgKmPerLiter}</td>
              <td>{vehicle.fuelExpenses}</td>
              <td>{vehicle.maintenanceExpenses}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ConsolidatedView;
