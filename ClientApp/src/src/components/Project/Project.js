import { Card, Nav, Button, Container, Row, Col, Image, Modal } from "react-bootstrap";
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

    return(
        <>
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
                        <Container>
                            <Row xs={1} md={3}>
                                <Col>
                                    <Button variant="primary">Details</Button>
                                </Col>
                                <Col>
                                    <Button variant="success">Edit</Button>   
                                </Col>
                                <Col>
                                    <Button variant="danger" onClick={()=>{deleteProject(API+"Project/delete?projectId="+project.id,localStorage.getItem("token"))}}>Delete</Button>
                                </Col>
                            </Row>
                        </Container>
                    </Card.Footer>
            </Card>
        </>
    );
};
