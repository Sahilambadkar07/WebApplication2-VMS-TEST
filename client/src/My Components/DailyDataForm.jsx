import React, { useState } from 'react';

const DailyDataForm = () => {
  const [odometerReading, setOdometerReading] = useState('');
  const [hoursOfOperation, setHoursOfOperation] = useState('');
  const [fuelFilled, setFuelFilled] = useState('');
  const [fuelCost, setFuelCost] = useState('');
  const [maintenanceExpenses, setMaintenanceExpenses] = useState('');

  const handleSubmit = (event) => {
    event.preventDefault();
    // TODO: Submit the form data to the system
  };

  return (
    <form onSubmit={handleSubmit}>
      <label>
        Odometer Reading:
        <input type="text" value={odometerReading} onChange={(event) => setOdometerReading(event.target.value)} />
      </label>
      <label>
        Hours of Operation:
        <input type="text" value={hoursOfOperation} onChange={(event) => setHoursOfOperation(event.target.value)} />
      </label>
      <label>
        Fuel Filled:
        <input type="text" value={fuelFilled} onChange={(event) => setFuelFilled(event.target.value)} />
      </label>
      <label>
        Fuel Cost:
        <input type="text" value={fuelCost} onChange={(event) => setFuelCost(event.target.value)} />
      </label>
      <label>
        Maintenance Expenses:
        <input type="text" value={maintenanceExpenses} onChange={(event) => setMaintenanceExpenses(event.target.value)} />
      </label>
      <button type="submit">Submit</button>
    </form>
  );
};

export default DailyDataForm;
