import { API } from "../../config";
import axios from "axios";
import DefaultImage from "../../assets/DefaultPage.png";
import { useNavigate } from "react-router-dom";
import { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Container, Col, Row, Image, Button } from "react-bootstrap";

export default function VerifyUser() {
    document.title = "Quickly - User Verification";
    const navigate = useNavigate();
    const {id} = useParams();
    const handleShow = ()=>{
        navigate('/');
    }
    useEffect(()=>{
        axios.get(API+"User/verify?id="+id, { headers: { 'Access-Control-Allow-Origin': '*', 'Accept' : 'application/json' } })
        .then((response)=>{console.log(response);})
        .catch((error)=>{alert("Invalid URL Access")});
    }, [])
    return(
        <>
            <Container>
                <Row xs={1} md={2}>
                    <Col><Image src={DefaultImage} height="300px" width="300px" fluid/></Col>
                    <Col>
                        <div style={{'font-family':'Segoe UI'},{'color':'#3B8CF5'}}>
                            <h1 style={{'padding-top':'50px'}}><b>Registered Successfully, Please Login</b></h1>
                        </div>
                        <div  style={{'padding-top':'55px'}}>
                            <Button variant="outline-primary" size="lg" onClick={handleShow}>Go to Login</Button>
                        </div>
                    </Col>
                </Row>
            </Container>
        </>
    );
};
