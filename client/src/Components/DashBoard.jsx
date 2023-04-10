import React, { useContext, useEffect, useState } from 'react'
import DenseAppBar from './DashComponents/AppBar'
import AddVehicleForm from './DashComponents/AddVehicleForm'
import VehiclesTable from './DashComponents/VehiclesTable'
import { AppContext } from '../App'
import { useNavigate } from 'react-router-dom'


function createData(vehicleId ,vehicleNumber, vehicleType, isSmartVehicle, lastServiceDate) {
    return {
        vehicleId,
        vehicleNumber,
        vehicleType,
        isSmartVehicle,
        lastServiceDate
    }
}



const DashBoard = () => {


    const {rootUser} = useContext(AppContext);

    const navigate = useNavigate();
    const [rows, setRows] = useState([])


    const getVehicleByUserId =  async () => { 
        try {
            
            const res = await fetch(`https://localhost:7059/api/Vehicle/GetVehicleByUserID/${rootUser.userId}`, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                }
            })

            const data = await res.json();
            
            console.log(data);

            var newRows = [];

            await data.forEach(element => {
                newRows.push(createData(
                    element.vehicleId,
                    element.vehicleNumber,
                    element.vehicleType,
                    element.isSmartVehicle,
                    element.lastServiceDate
                ))
            });

            if(data.length > 0 && newRows < data.length) getVehicleByUserId();
            setRows(newRows);

        } catch (error) {
            
        }
    }   

    useEffect(() => {

        if(rootUser.userId === undefined){
            navigate('/login')
        }

        getVehicleByUserId();

    }, [])



    

    

    
// const rows = [
//     createData('MH2700001', "Two Wheeler",  false, "2023-03-04"),
//     createData('MH2700002',  "Four Wheeler", true, "2023-02-10"),
//     createData('MH2700003',  "Four Wheeler", true, "2023-04-01"),
//     createData('MH2700004',  "Two Wheeler", false, "2023-01-14"),
//     createData('MH2700005',  "Two Wheeler", true, "2023-03-17"),
//   ];

  return (
    <div style={{
        display:'flex',
        width: '100%',
        alignItems: 'center',
        justifyContent: 'center',
        marginTop:'1rem'
    }} >
        <div style={{
            width:'70%',
            display:'flex',
            flexDirection:'column',
        }} >
            <DenseAppBar />
            <div style={{ 
                alignSelf:'flex-end' 
            }} >
                
            <AddVehicleForm setRows={setRows} />
            </div>
            <VehiclesTable  rows={rows} />
        </div>
    </div>
  )
}

export default DashBoard
