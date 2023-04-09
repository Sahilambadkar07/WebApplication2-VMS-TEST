import React, { useEffect, useState } from 'react'

const DashBoard = ({vehicleId, formData}) => {

    const getMethods  = async ( route ) => {
        try {
            const res = await fetch('https://localhost:7059/api/Dashboard' + route , {
                method: 'GET',
                headers : {
                    'Content-Type': 'application/json'
                }
            })

            const data = await res.json();

            return data;

        } catch (error) {
            
        }
    }

    const getFromDates  = async ( route ) => {
        try {
            const res = await fetch('https://localhost:7059/api/Dashboard' + route , {
                method: 'GET',
                headers : {
                    'Content-Type': 'application/json'
                }
            })

            const data = await res.json();

            return data;

        } catch (error) {
            
        }
    }

   /*
     Current o reading
     fuel remaining
     avd km per ltr
     fuel expenses
     main expenses
   */


    const [odometerReading, setOdometerReading] = useState(0)
    const [fuelRemaining, setFuelRemaining] = useState(0)
    const [avg_km_per_ltr, setAvg_km_per_ltr] = useState(0)
    const [fuelExpenses, setFuelExpenses] = useState(0)
    const [mainExpenses, setMainExpenses] = useState(0)

    const getData = () => {

        getMethods(`/GetCurrentOdodmeterReading/${vehicleId}`).then((data)=>{
            console.log("odometer reading",data);
            setOdometerReading(data)
        })
        getMethods(`/GetRemainingFuelAmount/${vehicleId}`).then((data)=>{
            console.log("fuel ammount",data);
            setFuelRemaining(data)
        })
        getFromDates(`/Avg_Km_Per_Ltr/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("Avg km pre ltr",data);
            setAvg_km_per_ltr(data);
        })
        getFromDates(`/FuelExpenses/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("AFuelExpenses",data);
            setFuelExpenses(data);
        })
        getFromDates(`/MaintExpenses/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("MaintExpenses",data);
            setMainExpenses(data);
        })
        
    }


    useEffect(() => {
        getData();
    }, [formData])
    

  return (
    <div style={{
        display:'flex',
        justifyContent: 'center',
        alignItems: 'center',
    }} >

    <div style={{
        borderRadius: '5px',
        boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px',
        padding : '2rem',
        width:'80%',
        display:'flex',
        // alignItems:'center',
        // justifyContent:'center',
        flexDirection:'column',
    }} >
        <h2>Odometer Reading : {odometerReading} </h2> 
        <h2>Fuel Remaining   : {fuelRemaining} </h2> 
        <h2>Avg Km Per Ltr   : {avg_km_per_ltr.toString().substring(0,4)} </h2> 
        <h2>Fuel Expenses    : {fuelExpenses} </h2> 
        <h2>Main Expenses    : {mainExpenses} </h2> 
    </div>
        </div>
  )
}

export default DashBoard