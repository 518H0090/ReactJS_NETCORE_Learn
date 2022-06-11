import React from "react";
import Employee from "./Employee";

export default function EmployeeList() {
  return (
    <div className="row">
      <div className="col-md-12">
        <div class="mt-4 p-5 py-4 bg-primary text-white rounded">
          <div className="container text-center">
            <h1 className="display-4">Employee Register</h1>
          </div>
        </div>
      </div>
      <div className="col-md-4">
        <Employee />
      </div>
      <div className="col-md-4">
        <div>List of Employee</div>
      </div>
    </div>
  );
}
