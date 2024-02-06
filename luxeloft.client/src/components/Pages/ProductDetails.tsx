import HomeLayout from '../Layouts/HomeLayout';
import HomeFooter from '../Footers/HomeFooter';
import HomeNavbar from '../Navbars/HomeNavbar';
import { useEffect, useState } from 'react';
import '../../App.css';

function ProductDetails() {
    const url = window.location.href;
    const id = url.substring(url.lastIndexOf('/') + 1);
    const productApiURL = 'https://localhost:7274/api/Product/GetProduct/' + id;
    const productRatingApiURL = 'https://localhost:7274/api/ProductRating/GetProductRating/' + id;

    const [product, setProduct] = useState<any>({});
    const [productRating, setProductRating] = useState<any>({});

    useEffect(() => {
        fetch(productRatingApiURL)
            .then(response => response.json())
            .then(data => setProductRating(data))
            .catch((error) => {
                console.error('Error:', error);
            });
    }, [productRatingApiURL]);

    useEffect(() => {
        fetch(productApiURL)
            .then(response => response.json())
            .then(data => setProduct(data))
            .catch((error) => {
                console.error('Error:', error);
            });
    }, [productApiURL]);

    if (productRating.rate !== undefined && productRating.rate % 1 !== 0 && productRating.rate % 1 !== 0.5) {
        productRating.rate = Math.round(productRating.rate);
    } else {
        product.ratings = productRating.rate;
    }

    if (product.price % 1 === 0) {
        product.price = product.price + '.00';
    }

    useEffect(() => {
        if (productRating.rate !== undefined) {
            for (let i = 0; i < productRating.rate; i++) {
                document.getElementsByClassName('fa fa-star')[i].classList.add('checked');
            }
        }
    }, [productRating.rate]);

    return (
        <>
            <HomeLayout>
                <HomeNavbar />
                <section id="product-details" className="padding-xlarge bg-white">
                    <div className="container">
                        <div className="row">
                            <div className="col-lg-12">
                                <h2 className="text-uppercase text-center pb-5">
                                    {product.title}
                                </h2>
                            </div>
                        </div>
                        <div className="row">
                            <div className="col-lg-4 col-md-6 col-sm-12">
                                <img src={'/src/assets/images/products/' + product.image} className="card-img-top" alt="..." />
                            </div>
                            <div className="col-lg-8 col-md-6 col-sm-12">
                                <p>{product.description}</p>
                                <p><strong>${product.price}</strong></p>
                                <div className="rating mb-3">
                                    <span className="fa fa-star"></span>
                                    <span className="fa fa-star"></span>
                                    <span className="fa fa-star"></span>
                                    <span className="fa fa-star"></span>
                                    <span className="fa fa-star"></span>
                                    <span>&nbsp;({productRating.count})</span>
                                </div>     
                                <button className="btn btn-dark" onClick={() => window.history.back()}>Back</button>
                            </div>
                        </div>
                    </div>
                </section>
                <HomeFooter />
            </HomeLayout >
        </>
    );
}
export default ProductDetails;