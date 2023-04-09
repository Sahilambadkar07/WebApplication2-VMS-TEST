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

    const getAvgData = () => {
        getFromDates(`/TotalExpPerDay/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("TotalExpPerDay", data);
        })
        getFromDates(`/RsPerKm/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("RsPerKm", data);
        })
        getFromDates(`/KmPerDay/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("KmPerDay", data);
        })
        getFromDates(`/FuelComPerDay/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("FuelComPerDay", data);
        })
        getFromDates(`/MaintCostPerDay/${vehicleId}/${formData.startdate}/${formData.enddate}`).then((data)=>{
            console.log("MaintCostPerDay", data);
        })
    }


    useEffect(() => {
      
        getAvgData();

    }, [])
    

  return (
    <div>
      AverageView
    </div>
  )
}

export default AverageView
