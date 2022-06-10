import React from "react";
import "./App.css";

function App() {
  return (
    <div className="App">
      {/* Nav */}
      <nav className="navbar navbar-expand-md navbar-dark bg-dark mb-4">
        <div className="container-fluid">
          <a className="navbar-brand" href="#">
            Home
          </a>

          <div>
            <ul className="navbar-nav me-auto mb-2 mb-md-0">
              <li className="nav-item">
                <a className="nav-link active" aria-current="page" href="#">
                  Login
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link active" aria-current="page" href="#">
                  Register
                </a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      {/* Login Form */}
      <main className="form-signin w-100 m-auto">
        <form>
          <h1 className="h3 mb-3 fw-normal">Please sign in</h1>

          <div className="form-floating">
            <input
              type="email"
              className="form-control"
              placeholder="name@example.com"
            />
          </div>
          <div className="form-floating">
            <input
              type="password"
              className="form-control"
              placeholder="Password"
            />
          </div>

          <button className="w-100 btn btn-lg btn-primary" type="submit">
            Sign in
          </button>
        </form>
      </main>
    </div>
  );
}

export default App;
