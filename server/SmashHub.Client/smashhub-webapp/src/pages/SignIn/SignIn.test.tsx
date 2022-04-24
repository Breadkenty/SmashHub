import React from "react";
import { render, screen } from "@testing-library/react";
import SignIn from "./SignIn";

test("renders SignIn", () => {
  render(<SignIn />);
  const element = screen.getByText(/SignIn/i);
  expect(element).toBeInTheDocument();
});
