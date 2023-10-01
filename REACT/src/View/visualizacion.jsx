import { useParams } from "react-router-dom";
import React, { useEffect, useState } from "react";
import QRCode from "react-qr-code";

export const CodigoQR = () => {
  const { Pk } = useParams();
  const [decodedToken, setDecodedToken] = useState(null);

  useEffect(() => {
    try {
      
      setDecodedToken(Pk);
    } catch (error) {
      console.error("Error al decodificar el token:", error);
      setDecodedToken(null);
    }
  }, [Pk]);

  const containerStyle = {
    display: "flex",
    justifyContent: "center",
    alignItems: "center", // Centrar verticalmente y horizontalmente
    minHeight: "100vh",
    backgroundColor: "#f3f3f3",
  };

  const leftColumnStyle = {
    display: "flex",
    flexDirection: "column",
    alignItems: "center", // Centrar horizontalmente
  };

  const qrCodeContainerStyle = {
    backgroundColor: "#fff",
    padding: "20px",
    borderRadius: "5px",
    boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
    minWidth: "250px", // Ancho mínimo para evitar que se comprima demasiado
    width: "300px", // Ancho deseado para el código QR
  };

  const detailsContainerStyle = {
    display: "grid",
    gap: "30px", // Aumentar la separación de 30px entre los cuadros de detalles
    gridTemplateColumns: "1fr 1fr", // Dos columnas en la sección de detalles
    marginTop: "50px", // Aumentar el espacio entre la descripción y los detalles
    width: "800px", // Aumentar el tamaño de la sección de detalles
  };

  const descriptionStyle = {
    backgroundColor: "#fff",
    padding: "20px",
    borderRadius: "5px",
    boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
    marginTop: "50px", // Separación entre el código QR y la descripción
    width: "800px", // Ancho deseado para la descripción
  };

  const detailBoxStyle = {
    backgroundColor: "#fff",
    padding: "20px", // Reducir el padding para hacer los cuadros más pequeños
    borderRadius: "5px",
    boxShadow: "0 2px 4px rgba(0, 0, 0, 0.1)",
    width: "350px", // Reducir el tamaño de cada cuadro de detalles
  };

  const importantDetailStyle = {
    ...detailBoxStyle,
    backgroundColor: "#ff8c00",
    color: "#fff",
  };

  // Estilo especial para "Detalles del Responsable" más largo
  const longDetailStyle = {
    ...detailBoxStyle,
    width: "700px", // Aumentar el tamaño para hacerlo más largo
  };

  // Media query para pantallas más pequeñas
  const mediaQuery = `@media (max-width: 768px)`;

  return (
    <div style={containerStyle}>
      {decodedToken ? (
        <div style={leftColumnStyle}>
          <div style={qrCodeContainerStyle}>
            <QRCode value={JSON.stringify(decodedToken)} size={250} />
          </div>

          <div style={descriptionStyle}>
            <h2>Descripción:</h2>
            <p>Pk: {decodedToken.pk}</p>
            <p>Nombre: {decodedToken.nombre}</p>
            <p>Categoria: {decodedToken.categoria}</p>
          </div>
        </div>
      ) : (
        <p>Token no válido.</p>
      )}

      {decodedToken && (
        <div style={{ ...detailsContainerStyle, ...leftColumnStyle }}>
          <div style={{ display: "flex" }}>
            <div style={{ ...importantDetailStyle, marginRight: "2cm" }}>
              <p>Categoría: {decodedToken.categoria}</p>
            </div>
            <div style={importantDetailStyle}>
              <p>Proveedor: {decodedToken.Proveedor}</p>
            </div>
          </div>

          <div style={{ display: "flex" }}>
            <div style={{ ...detailBoxStyle, marginRight: "2cm" }}>
              <p>Marca: {decodedToken.Marca}</p>
            </div>
            <div style={detailBoxStyle}>
              <p>Modelo: {decodedToken.Modelo}</p>
            </div>
          </div>

          <div style={{ display: "flex" }}>
            <div style={{ ...detailBoxStyle, marginRight: "2cm" }}>
              <p>Área: {decodedToken.area}</p>
            </div>
            <div style={detailBoxStyle}>
              <p>Costo: {decodedToken.costo}</p>
            </div>
          </div>

          <div style={{ display: "flex" }}>
            <div style={longDetailStyle}>
              <p>Detalles del Responsable:</p>
              <p>{decodedToken["detalles del responsable"]}</p>
            </div>
          </div>

          <div style={{ display: "flex" }}>
            <div style={{ ...detailBoxStyle, marginRight: "2cm" }}>
              <p>Responsable: {decodedToken.responsable}</p>
            </div>
            <div style={detailBoxStyle}>
              <p>Rol: {decodedToken.rol}</p>
            </div>
          </div>
        </div>
      )}
    </div>
  );
};
