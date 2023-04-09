import { Button, TextField } from '@mui/material'
import React, { useState } from 'react'
import { useNavigate } from 'react-router-dom';

const Register = () => {


    const navigate = useNavigate();

    const gotoLogin = () => {
        navigate('/login')
    }

    const [formData, setFormData] = useState({
        userId: 0,
        username: '',
        password: '',
        confirmPassword: '',
    })

    const changeHandler = (e) => {
        var name = e.target.name;
        var value = e.target.value;

        setFormData({
            ...formData,
            [name]: value
        })
    }


    const handleRegister = async () => {
        if (formData.password !== formData.confirmPassword) return;
        console.log(formData);
        try {
            const res = await fetch('https://localhost:7059/api/User/CreateUser', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    username: formData.username,
                    password: formData.password
                })
            })

            const data = await res.json();
            console.log(data);
            navigate('/login')
        } catch (error) {

        }


    }


    return (
        <div style={{
            width: '100%',
            height: '100vh',
            display: 'flex',
            justifyContent: 'center',
            alignItems: 'center'
        }} >
            <div style={{
                width: '450px',
                backgroundColor: 'white',
                borderRadius: '5px',
                padding: '1.5rem',
                boxShadow: 'rgba(99, 99, 99, 0.2) 0px 2px 8px 0px'
            }} >
                <div>
                    <h2 className='mb_1' >Register</h2>
                    <TextField name='username' value={formData.username} onChange={changeHandler} style={{ width: '100%', marginBottom: '2rem' }} id="standard-basic" label="User Name" variant="standard" />
                    <TextField name='password' value={formData.password} onChange={changeHandler} type='password' style={{ width: '100%', marginBottom: '2rem' }} id="standard-basic" label="Password" variant="standard" />
                    <TextField name='confirmPassword' value={formData.confirmPassword} onChange={changeHandler} type='password' style={{ width: '100%', marginBottom: '2rem' }} id="standard-basic" label="Confirm Password" variant="standard" />
                    <Button
                        type='submit'
                        style={{
                            width: '100%',
                            marginBottom: '2rem'
                        }}
                        variant='contained'
                        onClick={handleRegister}
                    >
                        Register
                    </Button>
                </div>
                <Button
                    type='submit'
                    style={{
                        width: '100%',
                    }}
                    onClick={gotoLogin}
                >
                    Login
                </Button>
            </div>
        </div>
    )
}

export default Register
