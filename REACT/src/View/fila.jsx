import React, { useState } from "react";

export const ImageUploader = () => {
  const [selectedImage, setSelectedImage] = useState(null);

  const handleImageUpload = (event) => {
    const file = event.target.files[0];
    setSelectedImage(URL.createObjectURL(file));
    // Aquí puedes realizar la lógica para enviar la imagen al servidor
  };

  return (
    <div>
      <input type="file" onChange={handleImageUpload} />

      {selectedImage && 

      <img src={selectedImage} alt="Selected" />
      
      }
    </div>
  );
};