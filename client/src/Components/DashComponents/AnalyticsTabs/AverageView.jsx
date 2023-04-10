import React, { useEffect, useState } from 'react'

const AverageView = ({vehicleId, formData}) => {

    
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

    const [totalExpPerDay, setTotalExpPerDay] = useState(0)
    const [rsPerKm, setRsPerKm] = useState(0)
    const [kmPerDay, setKmPerDay] = useState(0)
    const [fuelComPerDay, setFuelComPerDay] = useState(0)
    const [maintCostPerDay, setMaintCostPerDay] = useState(0)

    const getAvgData = () => {
        getFromDates(`/TotalExpPerDay/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("TotalExpPerDay", data);
            setTotalExpPerDay(data);
        })
        getFromDates(`/RsPerKm/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("RsPerKm", data);
            setRsPerKm(data);
        })
        getFromDates(`/KmPerDay/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("KmPerDay", data);
            setKmPerDay(data);
        })
        getFromDates(`/FuelComPerDay/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("FuelComPerDay", data);
            setFuelComPerDay(data);
        })
        getFromDates(`/MaintCostPerDay/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("MaintCostPerDay", data);
            setMaintCostPerDay(data);
        })
    }


    useEffect(() => {
      
        getAvgData();

    }, [])
    

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

        <h2>TotalExpPerDay      : {totalExpPerDay} </h2> 
        <h2>Rs Per Km           : {rsPerKm} </h2>  
        <h2>Km Per Day          : {kmPerDay} </h2> 
        <h2>Fuel Com Per Day    : {fuelComPerDay} </h2> 
        <h2>Maint Cost Per Day  : {maintCostPerDay} </h2> 
    </div>
    </div>
  )
}

export default AverageView
