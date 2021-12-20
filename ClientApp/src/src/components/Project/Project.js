import { Card, Nav, Button, Container, Row, Col, Image, Modal, Form, ListGroup } from "react-bootstrap";
import { API } from "../../config";
import { useState } from "react";
import axios from "axios";

export default function Project({project}) {
    //DELETE PROJECT
    const deleteProject = (url, token) => {
        axios.get(url, { headers: { 'Access-Control-Allow-Origin': '*', 'Accept' : 'application/json', 'TOKEN':token } })
        .then((response)=>{console.log(response.data)})
        .catch((error)=>{handleShowDelete();});
    }
    const [showDeleteModal, setShowDeleteModal] = useState(false);
    const handleCloseDelete = () => setShowDeleteModal(false);
    const handleShowDelete = () => setShowDeleteModal(true);
    //EDIT PROJECT
    const [showEditModal, setShowEditModal] = useState(false);
    const handleCloseEdit = () => setShowEditModal(false);
    const handleShowEdit = () => setShowEditModal(true);
    const [projectName, setProjectName] = useState('');
    const [projectDetail, setProjectDetail] = useState('');
    const [projectImage, setProjectImage] = useState(null);
    

    return(
        <>
            <>
                <Modal show={showEditModal} onHide={handleCloseEdit}>
                    <Modal.Header closeButton>
                    <Modal.Title>{project.projectName}</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <ListGroup variant="flush">
                            <ListGroup.Item>
                                <Image roundedCircle src={projectImage?URL.createObjectURL(projectImage):project.projectImageUrl} height="150px" width="150px" fluid/>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="file" name="file" id="file" onChange={(event) => setProjectImage(event.target.files[0])} placeholder="Project Image" accept="image/*"/>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="text" onChange={(event) => setProjectName(event.target.value)} value={project.projectName} placeholder="Project Name"/>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="text" onChange={(event) => setProjectDetail(event.target.value)} value={project.projectDetails} placeholder="Project Details"/>
                            </ListGroup.Item>
                        </ListGroup>
                    </Modal.Body>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseEdit}>Close</Button>
                    <Button variant="primary" onClick={handleCloseEdit}>Update</Button>
                    </Modal.Footer>
                </Modal>
            </>
            <Modal show={showDeleteModal} onHide={handleCloseDelete}>
                <Modal.Header closeButton>
                <Modal.Title>Failed</Modal.Title>
                </Modal.Header>
                <Modal.Body>You Do Not Have Permission to Delete this Project!</Modal.Body>
                <Modal.Footer>
                <Button variant="secondary" onClick={handleCloseDelete}>
                    Close
                </Button>
                </Modal.Footer>
            </Modal>
            <Card>
                <Card.Header as="h5">{project.projectName}</Card.Header>
                    <Card.Body>
                        <Container>
                            <Row xs={1} md={2}>
                                <Col>
                                    <Image src={project.projectImageUrl} height="120px" width="120px" roundedCircle/>
                                </Col>
                                <Col>
                                    <Card.Text style={{'padding-left':'15px'}}>
                                        <div style={{'font-family':'Segoe UI'},{'color':'grey'}}>
                                            {project.projectDetails}
                                        </div>
                                    </Card.Text>
                                </Col>
                            </Row>
                        </Container>
                    </Card.Body>
                    <Card.Footer className="card text-right">
                         <Button variant="outline-primary">Details</Button>
                         <div style={{'padding-bottom':'20px'}}></div>
                         <Button variant="outline-success" onClick={handleShowEdit}>Edit</Button>
                         <div style={{'padding-bottom':'20px'}}></div>
                         <Button variant="outline-danger" onClick={()=>{deleteProject(API+"Project/delete?projectId="+project.id,localStorage.getItem("token"))}}>Delete</Button>
                    </Card.Footer>
            </Card>
        </>
    );
};
