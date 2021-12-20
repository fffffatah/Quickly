import { Modal, Container, Row, Col, Nav } from "react-bootstrap";
import { useState } from "react";

export default function MyProjDetails({show}) {
    const [showDetailModal, setShowDetailModal] = useState(show?false:show);
    const handleCloseDetail = () => setShowDetailModal(false);
    const handleShowDetail = () => setShowDetailModal(true);
    return(
        <>
            <Modal show={showDetailModal} fullscreen={true} onHide={handleCloseDetail}>
                <Modal.Header closeButton>
                <Modal.Title>
                    ProjectName
                </Modal.Title>
                </Modal.Header>
                <Modal.Body>
                <Container>
                    <Row xs={1} md={2}>
                        
                    </Row>
                </Container>
                </Modal.Body>
                <Modal.Footer>
                    <Nav.Link>
                        Download Grade Report
                    </Nav.Link>
                </Modal.Footer>
            </Modal>
        </>
    );
};
