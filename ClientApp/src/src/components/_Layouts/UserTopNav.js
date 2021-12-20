import IconImage from "../../assets/Icon.png";
import ProfilePlaceholder from "../../assets/Profile.png";
import { Container, Navbar, NavItem, Image, NavDropdown, Modal, Button, ListGroup, Form, FormLabel, Row, Col } from "react-bootstrap";
import useGet from "./useGet";
import { useState } from "react";
import { API } from "../../config";
import { useNavigate } from "react-router-dom";
import Project from "../Project/Project";
import axios from "axios";
import { useEffect } from "react";

export default function UserTopNav() {
    document.title = "Quickly";
    const [user, setUser] = useState('');
    const [projectsOwner, setProjectsOwner] = useState([]);
    const [projectsMember, setProjectsMember] = useState([]);
    const navigate = useNavigate();
    const getMyProjects = (url, token, callback) => {
        axios.get(url, { headers: { 'Access-Control-Allow-Origin': '*', 'Accept' : 'application/json', 'TOKEN':token } })
        .then((response)=>{callback(response.data)})
        .catch((error)=>{console.log('ERROR: '+error)});
    }
    useEffect(()=>{
        getMyProjects(API+"User/get/one", localStorage.getItem("token"), setUser);
        for (let index = 0; index < 10000; index++) {
            console.log(index);
        }
    }, [])
    useEffect(()=>{
        getMyProjects(API+"Project/get/for/owner", localStorage.getItem("token"), setProjectsOwner);
        for (let index = 0; index < 10000; index++) {
            console.log(index);
        }
    }, [])
    useEffect(()=>{
        getMyProjects(API+"Project/get/for/member", localStorage.getItem("token"), setProjectsMember);
        for (let index = 0; index < 10000; index++) {
            console.log(index);
        }
    }, [])
    //EDIT PROFILE
    const [showEdit, setShowEdit] = useState(false);
    const handleCloseEdit = () => setShowEdit(false);
    const handleShowEdit = () => setShowEdit(true);
    const [profileImage, setProfileImage] = useState(null);
    const [fullName, setFullName] = useState("");
    const [errFullName, setErrFullName] = useState("");
    const onEditValidation = async () => {
        if (fullName === "") {
            setErrFullName("* Full Name Required");
        } else {
            setErrFullName("");
            //await onRegister();
        }
    };
    //LOGOUT
    const handleLogout = ()=>{
        localStorage.removeItem("token");
        navigate("/");
    }
    return(
        <>
            <>
                <Modal show={showEdit} onHide={handleCloseEdit}>
                    <Modal.Header closeButton>
                    <Modal.Title>{user.fullName}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <ListGroup variant="flush">
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
                        </ListGroup>
                    </Modal.Body>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseEdit}>Close</Button>
                    <Button variant="primary" onClick={onEditValidation}>Edit</Button>
                    </Modal.Footer>
                </Modal>
            </>
            <Navbar collapseOnSelect="true" expand="lg" bg="light" variant="light">
                <Container>
                    <Navbar.Brand href="/home"><Image src={IconImage} height="60px" width="60px"/></Navbar.Brand>
                    <Navbar.Text><div style={{'font-family':'Segoe UI'}}><div style={{'font-size':'25px'}}><b>Quickly</b></div></div></Navbar.Text>
                    <Navbar.Toggle aria-controls="responsive-navbar-nav" />
                    <Navbar.Collapse id="responsive-navbar-nav">
                        
                    </Navbar.Collapse>
                    <Navbar.Collapse className="justify-content-end">
                            <Image src={user.profileImageUrl} height="60px" width="60px" roundedCircle/>
                        <NavItem>
                            <NavDropdown title="Profile" id="basic-nav-dropdown">
                                <NavDropdown.Item onClick={handleShowEdit}>Edit Profile</NavDropdown.Item>
                                <NavDropdown.Item onClick={handleLogout}>Logout</NavDropdown.Item>
                            </NavDropdown>
                        </NavItem>
                    </Navbar.Collapse>
                </Container>
            </Navbar>
            <div style={{'padding-top':'50px'}}>
                <div style={{'font-family':'Segoe UI'},{'color':'#3B8CF5'}}>
                    <h1 style={{'padding-left':'50px'}}><b>My Projects</b></h1>
                </div>
                <div style={{'padding-top':'20px'}}></div>
                <Container>
                    <Row xs={1} md={2}>
                            {
                                projectsOwner.length?(
                                    projectsOwner.map((project)=>{
                                        return(
                                            <Col>
                                                <Project project={project}/>
                                            </Col>
                                        );
                                    })
                                ):''
                            }
                    </Row>
                </Container>
            </div>
            <div style={{'padding-top':'50px'}}>
                <div style={{'font-family':'Segoe UI'},{'color':'#3B8CF5'}}>
                    <h1 style={{'padding-left':'50px'}}><b>Projects I am Member of</b></h1>
                </div>
                <div style={{'padding-top':'20px'}}></div>
                <Container>
                    <Row xs={1} md={2}>
                            {
                                projectsMember.length?(
                                    projectsMember.map((project)=>{
                                        return(
                                            <Col>
                                                <Project project={project}/>
                                            </Col>
                                        );
                                    })
                                ):''
                            }
                    </Row>
                </Container>
            </div>
        </>
    );
};
