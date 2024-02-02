import { Navbar, Nav, Container } from 'react-bootstrap';

function HomeLayout() {
    return (
        <Navbar id='header-nav' bg="light" variant="light" expand="lg" sticky="top" className="navbar navbar-expand-lg px-3 mb-0">
            <Container fluid>
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="ml-auto text-uppercase">
                        <Nav.Link href="#home" className="me-4 active">Home</Nav.Link>
                        <Nav.Link href="#company-services" className="me-4">Services</Nav.Link>
                        <Nav.Link href="#yearly-sale" className="me-4">Sale</Nav.Link>
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}
export default HomeLayout;