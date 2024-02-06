import HomeLayout from '../Layouts/HomeLayout';
import HomeFooter from '../Footers/HomeFooter';
import HomeNavbar from '../Navbars/HomeNavbar';
import { useEffect, useState } from 'react';
import '../../App.css';
import { Button, Card, Col, Container, Row } from 'react-bootstrap';

function AllProducts() {
    const apiURL = 'https://localhost:7274/api/Product/GetProducts';
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
                <section id="all-products" className="padding-medium bg-light">
                    <Container>
                        <Row>
                            <Col>
                                <h2 className="text-uppercase text-center pb-5">
                                    All Products
                                </h2>
                            </Col>
                        </Row>
                        
                        <Row>
                            {products.map((product) => (
                                <Col lg={3} md={6} key={product.id}>
                                    <Card className="product-card">
                                        <img src={product.image} className="card-img-top" alt={product.image} />
                                        <Card.Body>
                                            <Card.Title>{product.title}</Card.Title>
                                            <Button href={'product/' + product.id} variant='dark'>View</Button>
                                        </Card.Body>
                                    </Card>
                                </Col>
                            ))}
                        </Row>
                    </Container>
                </section>
                <HomeFooter />
            </HomeLayout>
        </>
    );
}
export default AllProducts;