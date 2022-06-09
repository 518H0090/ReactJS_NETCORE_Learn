import {
  TextField,
  Button,
  Box,
  Card,
  CardContent,
  Typography,
} from "@mui/material";
import React, { useState } from "react";
import { createAPIEndpoint } from "../api";
import useForm from "../hooks/useForm";
import Center from "./Center";
import { ENDPOINTS } from "../api/index";

const getFreshModel = () => ({ name: "", email: "" });

export default function Login() {
  const { values, setValues, errors, setErrors, handleInputChange } =
    useForm(getFreshModel);

  const login = (e) => {
    e.preventDefault();
    if (validate()) {
      createAPIEndpoint(ENDPOINTS.participant)
        .post(values)
        .then((res) => console.log(res))
        .catch((err) => console.log(err));
    }
  };

  const validate = () => {
    let temp = {};
    temp.email = /\S+@\S+\.\S+/.test(values.email) ? "" : "Email is not valid.";
    temp.name = values.name != "" ? "" : "This field is required.";
    setErrors(temp);
    return Object.values(temp).every((x) => x == "");
  };

  return (
    <Center>
      <Card sx={{ width: "400" }}>
        <CardContent sx={{ textAlign: "center" }}>
          <Typography variant="h3" sx={{ my: 3 }}>
            Quiz App
          </Typography>
          <Box
            sx={{
              "& .MuiTextField-root": {
                m: 1,
                width: "90%",
              },
            }}
          >
            <form noValidate autoComplete="on" onSubmit={login}>
              <TextField
                label="Email"
                name="email"
                variant="outlined"
                value={values.email}
                onChange={handleInputChange}
                {...(errors.email && { error: true, helperText: errors.email })}
              />
              <TextField
                label="Name"
                name="name"
                variant="outlined"
                value={values.name}
                onChange={handleInputChange}
                {...(errors.name && { error: true, helperText: errors.email })}
              />
              <Button
                type="submit"
                variant="contained"
                size="large"
                sx={{ width: "90" }}
              >
                Start
              </Button>
            </form>
          </Box>
        </CardContent>
      </Card>
    </Center>
  );
}
