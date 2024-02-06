import { Navbar, Nav, Container, Dropdown } from 'react-bootstrap';
import { Link } from "react-router-dom";
import Logo from '../../assets/images/logo.png';

function HomeLayout() {
    return (
        <Navbar id='header-nav' bg="dark" variant="dark" expand="lg" sticky="top" className="navbar navbar-expand-lg px-3 mb-0">
            <Container fluid>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Brand href="#home">
                    <img src={Logo} alt="LuxeLoft" className="img-fluid nav-logo" />
                </Navbar.Brand>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto text-uppercase">
                        <Link to="/" className="nav-link me-4">Home</Link>
                        <Dropdown>
                            <Dropdown.Toggle variant="dark" id="dropdown-basic" className='text-uppercase me-4'>
                                Products
                            </Dropdown.Toggle>
                            <Dropdown.Menu>
                                <Link to="all" className="dropdown-item">All</Link>
                                <Dropdown.Item href="#">Men's</Dropdown.Item>
                                <Dropdown.Item href="#">Women's</Dropdown.Item>
                                <Dropdown.Item href="#">Kid's</Dropdown.Item>
                                <Dropdown.Item href="#">Tech</Dropdown.Item>
                                <Dropdown.Item href="#">Best Sellers</Dropdown.Item>
                            </Dropdown.Menu>
                        </Dropdown>
                        <Nav.Link href="#yearly-sale" className="me-4">Sale</Nav.Link>
                        <Nav.Link href="#yearly-sale" className="me-4">Explore</Nav.Link>
                        <Nav.Link href="#subscribe" className="me-4">Contact</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}
export default HomeLayout;