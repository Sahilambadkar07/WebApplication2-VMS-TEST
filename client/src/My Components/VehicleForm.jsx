import React, { useState } from "react";
import DatePicker from "react-datepicker";
import "./VehicleForm.css";
import moment from "moment";


const VehicleForm = ({ addVehicle }) => {
  const [type, setType] = useState("Two Wheeler");
  const [vehicleNumber, setVehicleNumber] = useState("");
  const [isSmartVehicle, setIsSmartVehicle] = useState(false);
  const [fuelType, setFuelType] = useState("Petrol");
  const [fuelCapacity, setFuelCapacity] = useState(0);
  const [odometerReading, setOdometerReading] = useState(0);
  const [lastServiceDate, setLastServiceDate] = useState(new Date());
  const [lastServiceCharge, setLastServiceCharge] = useState(0);
  const [fuelAmount, setFuelAmount] = useState(0);

  const handleSubmit = (e) => {
    e.preventDefault();
    const newVehicle = {
      type,
      vehicleNumber,
      isSmartVehicle,
      fuelType,
      fuelCapacity: Number(fuelCapacity),
      odometerReading: Number(odometerReading),
      lastServiceDate,
      lastServiceCharge: Number(lastServiceCharge),
      fuelAmount: Number(fuelAmount)
    };
    console.log(newVehicle);

    // addVehicle(newVehicle);
  };

  const handleDateChange = (e) => {
    setLastServiceDate(moment(e).format("YYYY-MM-DD"));
  };

  return (
    <form className="vehicle-form" onSubmit={handleSubmit}>
      <label>
        Type of Vehicle:
        <select  
          className="vehicle-input"  
          value={type}
          onChange={(e)=>setType(e.target.value)}
        >
          <option value={'Two Wheeler'} >Two Wheeler</option>
          <option value={'Four Wheeler'} >Four Wheeler</option>
        </select>
        {/* <input
          className="vehicle-input"
          type="text"
          value={type}
          onChange={(e) => setType(e.target.value)}
        /> */}
      </label>
      <br />
      <label>
        Vehicle Number:
        <input
          className="vehicle-input"
          type="text"
          value={vehicleNumber}
          onChange={(e) => setVehicleNumber(e.target.value)}
        />
      </label>
      <br />
      <label>
        Smart Vehicle:
        <input
          className="vehicle-input"
          type="checkbox"
          checked={isSmartVehicle}
          onChange={() => setIsSmartVehicle(!isSmartVehicle)}
        />
      </label>
      <br />
      <label>
        Fuel Type:
        <select  
          className="vehicle-input"  
          value={fuelType}
          onChange={(e)=>setFuelType(e.target.value)}
        >
          <option value={'Petrol'} >Petrol</option>
          <option value={'Dieasel'} >Dieasel</option>
        </select>
      </label>
      <br />
      <label>
        Fuel Capacity:
        <input
          className="vehicle-input"
          type="text"
          value={fuelCapacity}
          onChange={(e) => setFuelCapacity(e.target.value)}
        />
      </label>
      <br />
      <label>
        Odometer Reading:
        <input
          className="vehicle-input"
          type="number"
          min={0}
          value={odometerReading}
          onChange={(e) => setOdometerReading(e.target.value)}
        />
      </label>
      <br />
      <label>
        <div>

        Last Service Date:
        </div>
        <input type="date" 
        className="vehicle-input"
        style={{
          width:'100%'
        }}
        value={lastServiceDate}
        onChange={(e) => handleDateChange(e.target.value)}
        ></input>
      </label>
      <br />
      <label>
        Last Service Charge:
        <input
          className="vehicle-input"
          type="number"
          min={0}
          value={lastServiceCharge}
          onChange={(e) => setLastServiceCharge(e.target.value)}
        />
      </label>
      <br />
      <label>
        Amount of Fuel in Vehicle:
        <input
          className="vehicle-input"
          type="number"
          value={fuelAmount}
          onChange={(e) => setFuelAmount(e.target.value)}
        />
      </label>
      <br />
      <button className="vehicle-button" type="submit">
        Add Vehicle
      </button>
    </form>
  );
};

export default VehicleForm;
