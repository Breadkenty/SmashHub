import React from "react";
import { render, screen } from "@testing-library/react";
import NavBar from "./NavBar";

test("renders NavBar", () => {
  render(
    <NavBar authenticated={false}>
      <h1>Content</h1>
    </NavBar>
  );
  const element = screen.getByText(/NavBar/i);
  expect(element).toBeInTheDocument();
});
