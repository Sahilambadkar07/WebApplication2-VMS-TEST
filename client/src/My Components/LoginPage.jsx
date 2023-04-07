import React, { useState } from 'react';
import './LoginPage.css';
import { Navigate, useNavigate } from 'react-router-dom';

const LoginPage = ({setIsLoggedInFunc}) => {
  const [username, setUsername] = useState('');
  const [password, setPassword] = useState('');


  const navigate = useNavigate();

  const handleLogin = (event) => {
    event.preventDefault();
    // TODO: Replace with actual authentication logic here
    if (username === 'admin' && password === 'password') {
      setIsLoggedInFunc(true);
      navigate('/Dashboard')
      // return <Navigate to="/Dashboard" />;
    } else {
      alert('Invalid username or password');
    }
  };

  

  return (
    <div className="login-page">
      <div className="login-form-container">
        <h1 className="login-title">Pratiti Vehicle Manager</h1>
        <form onSubmit={handleLogin}>
          <div className="form-field">
            <label htmlFor="username">Username:</label>
            <input
              type="text"
              id="username"
              value={username}
              onChange={(event) => setUsername(event.target.value)}
            />
          </div>
          <div className="form-field">
            <label htmlFor="password">Password:</label>
            <input
              type="password"
              id="password"
              value={password}
              onChange={(event) => setPassword(event.target.value)}
            />
          </div>
          <button type="submit" className="login-btn">
            Login
          </button>
        </form>
      </div>
    </div>
  );
};

export default LoginPage;
