import React, { useEffect, useState } from "react";
import QRCode from "react-qr-code";

export const GeneraQR = ({Codigo}) => {
  const Dominio = "http://localhost:5173/"
  const [decodedToken, setDecodedToken] = useState(null);

  useEffect(() => {
    try {
      setDecodedToken(Dominio+Codigo);
    } catch (error) {
      console.error("Error al decodificar el token:", error);
      setDecodedToken(null);
    }
  }, [Codigo]);
  console.log(decodedToken)

  return (
    <>
        {decodedToken && (
            <QRCode className="w-full" value={(decodedToken)}/>
        )}
    </>
    
    
  )
}