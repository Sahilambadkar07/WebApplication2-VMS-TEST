// import React from "react";
// import { Line } from "react-chartjs-2";
// import { useEffect, useState } from "react" 

// const Dashboard = ({ vehicle }) => {

//   const [DashboardData, UpdateData] = useState(null)

//   // Calculate the average km/liter of fuel
//   const averageFuelEfficiency =
//     vehicle.totalKm / (vehicle.totalFuelFilled - vehicle.initialFuelAmount);

//   // Calculate the fuel expenses
//   const fuelExpenses = vehicle.totalFuelCost;

//   // Calculate the maintenance expenses
//   const maintenanceExpenses = vehicle.totalMaintenanceExpenses;

//   // Get an array of fuel usage over time
//   const fuelUsageOverTime = vehicle.dailyData.map((data) => ({
//     x: data.date,
//     y: data.fuelFilled,
//   }));
   
//   return (
//     <div>
//       <h2>{vehicle.vehicleNumber} Dashboard</h2>
//       <p>Current Odometer Reading: {vehicle.currentOdometerReading}</p>
//       <p>Fuel Remaining: {vehicle.currentFuelAmount}</p>
//       <p>Average km/liter of Fuel: {averageFuelEfficiency.toFixed(2)}</p>
//       <p>Fuel Expenses: Rs. {fuelExpenses}</p>
//       <p>Maintenance Expenses: Rs. {maintenanceExpenses}</p>
//       <div>
//         <h3>Fuel Usage Over Time</h3>
//         <p>This graph shows how much fuel was filled each day.</p>
//         {/* Add a chart component to display the fuel usage over time */}
//         {/* Example chart component: https://www.npmjs.com/package/react-chartjs-2 */}
//         <Line
//           data={{
//             datasets: [
//               {
//                 data: fuelUsageOverTime,
//                 label: "Fuel Filled",
//                 borderColor: "blue",
//                 fill: false,
//               },
//             ],
//           }}
//         />
//       </div>
//     </div>
//   );
// };

// export default Dashboard;



import React, { useEffect, useState } from 'react'

const DashBoard = () => {


    const [vehcile, setVehcile] = useState([])

    const getVehcile = async () => {
        try {
            const res = await fetch('https://localhost:44317/api/Vehicle/GetVehicleByUserID/2',{
                method : 'GET',
                headers : {
                    'Content-Type' : "application/json"
                }
            })

            const data = await res.json();

            console.log(data);
            setVehcile(data)

        } catch (error) {
            
        }
    }

    useEffect(()=>{
        getVehcile()
    },[])

    useEffect(()=>{
        
    },[vehcile])

  return (
    <div>
      {
        vehcile.map(e=>{
            return <div> 
                Vehicle No : {e.vehicleNumber}
            </div>
        })
      }
    </div>
  )
}

export default DashBoard

