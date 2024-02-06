import HomeLayout from '../Layouts/HomeLayout';
import HomeFooter from '../Footers/HomeFooter';
import HomeNavbar from '../Navbars/HomeNavbar';
import { useEffect, useState } from 'react';
import '../../App.css';

function Jewelery() {
    const apiURL = 'https://localhost:7274/api/Product/GetJewelery';
    const [products, setProducts] = useState<any[]>([]);

    useEffect(() => {
        fetch(apiURL)
            .then(response => response.json())
            .then(data => setProducts(data))
            .catch((error) => {
                console.error('Error:', error);
            });
    }, []);

    products.forEach((product) => {
        product.image = 'src/assets/images/products/' + product.image;
    });

    return (
        <>
            <HomeLayout>
                <HomeNavbar />
                <section id="mens" className="padding-xlarge bg-light">
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-12">
                                <h2 className="text-uppercase text-center pb-5">
                                    Jewelery
                                </h2>
                            </div>
                        </div>
                        <div className="row">
                            {products.map((product) => (
                                <div className="col-lg-4 col-md-6 col-sm-12" key={product.id}>
                                    <div className="card">
                                        <img src={product.image} className="card-img-top" alt="..." />
                                        <div className="card-body">
                                            <h5 className="card-title">{product.title}</h5>
                                            <p className="card-text">{product.description}</p>
                                            <a href="#" className="btn btn-dark">Add to Cart</a>
                                        </div>
                                    </div>
                                </div>
                            ))}
                        </div>
                    </div>
                </section>
                <HomeFooter />
            </HomeLayout>
        </>
    );
}
export default Jewelery;