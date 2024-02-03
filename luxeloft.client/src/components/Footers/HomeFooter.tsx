import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faFacebook, faInstagram, faTwitter } from '@fortawesome/free-brands-svg-icons';
import { Container, Row, Col } from 'react-bootstrap';

const HomeFooter = () => {
  return (
    <footer className="bg-dark text-light py-4">
      <Container>
        <Row>
          <Col xs={12} md={4}>
            <h5>About</h5>
            <p>
              LuxeLoft is a luxury fashion brand that offers a wide range of luxurious clothes and fashion items to help you create the perfect living space.
            </p>
          </Col>
          <Col xs={12} md={4}>
            <h5>Contact</h5>
            <address>
              <p>Email: info@luxeloft.com</p>
              <p>Phone: +1 (123) 456-7890</p>
            </address>
          </Col>
          <Col xs={12} md={4}>
            <h5 className='footer-header'>Social Media</h5>
            <a className='footer-social-link' href="#"><FontAwesomeIcon icon={faFacebook} /></a>
            <a className='footer-social-link' href="#"><FontAwesomeIcon icon={faInstagram} /></a>
            <a className='footer-social-link' href="#"><FontAwesomeIcon icon={faTwitter} /></a>
          </Col>
        </Row>
      </Container>
    </footer>
  );
};
export default HomeFooter;