import React from 'react';

const AverageView = ({ vehicleData }) => {

  // Calculate the total number of days
  const startDate = new Date(vehicleData[0].date);
  const endDate = new Date(vehicleData[vehicleData.length - 1].date);
  const timeDifference = Math.abs(endDate.getTime() - startDate.getTime());
  const totalDays = Math.ceil(timeDifference / (1000 * 3600 * 24));

  // Calculate the average kilometers per day
  const totalKm = vehicleData.reduce((accumulator, currentData) => {
    return accumulator + parseInt(currentData.kilometersRun);
  }, 0);
  const avgKmPerDay = Math.round(totalKm / totalDays);

  // Calculate the average fuel consumption per day
  const totalFuel = vehicleData.reduce((accumulator, currentData) => {
    return accumulator + parseInt(currentData.fuelFilled);
  }, 0);
  const avgFuelConsumption = Math.round(totalFuel / totalDays);

  // Calculate the average maintenance cost per day
  const totalMaintCost = vehicleData.reduce((accumulator, currentData) => {
    return accumulator + parseInt(currentData.maintenanceExpenses);
  }, 0);
  const avgMaintCostPerDay = Math.round(totalMaintCost / totalDays);

  // Calculate the total expenses per day
  const totalExpenses = vehicleData.reduce((accumulator, currentData) => {
    return accumulator + parseInt(currentData.fuelCost) + parseInt(currentData.maintenanceExpenses);
  }, 0);
  const avgExpensesPerDay = Math.round(totalExpenses / totalDays);

  // Calculate the kilometers per liter
  const totalFuelAmount = vehicleData.reduce((accumulator, currentData) => {
    return accumulator + parseInt(currentData.fuelFilled);
  }, 0);
  const totalKmPerLiter = Math.round(totalKm / totalFuelAmount);

  // Calculate the rupees per kilometer
  const totalFuelCost = vehicleData.reduce((accumulator, currentData) => {
    return accumulator + parseInt(currentData.fuelCost);
  }, 0);
  const totalRupeesPerKm = Math.round((totalFuelCost + totalMaintCost) / totalKm);

  return (
    <div>
      <h2>Average View</h2>
      <p>Average kilometers per day: {avgKmPerDay}</p>
      <p>Average fuel consumption per day: {avgFuelConsumption}</p>
      <p>Average maintenance cost per day: {avgMaintCostPerDay}</p>
      <p>Total expenses per day: {avgExpensesPerDay}</p>
      <p>Kilometers per liter: {totalKmPerLiter}</p>
      <p>Rupees per kilometer: {totalRupeesPerKm}</p>
    </div>
  );
};

export default AverageView;
