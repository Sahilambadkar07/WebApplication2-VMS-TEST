import React from 'react';

const DateWiseView = ({ data }) => {
  return (
    <table>
      <thead>
        <tr>
          <th>Date</th>
          <th>Kilometers Run</th>
          <th>Fuel Filled</th>
          <th>Fuel Amount</th>
          <th>Maintenance Expenses</th>
        </tr>
      </thead>
      <tbody>
        {data.map((entry) => (
          <tr key={entry.date}>
            <td>{entry.date}</td>
            <td>{entry.kmRun}</td>
            <td>{entry.fuelFilled}</td>
            <td>{entry.fuelAmount}</td>
            <td>{entry.maintenanceExpenses}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default DateWiseView;
