import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App.tsx'
import './assets/js/vendor/jquery-1.11.0.min.js'
import './assets/js/script.js'
import './index.css'
import './assets/css/vendor/vendor.css'
import 'bootstrap/dist/js/bootstrap.min.js'
import 'bootstrap/dist/css/bootstrap.min.css'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
)
