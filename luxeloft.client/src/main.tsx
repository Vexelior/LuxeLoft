import ReactDOM from 'react-dom/client'
import { BrowserRouter, Routes, Route } from "react-router-dom";
import App from './App.tsx'
import AllProducts from './components/Pages/AllProducts.tsx'
import MensClothing from './components/Pages/MensClothing.tsx'
import 'font-awesome/css/font-awesome.min.css'
import './assets/js/vendor/jquery-1.11.0.min.js'
import './assets/js/script.js'
import './index.css'
import 'bootstrap/dist/js/bootstrap.min.js'
import 'bootstrap/dist/css/bootstrap.min.css'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <BrowserRouter>
    <Routes>
      <Route path="/" element={<App />} />
      <Route path='all-products' element={<AllProducts />} />
      <Route path='mens-clothing' element={<MensClothing />} />
    </Routes>
  </BrowserRouter>
)