import { Button, Container, Col, Row } from 'react-bootstrap';
import { Swiper, SwiperSlide } from 'swiper/react';
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
                <section id="home" className="position-relative overflow-hidden bg-light-blue">
                    <Swiper className="main-swiper">
                        <SwiperSlide>
                            <Container>
                                <Row className="d-flex align-items-center">
                                    <Col md={6}>
                                        <div className="banner-content">
                                            <h1 className="display-2 text-uppercase text-dark pb-5">
                                                New Year Sale
                                            </h1>
                                            <Button href="#" className="btn-medium btn-dark text-uppercase btn-rounded-none">
                                                Shop Product
                                            </Button>
                                        </div>
                                    </Col>
                                </Row>
                            </Container>
                        </SwiperSlide>
                        <SwiperSlide>
                            <Container>
                                <Row className="d-flex flex-wrap align-items-center">
                                    <Col md={6}>
                                        <div className="banner-content">
                                            <h1 className="display-2 text-uppercase text-dark pb-5">Technology Hack You Won't Get</h1>
                                            <Button href="shop.html" className="btn-medium btn-dark text-uppercase btn-rounded-none">
                                                Shop Product
                                            </Button>
                                        </div>
                                    </Col>
                                    <Col md={5}>
                                        <div className="image-holder">
                                            <img src="images/banner-image.png" alt="banner" />
                                        </div>
                                    </Col>
                                </Row>
                            </Container>
                        </SwiperSlide>
                    </Swiper>
                    <div className="swiper-icon swiper-arrow swiper-arrow-prev">
                        <svg className="chevron-left">
                            <use xlinkHref="#chevron-left" />
                        </svg>
                    </div>
                    <div className="swiper-icon swiper-arrow swiper-arrow-next">
                        <svg className="chevron-right">
                            <use xlinkHref="#chevron-right" />
                        </svg>
                    </div>
                </section>
                <section id="company-services" className="padding-large">
                    <Container>
                        <Row>
                            <Col lg={3} md={6} className="pb-3">
                                <div className="icon-box d-flex">
                                    <div className="icon-box-icon pe-3 pb-3">
                                        {/* Replace the SVG below with your actual SVG component */}
                                        <svg className="cart-outline">
                                            <use xlinkHref="#cart-outline" />
                                        </svg>
                                    </div>
                                    <div className="icon-box-content">
                                        <h3 className="card-title text-uppercase text-dark">Free delivery</h3>
                                        <p>Consectetur adipi elit lorem ipsum dolor sit amet.</p>
                                    </div>
                                </div>
                            </Col>
                            <Col lg={3} md={6} className="pb-3">
                                <div className="icon-box d-flex">
                                    <div className="icon-box-icon pe-3 pb-3">
                                        {/* Replace the SVG below with your actual SVG component */}
                                        <svg className="quality">
                                            <use xlinkHref="#quality" />
                                        </svg>
                                    </div>
                                    <div className="icon-box-content">
                                        <h3 className="card-title text-uppercase text-dark">Quality guarantee</h3>
                                        <p>Dolor sit amet orem ipsu mcons ectetur adipi elit.</p>
                                    </div>
                                </div>
                            </Col>
                            <Col lg={3} md={6} className="pb-3">
                                <div className="icon-box d-flex">
                                    <div className="icon-box-icon pe-3 pb-3">
                                        {/* Replace the SVG below with your actual SVG component */}
                                        <svg className="price-tag">
                                            <use xlinkHref="#price-tag" />
                                        </svg>
                                    </div>
                                    <div className="icon-box-content">
                                        <h3 className="card-title text-uppercase text-dark">Daily offers</h3>
                                        <p>Amet consectetur adipi elit loreme ipsum dolor sit.</p>
                                    </div>
                                </div>
                            </Col>
                            <Col lg={3} md={6} className="pb-3">
                                <div className="icon-box d-flex">
                                    <div className="icon-box-icon pe-3 pb-3">
                                        {/* Replace the SVG below with your actual SVG component */}
                                        <svg className="shield-plus">
                                            <use xlinkHref="#shield-plus" />
                                        </svg>
                                    </div>
                                    <div className="icon-box-content">
                                        <h3 className="card-title text-uppercase text-dark">100% secure payment</h3>
                                        <p>Rem Lopsum dolor sit amet, consectetur adipi elit.</p>
                                    </div>
                                </div>
                            </Col>
                        </Row>
                    </Container>
                </section>
                <section
                    id="yearly-sale"
                    className="bg-light-blue overflow-hidden mt-5 padding-xlarge"
                    style={{ backgroundImage: "url('images/single-image1.png')", backgroundPosition: 'right', backgroundRepeat: 'no-repeat' }}
                >
                    <Row className="d-flex flex-wrap align-items-center">
                        <Col md={6} sm={12}>
                            <div className="text-content offset-4 padding-medium">
                                <h3>10% off</h3>
                                <h2 className="display-2 pb-5 text-uppercase text-dark">New year sale</h2>
                                <Button href="shop.html" className="btn btn-medium btn-dark text-uppercase btn-rounded-none">
                                    Shop Sale
                                </Button>
                            </div>
                        </Col>
                        <Col md={6} sm={12}></Col>
                    </Row>
                </section>
                <section id="subscribe" className="container-grid padding-medium position-relative overflow-hidden">
                    <Container>
                        <Row>
                            <div className="subscribe-content bg-dark d-flex flex-wrap justify-content-center align-items-center padding-medium">
                                <Col md={6}>
                                    <div className="display-header pe-3">
                                        <h2 className="display-7 text-uppercase text-light">Subscribe Us Now</h2>
                                        <p>Get latest news, updates and deals directly mailed to your inbox.</p>
                                    </div>
                                </Col>
                            </div>
                        </Row>
                    </Container>
                </section>
                <HomeFooter />
            </HomeLayout>
        </>
    );
}
export default App;