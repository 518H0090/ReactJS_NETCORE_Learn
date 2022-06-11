import React, { useState } from "react";

const defaultImageSrc = "img/images.jfif";

const initialFieldValues = {
  employeeId: 0,
  employeeName: "",
  occupation: "",
  imageName: "",
  imageSrc: defaultImageSrc,
  imageFile: null,
};

export default function Employee() {
  const [values, setValues] = useState(initialFieldValues);

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setValues({
      ...values,
      [name]: value,
    });
  };

  const showPreview = (e) => {
    if (e.target.files && e.target.files[0]) {
      let imageFile = e.target.files[0];
      const reader = new FileReader();
      reader.onload = (x) => {
        setValues({
          ...values,
          imageFile,
          imageSrc: x.target.result,
        });
      };
      reader.readAsDataURL(imageFile);
    } else {
      setValues({
        ...values,
        imageFile: null,
        imageSrc: defaultImageSrc,
      });
    }
  };

  return (
    <div>
      <div className="container text-center">
        <p className="lead">An Employee</p>
      </div>
      <form autoComplete="off" noValidate>
        <div className="card">
          <img
            src={values.imageSrc}
            className="card-img-top"
            alt=""
            style={{ width: "120px", marginLeft: "100px" }}
          />
          <div className="card-body">
            <div className="form-group">
              <input
                type="file"
                accept="image/*"
                className="form-control-file"
                onChange={showPreview}
              />
            </div>

            <div className="form-group">
              <input
                className="form-control"
                placeholder="Employee Name"
                name="employeeName"
                value={values.employeeName}
                onChange={handleInputChange}
              />
            </div>
            <div className="form-group">
              <input
                className="form-control"
                placeholder="Occupation"
                name="occupation"
                value={values.occupation}
                onChange={handleInputChange}
              />
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}
