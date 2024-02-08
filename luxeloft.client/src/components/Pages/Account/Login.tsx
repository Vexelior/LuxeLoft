import HomeLayout from '../../Layouts/HomeLayout';
import HomeFooter from '../../Footers/HomeFooter';
import HomeNavbar from '../../Navbars/HomeNavbar';
import { useEffect, useState } from 'react';
import { Container, Row, Col } from 'react-bootstrap';
import axios from 'axios';
import '../../../App.css'

function Login() {
    const [email, setEmail] = useState("");
    const [password, setPassword] = useState("");
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    const apiURL = 'https://localhost:7274/api/Account/Login';

    async function login(e: unknown) {
        e.preventDefault();
        setError("");
        setLoading(true);
        if (email === "" || password === "") {
            setError("Please fill in all fields.");
            setLoading(false);
            return;
        }
        axios.post(apiURL, {
            email: email,
            password: password
        }).then(response => {
            console.log(response);
            if (response.status === 200) {
                localStorage.setItem("token", response.data.token);
                window.location.href = "/";
            }
        }).catch(error => {
            console.log(error);
            setError("Invalid email or password. Please try again.");
        });
        setLoading(false);
    }

    useEffect(() => {
        document.title = "Login - Luxeloft";
    }, []);

    return (
        <HomeLayout>
            <HomeNavbar />
            <section className="padding-medium bg-light login-section">
                <Container className='login-container'>
                    <Row>
                        <Col>
                            <h2 className="text-center mb-4">Login</h2>
                            {error && <div className="alert alert-danger">{error}</div>}
                            <form onSubmit={login}>
                                <div className="form-group">
                                    <label>Email</label>
                                    <input type="email" className="form-control" onChange={e => setEmail(e.target.value)} />
                                </div>
                                <div className="form-group">
                                    <label>Password</label>
                                    <input type="password" className="form-control" onChange={e => setPassword(e.target.value)} />
                                </div>
                                <button disabled={loading} type="submit" className="btn btn-primary w-100 mt-3">Login</button>
                            </form>
                        </Col>
                    </Row>
                </Container>
            </section>
            <HomeFooter />
        </HomeLayout>
    );
}
export default Login;