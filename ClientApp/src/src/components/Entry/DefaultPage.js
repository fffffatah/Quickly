import { API } from "../../config";
import ProfilePlaceholder from "../../assets/Profile.png";
import SuccessImage from "../../assets/Success.png";
import DefaultImage from "../../assets/DefaultPage.png";
import { Container, Row, Col, Image, Button, Modal, ListGroup, Form, FormLabel, Spinner } from "react-bootstrap";
import { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

export default function DefaultPage() {
    document.title="Quickly";
    const navigate = useNavigate();
    //========================================================LOGIN======================================================
    //SHOW/CLOSE LOGIN MODAL
    const [show, setShow] = useState(false);
    const [showLoginLoading, setShowLoginLoading] = useState(true);
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);
    //LOGIN LOGIC
    const [email, setEmail] = useState("");
    const [pass, setPass] = useState("");
    const [erremail, setErrEmail] = useState("");
    const [errpass, setErrPass] = useState("");
    const [errorMessage, setErrorMessage] = useState("");
    const [remember, setRemember] = useState(false);
    //VALIDATION
    const onLoginValidation = async () => {
        if (email === "" && pass === "") {
            setErrEmail("* Email Required");
            setErrPass("* Password Required");
        } else if (email === "") {
            setErrEmail("* Email Required");
        } else if (pass === "") {
            setErrPass("* Password Required");
        } else {
            setErrEmail("");
            setErrPass("");
            setErrorMessage("");
            setShowLoginLoading(false);
            await onLogin();
        }
    };
    const onLogin = async () => {
        const formdata = new FormData();
        formdata.append("Email", email);
        formdata.append("Pass", pass);
        formdata.append("RememberMe", remember);
        await axios
          .post(API+"User/login", formdata, {
            headers: {
              "Access-Control-Allow-Origin": "*",
              "Content-Type": "multipart/form-data",
                Accept: "application/json",
            },
          })
          .then((response) => {
                setShowLoginLoading(true);
                localStorage.setItem("token", response.data.token);
                navigate('/home');
          })
          .catch((error) => {
                setShowLoginLoading(true);
                console.log("ERRRR:: ", error);
                setErrorMessage("* Invalid Credentials");
          });
      };
    //=============================================================================================================
    //=================================================FORGOT PASS============================================================
    const [showReset, setShowReset] = useState(false);
    const handleCloseReset = () => setShowReset(false);
    const handleShowReset = () => setShowReset(true);
    const [nextFlag, setNextFlag] = useState(false);
    const [resetPass, setResetPass] = useState("");
    const [errResetPass, setErrResetPass] = useState("");
    const [resetEmail, setResetEmail] = useState("");
    const [otp, setOtp] = useState("");
    const [errResetEmail, setErrResetEmail] = useState("");
    const [errOtp, setErrOtp] = useState("");
    const [errorResetMessage, setErrorResetMessage] = useState("");
    //VALIDATION
    const onResetEmailValidation = async () => {
        if (resetEmail === "") {
            setErrResetEmail("* Email Required");
        } else {
            setErrResetEmail("");
            setErrorResetMessage("");
            await onResetEmailSend();
        }
    };
    const onResetEmailSend = async (id)=>{
        axios.get(API+"User/send/otp?email="+resetEmail, { headers: { 'Access-Control-Allow-Origin': '*', 'Accept' : 'application/json' } })
        .then((response)=>{setNextFlag(true);})
        .catch((error)=>{setErrorResetMessage("* Email Doesn't Exist")});
    }
    const onPassResetValidation = async () => {
        if (otp === "" && resetPass === ""){
            setErrOtp("* OTP Required");
            setErrResetPass("* New Password Required");
        } else if (otp === "") {
            setErrOtp("* OTP Required");
        } else if (resetPass === "") {
            setErrResetPass("* New Password Required");
        } else {
            setErrOtp("");
            setErrorResetMessage("");
            axios.get(API+"User/get/token/by/otp?otp="+otp, { headers: { 'Access-Control-Allow-Origin': '*', 'Accept' : 'application/json' } })
            .then((response)=>{
                const formdata = new FormData();
                formdata.append("Pass", resetPass);
                formdata.append("ConfirmedPass", resetPass);
                axios
                .post(API+"User/reset/pass", formdata, {
                    headers: {
                        "TOKEN":response.data.resetToken,
                    "Access-Control-Allow-Origin": "*",
                    "Content-Type": "multipart/form-data",
                        Accept: "application/json",
                    },
                })
                .then((response) => {
                        setErrorResetMessage("Password Reset Successfully!");
                })
                .catch((error) => {
                        setShowLoginLoading(!showLoginLoading);
                        console.log("ERRRR:: ", error);
                        setErrorResetMessage("* Invalid OTP or Password Weak");
                });
            })
            .catch((error)=>{setErrorResetMessage("* Invalid OTP or Password Weak")});
        }
    };
    //=============================================================================================================
    //===================================================REGISTRATION==========================================================
    const [showSuccess, setShowSuccess] = useState(false);
    const [showRegister, setShowRegister] = useState(false);
    const handleCloseRegister = () => setShowRegister(false);
    const handleShowRegister = () => setShowRegister(true);
    const [profileImage, setProfileImage] = useState();
    const [fullName, setFullName] = useState("");
    const [errFullName, setErrFullName] = useState("");
    const [regEmail, setRegEmail] = useState("");
    const [errRegEmail, setErrRegEmail] = useState("");
    const [regPass, setRegPass] = useState("");
    const [errRegPass, setErrRegPass] = useState("");
    const [regPhone, setRegPhone] = useState("");
    const [errRegPhone, setErrRegPhone] = useState("");
    const [errRegMessage, setErrRegMessage] = useState("");
    //VALIDATION
    const onRegistrationValidation = () => {
        if (fullName === "" && regEmail === "" && regPass === "" && regPhone === "") {
            setErrRegEmail("* Email Required");
            setErrRegPhone("* Phone Required");
            setErrFullName("* Full Name Required");
            setErrRegPass("* Password Required");
        } else {
            setErrRegEmail("");
            setErrRegPhone("");
            setErrFullName("");
            setErrRegPass("");
            setErrRegMessage("");
            setShowLoginLoading(false);
            onRegister();
        }
    };
    const onRegister = () => {
        const formdata = new FormData();
        formdata.append("Id", 23);
        formdata.append("ProfileImageUrl", "empty");
        formdata.append("ProfileImage", profileImage);
        formdata.append("Email", regEmail);
        formdata.append("Pass", regPass);
        formdata.append("FullName", fullName);
        formdata.append("ConfirmedPass", regPass);
        formdata.append("UserType", "user");
        formdata.append("IsVerified", false);
        axios.post(API+"User/register", formdata)
          .then((response) => {
                setShowLoginLoading(true);
                console.log(response.data);
                setShowSuccess(true);
          })
          .catch((error) => {
                setShowLoginLoading(true);
                console.log(JSON.stringify(error));
                setErrRegMessage("* Couldn't Register");
          });
      };
    //=============================================================================================================
    return(
        <div style={{'padding-top':'150px'}}>
            <>
                <Modal show={showRegister} onHide={handleCloseRegister}>
                    <Modal.Header closeButton>
                    <Modal.Title>Register</Modal.Title>
                    </Modal.Header>
                    <div hidden={showSuccess}>
                    <Modal.Body>
                        <ListGroup variant="flush">
                        <center><FormLabel style={{ color: "red" }}><b>{errRegMessage}</b></FormLabel></center>
                            <ListGroup.Item>
                                <Image roundedCircle src={profileImage?URL.createObjectURL(profileImage):ProfilePlaceholder} height="150px" width="150px" fluid/>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="file" name="file" id="file" onChange={(event) => setProfileImage(event.target.files[0])} placeholder="Profile Image" accept="image/*"/>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="text" onChange={(event) => setFullName(event.target.value)} value={fullName} placeholder="Full Name"/>
                                <FormLabel style={{ color: "red" }}><b>{errFullName}</b></FormLabel>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="email" onChange={(event) => setRegEmail(event.target.value)} value={regEmail} placeholder="Email"/>
                                <FormLabel style={{ color: "red" }}><b>{errRegEmail}</b></FormLabel>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="number" onChange={(event) => setRegPhone(event.target.value)} value={regPhone} placeholder="Phone"/>
                                <FormLabel style={{ color: "red" }}><b>{errRegPhone}</b></FormLabel>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="password" onChange={(event) => setRegPass(event.target.value)} value={regPass} placeholder="Password"/>
                                <FormLabel style={{ color: "red" }}><b>{errRegPass}</b></FormLabel>
                            </ListGroup.Item>
                        </ListGroup>
                    </Modal.Body>
                    </div>
                    <div hidden={!showSuccess}>
                        <Modal.Body>
                            <Image roundedCircle src={SuccessImage} height="120px" width="120px" fluid/>
                            <div style={{'font-family':'Segoe UI'},{'color':'grey'}}>
                                <p style={{'padding-top':'5px'}}><b>Registered Successfully, Check your email for verification link!</b></p>
                            </div>
                        </Modal.Body>
                    </div>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseRegister}>Close</Button>
                    <Button variant="primary" onClick={onRegistrationValidation}><Spinner animation="border" size="sm" hidden={showLoginLoading}/> Register</Button>
                    </Modal.Footer>
                </Modal>
            </>
            <>
                <Modal show={show} onHide={handleClose}>
                    <Modal.Header closeButton>
                    <Modal.Title>Login</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <ListGroup variant="flush">
                        <center><FormLabel style={{ color: "red" }}><b>{errorMessage}</b></FormLabel></center>
                            <ListGroup.Item>
                                <Form.Control type="email" onChange={(event) => setEmail(event.target.value)} value={email} placeholder="Email"/>
                                <FormLabel style={{ color: "red" }}><b>{erremail}</b></FormLabel>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="password" onChange={(event) => setPass(event.target.value)} value={pass} placeholder="Password"/>
                                <FormLabel style={{ color: "red" }}><b>{errpass}</b></FormLabel>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Check label="Remember Me" type="checkbox" onChange={(event) => setRemember(event.target.checked)}/>
                            </ListGroup.Item>
                        </ListGroup>
                    </Modal.Body>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleClose}>Close</Button>
                    <Button variant="primary" onClick={onLoginValidation}><Spinner animation="border" size="sm" hidden={showLoginLoading}/> Login</Button>
                    </Modal.Footer>
                </Modal>
            </>
            <>
                <Modal show={showReset} onHide={handleCloseReset}>
                    <Modal.Header closeButton>
                    <Modal.Title>Reset Password</Modal.Title>
                    </Modal.Header>
                        <div hidden={nextFlag}>
                            <Modal.Body>
                                <ListGroup variant="flush">
                                <center><FormLabel style={{ color: "red" }}><b>{errorResetMessage}</b></FormLabel></center>
                                    <ListGroup.Item>
                                        <Form.Control type="email" onChange={(event) => setResetEmail(event.target.value)} value={resetEmail} placeholder="Email"/>
                                        <FormLabel style={{ color: "red" }}><b>{errResetEmail}</b></FormLabel>
                                    </ListGroup.Item>
                                </ListGroup>
                            </Modal.Body>
                        </div>
                        <div hidden={!nextFlag}>
                            <Modal.Body>
                                <ListGroup variant="flush">
                                <center><FormLabel style={{ color: "red" }}><b>{errorResetMessage}</b></FormLabel></center>
                                    <ListGroup.Item>
                                        <Form.Control type="number" onChange={(event) => setOtp(event.target.value)} value={otp} placeholder="OTP"/>
                                        <FormLabel style={{ color: "red" }}><b>{errOtp}</b></FormLabel>
                                    </ListGroup.Item>
                                    <ListGroup.Item>
                                        <Form.Control type="password" onChange={(event) => setResetPass(event.target.value)} value={resetPass} placeholder="New Password"/>
                                        <FormLabel style={{ color: "red" }}><b>{errResetPass}</b></FormLabel>
                                    </ListGroup.Item>
                                </ListGroup>
                            </Modal.Body>
                        </div>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseReset}>Close</Button><span style={{'padding-left':'15px'}}></span>
                    <Button hidden={nextFlag} variant="primary" onClick={onResetEmailValidation}>Next</Button>
                    <Button hidden={!nextFlag} variant="primary" onClick={onPassResetValidation}>Confirm</Button>
                    </Modal.Footer>
                </Modal>
            </>
            <Container>
                <Row xs={1} md={2}>
                    <Col><Image src={DefaultImage} height="300px" width="300px" fluid/></Col>
                    <Col>
                        <div style={{'font-family':'Segoe UI'},{'color':'#3B8CF5'}}>
                            <h1 style={{'padding-top':'50px'}}><b>Quickly - Project Management</b></h1>
                        </div>
                        <div style={{'font-family':'Segoe UI'},{'color':'grey'}}>
                            <p style={{'padding-top':'5px'}}><b>A simple project management tool for managing personal or large project that requires collaboration with other people</b></p>
                        </div>
                        <div  style={{'padding-top':'55px'}}>
                            <Button variant="outline-primary" size="lg" onClick={handleShow}>Login</Button><span style={{'padding-left':'15px'}}></span>
                            <Button variant="outline-success" size="lg" onClick={handleShowRegister}>Register</Button><span style={{'padding-left':'15px'}}></span>
                            <Button variant="outline-danger" size="lg" onClick={handleShowReset}>Reset Password</Button>
                        </div>
                    </Col>
                </Row>
            </Container>
        </div>
    );
};
