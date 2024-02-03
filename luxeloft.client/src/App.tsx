import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faTruck, faMedal, faTag, faCreditCard } from '@fortawesome/free-solid-svg-icons';
import { Button, Container, Col, Row } from 'react-bootstrap';
import BannerImage from './assets/images/baner-right-image-04.jpg';
import YearlyBanner from './assets/images/baner-right-image-01.jpg';
import HomeFooter from './components/Footers/HomeFooter';
import HomeNavbar from './components/Navbars/HomeNavbar';
import HomeLayout from './components/Layouts/HomeLayout';
import 'swiper/swiper-bundle.css';
import './App.css';

function App() {
    return (
        <>
            <HomeLayout>
                <HomeNavbar />
                <section id="home" className="position-relative overflow-hidden padding-xlarge bg-white">
                    <Container>
                        <Row className="d-flex align-items-center">
                            <Col md={6}>
                                <div className="banner-content">
                                    <h1 className="display-2 text-uppercase text-dark pb-5">
                                        LUXELOFT
                                    </h1>
                                    <p>
                                        Explore the world of luxury living through LuxeLoft. We offer a wide range of luxurious clothes and fashion items to help you create the perfect living space.
                                    </p>
                                    <Button href="#" className="btn-medium btn-dark text-uppercase btn-rounded-none">
                                        Shop Now!
                                    </Button>
                                </div>
                            </Col>
                            <Col md={6}>
                                <img
                                    src={BannerImage}
                                    alt="Home Banner"
                                    className="img-fluid"
                                />
                            </Col>
                        </Row>
                    </Container>
                </section>
                <section id="promote" className="padding-xlarge bg-light">
                    <Container>
                        <Row>
                            <Col lg={3} md={6} className="pb-3">
                                <div className="icon-box d-flex">
                                    <div className="icon-box-content">
                                        <h3 className="card-title text-uppercase text-dark">
                                            <FontAwesomeIcon icon={faTruck} />
                                            &nbsp;Free delivery
                                        </h3>
                                        <p>
                                            We provide free delivery on all orders over $100.
                                        </p>
                                    </div>
                                </div>
                            </Col>
                            <Col lg={3} md={6} className="pb-3">
                                <div className="icon-box d-flex">
                                    <div className="icon-box-content">
                                        <h3 className="card-title text-uppercase text-dark">
                                            <FontAwesomeIcon icon={faMedal} />
                                            &nbsp;Quality guarantee
                                        </h3>
                                        <p>
                                            Best quality products to our customers.
                                        </p>
                                    </div>
                                </div>
                            </Col>
                            <Col lg={3} md={6} className="pb-3">
                                <div className="icon-box d-flex">
                                    <div className="icon-box-content">
                                        <h3 className="card-title text-uppercase text-dark">
                                            <FontAwesomeIcon icon={faTag} />
                                            &nbsp;Daily offers
                                        </h3>
                                        <p>
                                            Get exciting offers every day on different products by subscribing to our newsletter.
                                        </p>
                                    </div>
                                </div>
                            </Col>
                            <Col lg={3} md={6}>
                                <div className="icon-box d-flex">
                                    <div className="icon-box-content">
                                        <h3 className="card-title text-uppercase text-dark">
                                            <FontAwesomeIcon icon={faCreditCard} />
                                            &nbsp;100% secure payment
                                        </h3>
                                        <p>
                                            100% secure payment options including credit card, debit card, and PayPal.
                                        </p>
                                    </div>
                                </div>
                            </Col>
                        </Row>
                    </Container>
                </section>
                <section
                    id="yearly-sale"
                    className="bg-white padding-xlarge"
                >
                    <Row className="d-flex flex-wrap align-items-center">
                        <Col md={6} sm={12}>
                            <div className="text-content offset-4 padding-medium">
                                <h3>10% off</h3>
                                <h2 className="display-2 pb-5 text-uppercase text-dark">New year sale</h2>
                                <Button href="#" className="btn btn-medium btn-dark text-uppercase btn-rounded-none">
                                    Shop Sale
                                </Button>
                            </div>
                        </Col>
                        <Col md={6} sm={12}>
                            <img
                                src={YearlyBanner}
                                alt="Yearly Sale"
                                className="img-fluid"
                            />
                        </Col>
                    </Row>
                </section>
                <section id="subscribe" className="container-grid padding-xlarge position-relative text-dark bg-light">
                    <Container>
                        <Row>
                            <Col md={6} sm={12}>
                                <h2 className="text-uppercase">Subscribe To Our Newsletter</h2>
                                <p>Get latest news, updates and deals directly mailed to your inbox.</p>
                            </Col>
                            <Col md={6} sm={12}>
                                <form className="d-flex">
                                    <input
                                        type="email"
                                        className="form-control"
                                        placeholder="Enter your email"
                                    />
                                    <Button
                                        type="submit"
                                        className="btn btn-dark btn-medium text-uppercase btn-rounded-none ms-2"
                                    >
                                        Subscribe
                                    </Button>
                                </form>
                            </Col>
                        </Row>
                    </Container>
                </section>
                <HomeFooter />
            </HomeLayout>
        </>
    );
}
export default App;