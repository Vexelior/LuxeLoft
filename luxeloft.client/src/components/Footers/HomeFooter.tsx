import { Container, Row, Col } from 'react-bootstrap';

const HomeFooter = () => {
  return (
    <footer className="bg-dark text-light py-4">
      <Container>
        <Row>
          <Col xs={12} md={6}>
            {/* Content (e.g., company information, links, etc.) */}
            <h5>LuxeLoft</h5>
            <p>Explore the world of luxury living.</p>
          </Col>
          <Col xs={12} md={6}>
            {/*Content (e.g., contact information, social media links, etc.) */}
            <h5>Contact Us</h5>
            <address>
              <p>Email: info@luxeloft.com</p>
              <p>Phone: +1 (123) 456-7890</p>
            </address>
          </Col>
        </Row>
      </Container>
    </footer>
  );
};

export default HomeFooter;