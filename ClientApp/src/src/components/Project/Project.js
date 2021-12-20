import { Card, Nav, Button, Container, Row, Col, Image, Modal, Form, ListGroup, ProgressBar } from "react-bootstrap";
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
    //DETAILS
    const [showDetailModal, setShowDetailModal] = useState(false);
    const handleCloseDetail = () => setShowDetailModal(false);
    const handleShowDetail = () => setShowDetailModal(true);
    //INVITE MEMBER
    const [showInviteModal, setShowInviteModal] = useState(false);
    const handleCloseInvite = () => setShowInviteModal(false);
    const handleShowInvite = () => setShowInviteModal(true);
    //NEW TASK
    const [showTaskModal, setShowTaskModal] = useState(false);
    const handleCloseTask = () => setShowTaskModal(false);
    const handleShowTask = () => setShowTaskModal(true);

    return(
        <>
            <>
                <Modal show={showTaskModal} onHide={handleCloseTask}>
                    <Modal.Header closeButton>
                    <Modal.Title>New Task</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <ListGroup variant="flush">
                            <ListGroup.Item>
                                <Form.Control type="text" placeholder="Title"/>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="text" placeholder="Description"/>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Control type="date" placeholder="Deadline"/>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Select aria-label="Default select example">
                                    <option disabled selected>Type</option>
                                    <option value="1">Task</option>
                                    <option value="2">Bug</option>
                                </Form.Select>
                            </ListGroup.Item>
                            <ListGroup.Item>
                                <Form.Select aria-label="Default select example">
                                    <option disabled selected>Assign To</option>
                                    <option value="1">John Doe</option>
                                    <option value="2">Jane Doe</option>
                                </Form.Select>
                            </ListGroup.Item>
                        </ListGroup>
                    </Modal.Body>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseTask}>Close</Button>
                    <Button variant="primary" onClick={handleCloseTask}>Add</Button>
                    </Modal.Footer>
                </Modal>
            </>
            <>
                <Modal show={showInviteModal} onHide={handleCloseInvite}>
                    <Modal.Header closeButton>
                    <Modal.Title>Invite Member</Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                        <ListGroup variant="flush">
                            <ListGroup.Item>
                                <Form.Control type="email" placeholder="Email"/>
                            </ListGroup.Item>
                        </ListGroup>
                    </Modal.Body>
                    <Modal.Footer>
                    <Button variant="secondary" onClick={handleCloseInvite}>Close</Button>
                    <Button variant="primary" onClick={handleCloseInvite}>Send</Button>
                    </Modal.Footer>
                </Modal>
            </>
            <>
                <Modal show={showDetailModal} fullscreen={true} onHide={handleCloseDetail}>
                    <Modal.Header closeButton>
                    <Modal.Title>
                        {project.projectName}
                    </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>
                    <Container>
                        <Row xs={1} md={2}>
                            <Col>
                                <Card>
                                    <Card.Header as="h5">Demo Task</Card.Header>
                                        <Card.Body>
                                            <ListGroup variant="flush">
                                                <ListGroup.Item>
                                                    <ProgressBar label={"In-Progress"} variant="info" now={100} />
                                                </ListGroup.Item>
                                                <ListGroup.Item>
                                                    Tile: Demo Task
                                                </ListGroup.Item>
                                                <ListGroup.Item>
                                                    Description: Demo Description
                                                </ListGroup.Item>
                                                <ListGroup.Item>
                                                    Type: Task
                                                </ListGroup.Item>
                                                <ListGroup.Item>
                                                    Assigned To: John Doe
                                                </ListGroup.Item>
                                                <ListGroup.Item>
                                                    Deadline: 12/22/2021
                                                </ListGroup.Item>
                                            </ListGroup>
                                        </Card.Body>
                                        <Card.Footer className="card text-right">
                                            <Button variant="primary">Mark as Complete</Button>
                                            <div style={{'padding-bottom':'20px'}}/>
                                            <Button variant="warning">Mark as In-Progress</Button>
                                        </Card.Footer>
                                </Card>
                            </Col>
                        </Row>
                    </Container>
                    </Modal.Body>
                    <Modal.Footer>
                        <div className="justify-content-end">
                            <Button variant="primary" onClick={handleShowTask}>New Task</Button>
                            <Button variant="primary" onClick={handleShowInvite}>Invite Member</Button>
                        </div>
                        <div style={{'width':'200px'}}>
                            <ProgressBar label={"Complete"} striped animated variant="success" now={50} />
                            <ProgressBar label={"In-Progress"} striped animated variant="info" now={60} />
                            <ProgressBar label={"To-Do"} striped animated variant="warning" now={70} />
                        </div>
                    </Modal.Footer>
                </Modal>
            </>
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
                         <Button variant="outline-primary" onClick={handleShowDetail}>Details</Button>
                         <div style={{'padding-bottom':'20px'}}></div>
                         <Button variant="outline-success" onClick={handleShowEdit}>Edit</Button>
                         <div style={{'padding-bottom':'20px'}}></div>
                         <Button variant="outline-danger" onClick={()=>{deleteProject(API+"Project/delete?projectId="+project.id,localStorage.getItem("token"))}}>Delete</Button>
                    </Card.Footer>
            </Card>
        </>
    );
};
