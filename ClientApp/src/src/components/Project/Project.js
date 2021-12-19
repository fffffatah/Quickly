import { Card, Nav, Button, Container, Row, Col, Image } from "react-bootstrap";

export default function Project({project}) {
    return(
        <>
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
                                    <Button variant="danger">Delete</Button>
                                </Col>
                            </Row>
                        </Container>
                    </Card.Footer>
            </Card>
        </>
    );
};
