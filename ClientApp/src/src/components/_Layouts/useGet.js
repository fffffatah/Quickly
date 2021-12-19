import { useEffect } from "react";
import axios from "axios";

export default function useGet (url, token, callback){

    const getDashboard = async () => {
        await axios.get(url, { headers: { 'Access-Control-Allow-Origin': '*', 'Accept' : 'application/json', 'TOKEN':token } })
        .then((response)=>{callback(response.data)})
        .catch((error)=>{console.log('ERROR: '+error)});
    }

    useEffect(()=>{
        getDashboard();
    }, [])
}