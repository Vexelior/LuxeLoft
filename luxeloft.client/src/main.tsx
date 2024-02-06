import ReactDOM from 'react-dom/client'
import { BrowserRouter, Routes, Route } from "react-router-dom"
import App from './App.tsx'
import AllProducts from './components/Pages/AllProducts.tsx'
import MensClothing from './components/Pages/MensClothing.tsx'
import WomensClothing from './components/Pages/WomensClothing.tsx'
import Jewelery from './components/Pages/Jewelery.tsx'
import Electronics from './components/Pages/Electronics.tsx'
import ProductDetails from './components/Pages/ProductDetails.tsx'
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
      <Route path='womens-clothing' element={<WomensClothing />} />
      <Route path='jewelery' element={<Jewelery />} />
      <Route path='electronics' element={<Electronics />} />
      <Route path='product/:id' element={<ProductDetails />} />
    </Routes>
  </BrowserRouter>
)